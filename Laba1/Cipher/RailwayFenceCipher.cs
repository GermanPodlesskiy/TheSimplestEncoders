using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Laba1.Interfaces;

namespace Laba1.Cipher
{
	class RailwayFenceCipher : ICipher
	{
		private Error.Error errors = new Error.Error();
		private bool error;
		private string key;

		//private char[] characters = new char[]
		//{
		//	'A','B','C','D','E','F','G','H','I','J','K','L','M','N',
		//	'O','P','Q','R','S','T','U','V','W','X','Y','Z'
		//};

		//private char[] otherCharacters = new char[]
		//{
		//	' ', '.', ',', '-', '"', '\'',':','(',')'
		//};

		public string Key
		{
			get { return key; }
			set
			{
				error = false;
				value = value.ToUpper();
				if (InputValidationKey(value))
				{
					error = true;
				}

				if (!error)
					key = value;
			}
		}

		public bool Error
		{
			get { return error; }
		}

		public string Encryption(string plaintext)
		{
			plaintext = plaintext.ToUpper();
			if (InputValidationPlaintext(ref plaintext))
			{
				return null;
			}

			if (Convert.ToInt32(key) == 1)
				return plaintext;
			char[,] ciperMatr = new char[Convert.ToInt32(key), plaintext.Length];
			string result = null;

			int i = 0;
			int j = 0;
			bool direction = true;
			while (j < plaintext.Length)
			{
				ciperMatr[i, j] = plaintext[j];
				if (i == 0)
				{
					direction = true;
				}
				else if (i == Convert.ToInt32(key) - 1)
				{
					direction = false;
				}

                i = direction ? i++ : i--;
				j++;
			}

			i = 0;
			while (i < Convert.ToInt32(key))
			{
				j = 0;
				while (j < plaintext.Length)
				{
					if (ciperMatr[i, j] != '\0')
					{
						result += ciperMatr[i, j];
					}
					j++;
				}
				i++;
			}
			return result;
		}

		public string Decryption(string ciphertext)
		{
			if (InputValidationPlaintext(ref ciphertext))
			{
				return null;
			}
			if (Convert.ToInt32(key) == 1)
				return ciphertext;
			Dictionary<int, char> resultDictionary = new Dictionary<int, char>();
			int[,] ciperMatr = new int[Convert.ToInt32(key), ciphertext.Length];
			string result = null;
			string tmpString = null;

			int i = 0;
			int j = 0;
			bool direction = true;
			while (j < ciphertext.Length)
			{
				ciperMatr[i, j] = j + 1;
				if (i == 0)
				{
					direction = true;
				}
				else if (i == Convert.ToInt32(key) - 1)
				{
					direction = false;
				}

                i = direction ? i++ : i--;
                j++;
			}

			i = 0;
			int k = 0;
			while (i < Convert.ToInt32(key))
			{
				j = 0;
				while (j < ciphertext.Length)
				{
					if (ciperMatr[i, j] != 0)
					{
						resultDictionary.Add(ciperMatr[i, j], ciphertext[k]);
						k++;
					}
					j++;
				}
				i++;
			}

			
			var orderedNubmers = resultDictionary.OrderBy(u => u.Key);

			foreach (var value in orderedNubmers)
			{
				result += value.Value;
			}

			return result;
		}

		private bool InputValidationKey(string key)
		{
			try
			{
				if (Convert.ToUInt16(key) <= 0)
					return true;
			}
			catch (Exception e)
			{
				errors.WarningKey();
				return true;
			}

			return false;
		}

		public bool InputValidationPlaintext(ref string plaintext)
		{
			plaintext.ToUpper();
			plaintext = Regex.Replace(plaintext, @"[^A-Z]", "");
			if (String.IsNullOrEmpty(plaintext))
			{
				errors.Empty();
				return true;
			}
			return false;
		}
	}
}