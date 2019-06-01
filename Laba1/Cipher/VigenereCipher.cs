using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TheSimplestEncoders.Cipher
{
    public class VigenereCipher : ICipher
    {
        private Error _errors = new Error();
        private bool _error;
        private string key;
        private int? lengthKey;
        private List<Lgram> _lgrams;
        private int _lgramTextLength;
        private const int DigramLength = 3;

        private char[] _characters =
        {
            'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н',
            'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я'
        };

        private static readonly double[] Frequency =
        {
            0.07821, 0.01732, 0.04491, 0.01698, 0.03103, 0.08567, 0.0007, 0.01082, 0.01647, 0.06777, 0.01041,
            0.03215, 0.04813, 0.03139, 0.0685, 0.11394, 0.02754, 0.04234, 0.05382, 0.06443, 0.02882, 0.00132,
            0.00833, 0.00333, 0.01645, 0.00775, 0.00331, 0.00023, 0.01854, 0.02106, 0.0031, 0.00544, 0.01979
        };

        public List<Lgram> Lgrams => _lgrams;
        public int LengthKey => lengthKey != null && lengthKey.Value.Equals(null) ? lengthKey.Value : 0;
        public bool DifKey { get; set; }

        public string Key
        {
            get => key;
            set
            {
                _error = false;
                value = value.ToUpper();
                if (InputValidationKey(value))
                {
                    _error = true;
                }

                if (!_error)
                {
                    key = value;
                }
            }
        }

        public bool Error => _error;

        public string Encryption(string plaintext)
        {
            var length = _characters.Length;
            plaintext = plaintext.ToUpper();
            if (InputValidationPlaintext(ref plaintext))
            {
                return null;
            }

            var result = new StringBuilder();
            var keyIndex = 0;
            var keyTmp = new StringBuilder(key.ToUpper());

            foreach (var symbol in plaintext)
            {
                if (_characters.Contains(symbol))
                {
                    var c = (Array.IndexOf(_characters, symbol) + Array.IndexOf(_characters, keyTmp[keyIndex])) %
                            length;
                    result.Append(_characters[c]);
                    keyIndex++;
                    if (keyIndex != keyTmp.Length)
                    {
                        continue;
                    }

                    if (!DifKey)
                    {
                        for (var i = 0; i < key.Length; i++)
                        {
                            keyTmp[i] = keyTmp[i] == 'Я'
                                ? keyTmp[i] = 'А'
                                : keyTmp[i] = _characters[Array.IndexOf(_characters, keyTmp[i]) + 1];
                        }
                    }

                    keyIndex = 0;
                }
                else
                {
                    result.Append(symbol);
                }
            }

            return result.ToString();
        }

        public string Decryption(string cipherText)
        {
            var length = _characters.Length;
            if (InputValidationPlaintext(ref cipherText))
            {
                return null;
            }

            var result = new StringBuilder();
            var keyIndex = 0;
            var keyTmp = new StringBuilder(key.ToUpper());

            foreach (var symbol in cipherText)
            {
                if (_characters.Contains(symbol))
                {
                    var p =
                        (Array.IndexOf(_characters, symbol) + length - Array.IndexOf(_characters, keyTmp[keyIndex])) %
                        length;
                    result.Append(_characters[p]);
                    keyIndex++;
                    if (keyIndex != keyTmp.Length)
                    {
                        continue;
                    }

                    if (!DifKey)
                    {
                        for (var i = 0; i < key.Length; i++)
                        {
                            keyTmp[i] = keyTmp[i] == 'Я'
                                ? keyTmp[i] = 'А'
                                : keyTmp[i] = _characters[Array.IndexOf(_characters, keyTmp[i]) + 1];
                        }
                    }

                    keyIndex = 0;
                }
                else
                {
                    result.Append(symbol);
                }
            }

            return result.ToString();
        }

        public static int Node(int a, int b)
        {
            while (true)
            {
                if (b == 0) return a;
                var a1 = a;
                a = b;
                b = a1 % b;
            }
        }

        public void TestKasiski(string plainttext)
        {
            var repeatCount = new List<int>(); //заполняем лист, ища расстояние между одинаковыми триграммами

            _lgrams = new List<Lgram>();
            //список для хранения всех триграмм с их длинной и максимальным значением НОД
            var tempLgrams = new Lgram();
            var result = new List<Pair>();
            int i;
            for (i = 0; i < plainttext.Length - DigramLength + 1; i++)
            {
                //indexLength = 0;
                var temp = plainttext.Substring(i, DigramLength);

                if (i != 0 && tempLgrams.Lengths.Count >= 2)
                {
                    _lgrams.Add(new Lgram()
                        {Digram = tempLgrams.Digram, Gcd = tempLgrams.Gcd, Lengths = tempLgrams.Lengths});
                }


                tempLgrams.Lengths = new List<int>();
                tempLgrams.Digram = temp;
                for (var j = i + 1; j < plainttext.Length - DigramLength + 1; j++)
                {
                    var temp2 = plainttext.Substring(j, DigramLength);
                    if (!temp.Equals(temp2))
                    {
                        continue;
                    }

                    repeatCount.Add(j - i);
                    tempLgrams.Lengths.Add(j - i);
                }
            }

            for (i = 0; i < _lgrams.Count; i++)
            {
                var nodsDigram = new int[5000];
                //массив для подсчета количества НОД 
                //nodsAll[НОД]++
                for (var k = 0; k < _lgrams[i].Lengths.Count; k++)
                for (var j = k + 1; j < _lgrams[i].Lengths.Count; j++)
                {
                    nodsDigram[Node(_lgrams[i].Lengths[k], _lgrams[i].Lengths[j])]++;
                }

                nodsDigram[0] = 0;
                result.Clear();
                for (var k = 1; k < 5000; ++k)
                {
                    result.Add(new Pair() {Index = k, Value = nodsDigram[k]});
                }

                var resultSortTake = result.OrderByDescending(u => u.Value).Take(1);
                var res = resultSortTake.First().Index;
                _lgrams[i].Gcd = res;
            }

            var nodsAll = new int[10000];
            for (i = 0; i < repeatCount.Count - 1; ++i)
            for (var j = i + 1; j <= repeatCount.Count - 1; ++j)
            {
                nodsAll[Node(repeatCount[i], repeatCount[j])]++;
            }

            nodsAll[0] = 0;
            result.Clear();
            for (i = 2; i < 500; ++i)
            {
                result.Add(new Pair() {Index = i, Value = nodsAll[i]});
            }

            lengthKey = result.OrderByDescending(u => u.Value).First().Index;
        }

        public string FrequencyAnalysis(string text, int lengthKey)
        {
            var frequency = new double[lengthKey, _characters.Length];
            var count = new int[lengthKey];
            var j = 0;
            foreach (var symbol in text)
            {
                if (!_characters.Contains(symbol))
                {
                    continue;
                }

                frequency[j % lengthKey, Array.IndexOf(_characters, symbol)]++;
                count[j % lengthKey]++;
                j++;
            }

            for (var i = 0; i < lengthKey; i++)
            for (j = 0; j < _characters.Length; j++)
            {
                frequency[i, j] /= count[i];
            }

            int index;
            double sum, maxSum;
            var newKey = string.Empty;
            //Каждый символ ключа находим из самой большой суммы строки(сумма строки = табличная частота * частату шифра текста)
            for (var k = 0; k < lengthKey; k++)
            {
                index = 0;
                maxSum = 0;
                //таблица виженера
                for (var i = 0; i < _characters.Length; i++)
                {
                    sum = 0;
                    //i-ая строка в таблице(состоит из шифра Цезаря с ключом i)
                    for (j = 0; j < _characters.Length; j++)
                    {
                        sum += frequency[k, j] * Frequency[(j + _characters.Length - i) % _characters.Length];
                    }

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        index = i;
                    }
                }

                newKey += _characters[index];
            }

            key = newKey;
            return Decryption(text);
        }

        private bool InputValidationKey(string key)
        {
            foreach (var symbol in key)
            {
                if (!_characters.Contains(symbol))
                {
                    _errors.WarningKey();
                    return true;
                }
            }

            return false;
        }

        private bool InputValidationPlaintext(ref string plaintext)
        {
            plaintext.ToUpper();
            plaintext = Regex.Replace(plaintext, @"[^А-ЯЁ]+", "");
            if (string.IsNullOrEmpty(plaintext))
            {
                _errors.Empty();
                return true;
            }

            return false;
        }
    }
}