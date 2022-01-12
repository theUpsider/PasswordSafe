using System.Security.Cryptography;
using System.Text;

namespace PasswordSafeLibrary {
    public class AESEncryption : IEncryptionMethod {
        private Aes aes;
        public AESEncryption() {
            aes = Aes.Create();
        }
        public string decrypt(byte[] key, byte[] crypted) {
            using (var decryptor = aes.CreateDecryptor(key, key)) {
                var decryptedBytes = decryptor
                    .TransformFinalBlock(crypted, 0, crypted.Length);
                return Encoding.UTF8.GetString(decryptedBytes);
            }
        }
        public byte[] encrypt(byte[] key, string plain) {
            using (var encryptor = aes.CreateEncryptor(key, key)) {
                var plainText = Encoding.UTF8.GetBytes(plain);
                return encryptor.TransformFinalBlock(plainText, 0, plainText.Length);
            }
        }
    }
}
