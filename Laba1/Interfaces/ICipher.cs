namespace Laba1.Interfaces
{
	public interface ICipher
	{
		string Key { get; set; }
		bool Error { get; }
		string Encryption(string plaintext);
		string Decryption(string ciphertext);
	}
}