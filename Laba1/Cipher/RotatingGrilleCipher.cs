using Laba1.Interfaces;
using System;
using System.Text.RegularExpressions;

namespace Laba1.Cipher
{
	class RotatingGrilleCipher : ICipher
	{
		private Error.Error error = new Error.Error();
		private string key;
		private const int COUNT_COLS = 4;
		private int[,] keyMatr = new int[COUNT_COLS, COUNT_COLS];
		char[,] tempMatrix = new Char[COUNT_COLS,COUNT_COLS];

		private char[] characters = new char[]
		{
			'A','B','C','D','E','F','G','H','I','J','K','L','M','N',
			'O','P','Q','R','S','T','U','V','W','X','Y','Z'
		};

		//private char[] otherCharacters = new char[]
		//{
		//	' ', '.', ',', '-', '"', '\'',':','(',')','*'
		//};

		public string Key{get{return key;}set { key = Convert.ToString(COUNT_COLS); }
		}

		public int[,] KeyMatr
		{
			get { return keyMatr; }
			set { keyMatr = value; }
		}

		public bool Error { get { return false; } }


		public string Encryption(string plaintext)
		{
			plaintext = plaintext.ToUpper();
			if (InputValidationPlaintext(ref plaintext))
			{
				return null;
			}

			string result = null;
			int plaintextIndex = 0;

			while (plaintextIndex != plaintext.Length)
			{
				tempMatrix = ClearMatrix(tempMatrix);
				for (int i = 0; i < COUNT_COLS; i++)
				{
					if (plaintextIndex == plaintext.Length)
						break;
					for (int j = 0; j < COUNT_COLS; j++)
						if (keyMatr[i, j] == 1)
						{
							if (plaintextIndex == plaintext.Length)
								break;

							tempMatrix[i, j] = plaintext[plaintextIndex++];
						}
				}


				// поворот решетки на 90 градусов по часовой стрелке
				for (int i = 0; i < COUNT_COLS; i++)
				{
					if (plaintextIndex == plaintext.Length)
						break;
					for (int j = 0; j < COUNT_COLS; j++)
						if (keyMatr[COUNT_COLS - j - 1, i] == 1)
						{
							if (plaintextIndex == plaintext.Length)
								break;

							tempMatrix[i, j] = plaintext[plaintextIndex++];
						}
				}

				// поворот решетки на 180 градусов по часовой стрелке
				for (int i = 0; i < COUNT_COLS; i++)
				{
					if (plaintextIndex == plaintext.Length)
						break;
					for (int j = 0; j < COUNT_COLS; j++)
						if (keyMatr[COUNT_COLS - i - 1, COUNT_COLS - j - 1] == 1)
						{
							if (plaintextIndex == plaintext.Length)
								break;

							tempMatrix[i, j] = plaintext[plaintextIndex++];
						}
				}

				// поворот решетки на 270 градусов по часовой стрелке
				for (int i = 0; i < COUNT_COLS; i++)
				{
					if (plaintextIndex == plaintext.Length)
						break;
					for (int j = 0; j < COUNT_COLS; j++)
						if (keyMatr[j, COUNT_COLS - i - 1] == 1)
						{
							if (plaintextIndex == plaintext.Length)
								break;

							tempMatrix[i, j] = plaintext[plaintextIndex++];
						}
				}
				foreach (char symbol in tempMatrix)
				{
					result += symbol;
				}
			}

			return result;
		}

		public string Decryption(string ciphertext)
		{
			ciphertext = ciphertext.ToUpper();
			if (ciphertext.Length % 16 != 0)
			{
				error.ValidationRotation();
				return null;
			}
			if (InputValidationPlaintext(ref ciphertext))
			{
				return null;
			}

			string result = null;
			int ciphertextIndex = 0;

			while (ciphertextIndex != ciphertext.Length)
			{
				int bufindex = ciphertextIndex;
				for (int i = 0; i < COUNT_COLS; i++)
					for (int j = 0; j < COUNT_COLS; j++)
					{
						tempMatrix[i, j] = ciphertext[bufindex++];
					}

				for (int i = 0; i < COUNT_COLS; i++)
				{
					for (int j = 0; j < COUNT_COLS; j++)
						if (keyMatr[i, j] == 1)
						{
							ciphertextIndex++;
							result += tempMatrix[i, j];
						}
				}


				// поворот решетки на 90 градусов по часовой стрелке
				for (int i = 0; i < COUNT_COLS; i++)
				{
					for (int j = 0; j < COUNT_COLS; j++)
						if (keyMatr[COUNT_COLS - j - 1, i] == 1)
						{
							ciphertextIndex++;
							result += tempMatrix[i, j];
						}
				}

				// поворот решетки на 180 градусов по часовой стрелке
				for (int i = 0; i < COUNT_COLS; i++)
				{
					for (int j = 0; j < COUNT_COLS; j++)
						if (keyMatr[COUNT_COLS - i - 1, COUNT_COLS - j - 1] == 1)
						{
							ciphertextIndex++;
							result += tempMatrix[i, j];
						}
				}

				// поворот решетки на 270 градусов по часовой стрелке
				for (int i = 0; i < COUNT_COLS; i++)
				{
					for (int j = 0; j < COUNT_COLS; j++)
						if (keyMatr[j, COUNT_COLS - i - 1] == 1)
						{
							ciphertextIndex++;
							result += tempMatrix[i, j];
						}
				}
			}

			result = Regex.Replace(result, @"[^A-Z]","");
			return result;
		}

		
		private char[,] ClearMatrix(char[,] matrix)
		{
			//Random random = new Random();
			for (int i = 0; i < COUNT_COLS; i++)
			for (int j = 0; j < COUNT_COLS; j++)
			{
					//int temp = random.Next(0,characters.Length - 1 );
					//matrix[i, j] = characters[temp];
					matrix[i, j] = '*';
				}
				
			return matrix;
		}
		private bool InputValidationPlaintext(ref string plaintext)
		{
			plaintext = plaintext.ToUpper();
			plaintext = Regex.Replace(plaintext, @"[^A-Z*]+", "");

			if (plaintext == "")
			{
				error.Empty();
				return true;
			}
			else
				return false;
		}
	}
}