using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace PasswordSafeConsole {
    public class Program {
        //remove later
        private static MasterPasswordRepository masterRepository = new MasterPasswordRepository(ConfigurationManager.AppSettings.Get("masterpassword_path") + "master.pw");
        private static PasswordSafeEngine passwordSafeEngine = null;
        // https://docs.microsoft.com/de-de/dotnet/api/system.security.cryptography.passwordderivebytes?view=net-6.0

        public static void Main(String[] args) {
            Console.WriteLine("Welcome to Passwordsafe");

            bool abort = false;
            bool unlocked = false;
            while (!abort) {
                Console.WriteLine("Enter master (1), show all (2), show single (3), add (4), delete(5), set new master (6), set master pw location (7), set passwords location (8), Abort (0)");
                int input = 0;
                if (!int.TryParse(Console.ReadLine(), out input)) {
                    input = -1;
                }
                switch (input) {
                    case 0: {
                            abort = true;
                            break;
                        }
                    case 1: {
                            Console.WriteLine("Enter master password");
                            var masterPw = Console.ReadLine();

                            var aes = new AESEncryption();
                            byte[] masterPwByte = aes.encrypt(CipherFacility.GetKey(Encoding.UTF8.GetBytes(masterPw)), masterPw);

                            unlocked = masterRepository.MasterPasswordIsEqualTo(masterPwByte);
                            if (unlocked) {
                                passwordSafeEngine = new PasswordSafeEngine(ConfigurationManager.AppSettings.Get("passwords_path"),
                                    new CipherFacility(Encoding.UTF8.GetBytes(masterPw)));
                                Console.WriteLine("unlocked");
                            } else {
                                Console.WriteLine("master password did not match ! Failed to unlock.");
                            }
                            break;
                        }
                    case 2: {
                            if (unlocked) {
                                passwordSafeEngine.GetStoredPasswords().ToList().ForEach(pw => Console.WriteLine(pw));
                            } else {
                                Console.WriteLine("Please unlock first by entering the master password.");
                            }
                            break;
                        }
                    case 3: {
                            if (unlocked) {
                                Console.WriteLine("Enter password name");
                                string passwordName = Console.ReadLine();
                                Console.WriteLine(passwordSafeEngine.GetPassword(passwordName));
                            } else {
                                Console.WriteLine("Please unlock first by entering the master password.");
                            }
                            break;
                        }
                    case 4: {
                            if (unlocked) {
                                Console.WriteLine("Enter new name of password");
                                String passwordName = Console.ReadLine();
                                Console.WriteLine("Enter password");
                                String password = Console.ReadLine();
                                passwordSafeEngine.AddNewPassword(new PasswordInfo(password, passwordName));
                            } else {
                                Console.WriteLine("Please unlock first by entering the master password.");
                            }
                            break;
                        }
                    case 5: {
                            if (unlocked) {
                                Console.WriteLine("Enter password name");
                                String passwordName = Console.ReadLine();
                                passwordSafeEngine.DeletePassword(passwordName);
                            } else {
                                Console.WriteLine("Please unlock first by entering the master password.");
                            }
                            break;
                        }
                    case 6: {
                            unlocked = false;
                            passwordSafeEngine = null;
                            Console.WriteLine("Enter new master password ! (Warning you will loose all already stored passwords)");
                            string masterPw = Console.ReadLine();
                            var aes = new AESEncryption();
                            byte[] masterPwByteEncrypted = aes.encrypt(CipherFacility.GetKey(Encoding.UTF8.GetBytes(masterPw)), masterPw);
                            Console.WriteLine("Enter again");
                            string masterPw_second = Console.ReadLine();
                            byte[] masterPwByteEncrypted_second = aes.encrypt(CipherFacility.GetKey(Encoding.UTF8.GetBytes(masterPw_second)), masterPw_second);

                            if (masterPwByteEncrypted.SequenceEqual(masterPwByteEncrypted_second)) {
                                masterRepository.SetMasterPasswordEncrypted(masterPw);
                                // urgent hotfix delete old passwords after changing the master
                                if (Directory.Exists("./passwords.pw")) {
                                    Directory.Delete("./passwords.pw", true);
                                }
                            } else
                                Console.WriteLine("Passwords do not match");

                            break;
                        }
                    case 7: {
                            if (unlocked) {
                                Console.WriteLine("Enter new path for master password file like: C:/User/data/folder");
                                string masterPwPath = Console.ReadLine();
                                ConfigurationManager.AppSettings.Set("masterpassword_path", masterPwPath);
                            } else {
                                Console.WriteLine("Please unlock first by entering the master password.");
                            }
                        }
                        break;
                    case 8: {
                            if (unlocked) {
                                Console.WriteLine("Enter new path for passwords location like: C:/User/data/folder");
                                string PwPath = Console.ReadLine();
                                ConfigurationManager.AppSettings.Set("passwords_path", PwPath);
                            } else {
                                Console.WriteLine("Please unlock first by entering the master password.");
                            }
                        }
                        break;
                    default: {
                            Console.WriteLine("Invalid input");
                            break;
                        }

                }
            }

            Console.WriteLine("Good bye !");
        }

        //////////////////////////////////////////////////////////
        // Helper methods:
        // CreateRandomSalt: Generates a random salt value of the
        //                   specified length.
        //
        // ClearBytes: Clear the bytes in a buffer so they can't
        //             later be read from memory.
        //////////////////////////////////////////////////////////

        public static byte[] CreateRandomSalt(int length) {
            // Create a buffer
            byte[] randBytes;

            if (length >= 1) {
                randBytes = new byte[length];
            } else {
                randBytes = new byte[1];
            }

            // Create a new RNGCryptoServiceProvider.
            RNGCryptoServiceProvider rand = new RNGCryptoServiceProvider();

            // Fill the buffer with random bytes.
            rand.GetBytes(randBytes);

            // return the bytes.
            return randBytes;
        }

        public static void ClearBytes(byte[] buffer) {
            // Check arguments.
            if (buffer == null) {
                throw new ArgumentException("buffer");
            }

            // Set each byte in the buffer to 0.
            for (int x = 0; x < buffer.Length; x++) {
                buffer[x] = 0;
            }
        }
    }
}
