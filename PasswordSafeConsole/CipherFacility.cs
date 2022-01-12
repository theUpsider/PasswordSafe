using System;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;

namespace PasswordSafeConsole {
    public enum EncryptionType {
        AESEncryption
    }
    internal class CipherFacility {
        private byte[] masterPw;
        private IEncryptionMethod encryptionMethod;

        public CipherFacility(byte[] masterPwByte) {
            this.masterPw = masterPwByte;
            EncryptionType encryption;
            EncryptionType prevEncryption;
            // read config
            Enum.TryParse(ConfigurationManager.AppSettings.Get("encryption"), out encryption);
            Enum.TryParse(ConfigurationManager.AppSettings.Get("previous_encryption"), out prevEncryption);

            ConfigurationManager.RefreshSection("appSettings");

            var ass = Assembly.GetExecutingAssembly();
            var type = ass.GetTypes().First(ts => ts.Name == encryption.ToString());

            // encryption method changed
            if (!prevEncryption.Equals(encryption)) {
                Console.WriteLine("The encryption type changed. Passwords may not be readable. If you want to change the type, put in <yes>. " +
                    "\nIf you want to stick to the old one put in <no>");
                string input = Console.ReadLine();
                switch (input) {
                    case "yes":
                        ConfigurationManager.AppSettings.Set("previous_encryption", ConfigurationManager.AppSettings.Get("encryption"));
                        break;
                    case "no":
                        type = ass.GetTypes().First(ts => ts.Name == prevEncryption.ToString());
                        break;
                    default:
                        // fall back if false userinput
                        break;
                }

            }

            // depending on config choose encryption. should not be changed.
            // to add a new encryption type, simply implement the interface using a new class and add below
            encryptionMethod = (IEncryptionMethod)Activator.CreateInstance(type);

        }

        public string Decrypt(byte[] crypted) {
            return encryptionMethod.decrypt(GetKey(masterPw), crypted);
        }

        public byte[] Encrypt(string plain) {
            return encryptionMethod.encrypt(GetKey(masterPw), plain);
        }

        public static byte[] GetKey(byte[] keyBytes) {
            using (var md5 = MD5.Create()) {
                return md5.ComputeHash(keyBytes);
            }
        }

    }
}