namespace TheSimplestEncoders
{
    public interface ICipher
    {
        string Key { get; set; }
        bool Error { get; }
        string Encryption(string plainText);
        string Decryption(string cipherText);
    }
}