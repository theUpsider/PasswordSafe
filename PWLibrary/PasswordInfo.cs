using System.Xml.Serialization;

namespace PasswordSafeLibrary {
    [XmlElement(ElementName = "Entry")]
    public class PasswordInfo {
        [XmlElement(ElementName = "Name")]
        public string PasswordName { get; set; }
        public string Password { get; set; }

        public PasswordInfo(string password, string passwordName) {
            this.Password = password;
            this.PasswordName = passwordName;
        }

        public PasswordInfo() { }
    }
}