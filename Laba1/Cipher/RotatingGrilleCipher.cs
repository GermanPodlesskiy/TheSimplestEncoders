using System;
using System.Text;
using System.Text.RegularExpressions;

namespace TheSimplestEncoders.Cipher
{
    public class RotatingGrilleCipher : ICipher
    {
        private Error _error = new Error();
        private string _key = Convert.ToString(CountCols);
        private const int CountCols = 4;
        private char[,] _tempMatrix = new char[CountCols, CountCols];

        private char[] characters = new char[]
        {
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N',
            'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
        };

        public string Key
        {
            get => _key;
            set { }
        }

        public int[,] KeyMatrix { get; set; }

        public bool Error => false;

        public string Encryption(string plaintext)
        {
            plaintext = plaintext.ToUpper();
            if (new RailwayFenceCipher().InputValidationPlaintext(ref plaintext))
            {
                return null;
            }

            var result = new StringBuilder();
            var plaintextIndex = 0;

            while (plaintextIndex != plaintext.Length)
            {
                _tempMatrix = ClearMatrix(_tempMatrix);
                for (var i = 0; i < CountCols; i++)
                {
                    if (plaintextIndex == plaintext.Length)
                    {
                        break;
                    }

                    for (var j = 0; j < CountCols; j++)
                    {
                        if (KeyMatrix[i, j] != 1)
                        {
                            continue;
                        }

                        if (plaintextIndex == plaintext.Length)
                        {
                            break;
                        }

                        _tempMatrix[i, j] = plaintext[plaintextIndex++];
                    }
                }


                // поворот решетки на 90 градусов по часовой стрелке
                for (var i = 0; i < CountCols; i++)
                {
                    if (plaintextIndex == plaintext.Length)
                    {
                        break;
                    }

                    for (var j = 0; j < CountCols; j++)
                    {
                        if (KeyMatrix[CountCols - j - 1, i] != 1)
                        {
                            continue;
                        }

                        if (plaintextIndex == plaintext.Length)
                        {
                            break;
                        }

                        _tempMatrix[i, j] = plaintext[plaintextIndex++];
                    }
                }

                // поворот решетки на 180 градусов по часовой стрелке
                for (var i = 0; i < CountCols; i++)
                {
                    if (plaintextIndex == plaintext.Length)
                    {
                        break;
                    }

                    for (var j = 0; j < CountCols; j++)
                    {
                        if (KeyMatrix[CountCols - i - 1, CountCols - j - 1] != 1)
                        {
                            continue;
                        }

                        if (plaintextIndex == plaintext.Length)
                        {
                            break;
                        }

                        _tempMatrix[i, j] = plaintext[plaintextIndex++];
                    }
                }

                // поворот решетки на 270 градусов по часовой стрелке
                for (var i = 0; i < CountCols; i++)
                {
                    if (plaintextIndex == plaintext.Length)
                    {
                        break;
                    }

                    for (var j = 0; j < CountCols; j++)
                    {
                        if (KeyMatrix[j, CountCols - i - 1] != 1)
                        {
                            continue;
                        }

                        if (plaintextIndex == plaintext.Length)
                        {
                            break;
                        }

                        _tempMatrix[i, j] = plaintext[plaintextIndex++];
                    }
                }

                foreach (var symbol in _tempMatrix)
                {
                    result.Append(symbol);
                }
            }

            return result.ToString();
        }

        public string Decryption(string cipherText)
        {
            cipherText = cipherText.ToUpper();
            if (cipherText.Length % 16 != 0 || new RailwayFenceCipher().InputValidationPlaintext(ref cipherText))
            {
                _error.ValidationRotation();
                return null;
            }

            var result = new StringBuilder();
            var index = 0;

            while (index != cipherText.Length)
            {
                var bufIndex = index;
                for (var i = 0; i < CountCols; i++)
                for (var j = 0; j < CountCols; j++)
                {
                    _tempMatrix[i, j] = cipherText[bufIndex++];
                }

                for (var i = 0; i < CountCols; i++)
                {
                    for (var j = 0; j < CountCols; j++)
                    {
                        if (KeyMatrix[i, j] != 1)
                        {
                            continue;
                        }

                        index++;
                        result.Append(_tempMatrix[i, j]);
                    }
                }


                // поворот решетки на 90 градусов по часовой стрелке
                for (var i = 0; i < CountCols; i++)
                {
                    for (var j = 0; j < CountCols; j++)
                    {
                        if (KeyMatrix[CountCols - j - 1, i] != 1)
                        {
                            continue;
                        }

                        index++;
                        result.Append(_tempMatrix[i, j]);
                    }
                }

                // поворот решетки на 180 градусов по часовой стрелке
                for (var i = 0; i < CountCols; i++)
                {
                    for (var j = 0; j < CountCols; j++)
                    {
                        if (KeyMatrix[CountCols - i - 1, CountCols - j - 1] != 1)
                        {
                            continue;
                        }

                        index++;
                        result.Append(_tempMatrix[i, j]);
                    }
                }

                // поворот решетки на 270 градусов по часовой стрелке
                for (var i = 0; i < CountCols; i++)
                {
                    for (var j = 0; j < CountCols; j++)
                    {
                        if (KeyMatrix[j, CountCols - i - 1] != 1)
                        {
                            continue;
                        }

                        index++;
                        result.Append(_tempMatrix[i, j]);
                    }
                }
            }

            return Regex.Replace(result.ToString(), @"[^A-Z]", "");
        }


        private char[,] ClearMatrix(char[,] matrix)
        {
            for (var i = 0; i < CountCols; i++)
            for (var j = 0; j < CountCols; j++)
            {
                matrix[i, j] = '*';
            }

            return matrix;
        }
    }
}