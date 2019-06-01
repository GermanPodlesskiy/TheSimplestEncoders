using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TheSimplestEncoders.Cipher
{
    public class RailwayFenceCipher : ICipher
    {
        private Error _errors = new Error();
        public bool error;
        private string key;

        public string Key
        {
            get => key;
            set
            {
                error = false;
                value = value.ToUpper();
                if (InputValidationKey(value))
                {
                    error = true;
                }
                else
                {
                    key = value;
                }
            }
        }

        public bool Error => error;

        public string Encryption(string plaintext)
        {
            plaintext = plaintext.ToUpper();
            if (InputValidationPlaintext(ref plaintext))
            {
                return null;
            }

            if (Convert.ToInt32(key) == 1)
            {
                return plaintext;
            }

            var ciperMatrix = new char[Convert.ToInt32(key), plaintext.Length];
            string result = null;

            var i = 0;
            var j = 0;
            var direction = true;
            while (j < plaintext.Length)
            {
                ciperMatrix[i, j] = plaintext[j];
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
                    if (ciperMatrix[i, j] != '\0')
                    {
                        result += ciperMatrix[i, j];
                    }

                    j++;
                }

                i++;
            }

            return result;
        }

        public string Decryption(string cipherText)
        {
            if (InputValidationPlaintext(ref cipherText))
            {
                return null;
            }

            if (Convert.ToInt32(key) == 1)
            {
                return cipherText;
            }

            var resultDictionary = new Dictionary<int, char>();
            var ciperMatrix = new int[Convert.ToInt32(key), cipherText.Length];
            var result = new StringBuilder();

            var i = 0;
            var j = 0;
            var direction = true;
            while (j < cipherText.Length)
            {
                ciperMatrix[i, j] = j + 1;
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
            var k = 0;
            while (i < Convert.ToInt32(key))
            {
                j = 0;
                while (j < cipherText.Length)
                {
                    if (ciperMatrix[i, j] != 0)
                    {
                        resultDictionary.Add(ciperMatrix[i, j], cipherText[k]);
                        k++;
                    }

                    j++;
                }

                i++;
            }


            var orderedNubmers = resultDictionary.OrderBy(u => u.Key);

            foreach (var value in orderedNubmers)
            {
                result.Append(value.Value);
            }

            return result.ToString();
        }

        private bool InputValidationKey(string key)
        {
            try
            {
                if (Convert.ToUInt16(key) <= 0)
                {
                    return true;
                }
            }
            catch
            {
                _errors.WarningKey();
                return true;
            }

            return false;
        }

        public bool InputValidationPlaintext(ref string plaintext)
        {
            plaintext.ToUpper();
            plaintext = Regex.Replace(plaintext, @"[^A-Z]", "");
            if (!string.IsNullOrEmpty(plaintext))
            {
                return false;
            }

            _errors.Empty();
            return true;
        }
    }
}