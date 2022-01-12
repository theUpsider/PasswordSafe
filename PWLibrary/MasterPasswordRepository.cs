using System.IO;
using System.Linq;
using System.Text;

namespace PasswordSafeLibrary {
    public class MasterPasswordRepository {
        private string masterPasswordPath;

        public MasterPasswordRepository(string masterPasswordPath) {
            this.masterPasswordPath = masterPasswordPath;
        }

        public bool MasterPasswordIsEqualTo(string masterPwToCompare) {
            return File.Exists(this.masterPasswordPath) &&
                masterPwToCompare == File.ReadAllText(this.masterPasswordPath);
        }
        public bool MasterPasswordIsEqualTo(byte[] masterPwToCompare) {
            byte[] b = { };
            if (File.Exists(this.masterPasswordPath))
                b=File.ReadAllBytes(this.masterPasswordPath);
            return masterPwToCompare.SequenceEqual(b);
        }

        internal void SetMasterPasswordPlain(string masterPw) {
            File.WriteAllText(this.masterPasswordPath, masterPw);
        }

        internal void SetMasterPasswordEncrypted(string masterPw) {
            var aes = new AESEncryption();
            File.WriteAllBytes(this.masterPasswordPath,
                aes.encrypt(CipherFacility.GetKey(Encoding.UTF8.GetBytes(masterPw)), masterPw));
        }
    }
}