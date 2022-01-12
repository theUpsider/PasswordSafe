using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;

namespace PasswordSafeConsole {
    internal class PasswordSafeEngine {
        private string path;
        private CipherFacility cipherFacility;
        SqliteConnection sqlite_conn;

        public PasswordSafeEngine(string path, CipherFacility cipherFacility) {
            this.path = path;
            this.cipherFacility = cipherFacility;
            sqlite_conn = CreateConnection();

            CreateTable(sqlite_conn);
        }

        ~PasswordSafeEngine() {
            sqlite_conn.Close();
        }

        internal SqliteConnection CreateConnection() {

            SqliteConnection sqlite_conn;
            // Create a new database connection:
            sqlite_conn = new SqliteConnection($"Data Source={path}passwords.db");
            // Open the connection:
            try {
                sqlite_conn.Open();
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return sqlite_conn;
        }

        internal void CreateTable(SqliteConnection conn) {
            SqliteCommand sqlite_cmd;
            string Createsql = "CREATE TABLE IF NOT EXISTS SampleTable (pw_name TEXT, pw_hashed BLOB)";
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = Createsql;
            sqlite_cmd.ExecuteNonQuery();
        }

        internal IEnumerable<string> GetStoredPasswords() {
            SqliteDataReader sqlite_datareader;
            SqliteCommand sqlite_cmd;
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM SampleTable";

            sqlite_datareader = sqlite_cmd.ExecuteReader();
            List<string> password_names = new List<string>();
            while (sqlite_datareader.Read()) {
                string myreader = sqlite_datareader.GetString(0);
                password_names.Add(myreader);
            }
            return password_names;
        }

        internal string GetPassword(string passwordName) {
            SqliteCommand sqlite_cmd;
            sqlite_cmd = sqlite_conn.CreateCommand();
            //TODO sanity checks for string
            sqlite_cmd.CommandText = $"SELECT * FROM SampleTable WHERE pw_name = '{passwordName}'";

            using (var reader = sqlite_cmd.ExecuteReader()) {
                while (reader.Read()) {
                    byte[] buffer = GetBytes(reader);
                    return cipherFacility.Decrypt(buffer);
                }
            }
            // return message in case nothing was found
            return "No password for this entry";
        }

        internal void AddNewPassword(PasswordInfo passwordInfo) {

            SqliteCommand sqlite_cmd;
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "INSERT OR REPLACE INTO SampleTable (pw_name, pw_hashed) VALUES(@name, @hashed);";
            sqlite_cmd.Parameters.Add("@name", SqliteType.Text, passwordInfo.PasswordName.Length).Value = passwordInfo.PasswordName;
            sqlite_cmd.Parameters.Add("@hashed", SqliteType.Blob).Value = cipherFacility.Encrypt(passwordInfo.Password);
            sqlite_cmd.ExecuteNonQuery();
        }

        internal void DeletePassword(string passwordName) {
            SqliteCommand sqlite_cmd;
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = $"DELETE FROM SampleTable WHERE pw_name = '{passwordName}'";
            sqlite_cmd.ExecuteNonQuery();
        }

        static byte[] GetBytes(SqliteDataReader reader) {
            const int CHUNK_SIZE = 2 * 1024;
            byte[] buffer = new byte[CHUNK_SIZE];
            long bytesRead;
            long fieldOffset = 0;
            using (MemoryStream stream = new MemoryStream()) {
                while ((bytesRead = reader.GetBytes(1, fieldOffset, buffer, 0, buffer.Length)) > 0) {
                    stream.Write(buffer, 0, (int)bytesRead);
                    fieldOffset += bytesRead;
                }
                return stream.ToArray();
            }
        }
    }
}