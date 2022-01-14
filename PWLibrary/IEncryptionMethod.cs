namespace PasswordSafeLibrary {
    /// <summary>
    /// Every encryption type needs to implement this interface
    /// </summary>
    public interface IEncryptionMethod {
        // returns decrypted string
        string decrypt(byte[] key, byte[] crypted);
        // returns the transformed encryption
        byte[] encrypt(byte[] key, string text);
    }
}
