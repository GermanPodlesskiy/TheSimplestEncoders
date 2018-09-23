using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba1.Cipher
{
	class  Lgram
	{
		public string Digram { get; set; }
		public int Gcd { get; set; }
		public List<int> Lengths;
	}

	class ViginereCipher : Interfaces.ICipher
	{
		private Error.Error errors = new Error.Error();
		private bool error;
		private string key;
		private int? lengthKey;
		static double[] FREQUENCY = {0.07821, 0.01732, 0.04491, 0.01698, 0.03103, 0.08567, 0.0007, 0.01082, 0.01647, 0.06777, 0.01041,
			0.03215, 0.04813, 0.03139, 0.0685, 0.11394, 0.02754, 0.04234, 0.05382, 0.06443, 0.02882,  0.00132,
			0.00833, 0.00333, 0.01645, 0.00775, 0.00331, 0.00023, 0.01854, 0.02106, 0.0031, 0.00544, 0.01979};
		public int LengthKey
		{
			get
			{
				return lengthKey.Value.Equals(null) ? lengthKey.Value : 0;
			}
		}

		public bool DifKey { get; set; }
		List<Lgram> lgrams;
		private int lgramTextLength;
		public List<Lgram> Lgrams
		{
			get
			{
				return lgrams;
			}
		}
		private char[] characters = new char[]
		{
			'А','Б','В','Г','Д','Е','Ё','Ж','З','И','Й','К','Л','М','Н',
			'О','П','Р','С','Т','У','Ф','Х','Ц','Ч','Ш','Щ','Ъ','Ы','Ь','Э','Ю','Я'
		};
		//private char[] otherCharacters = new char[]
		//{
		//	' ', '.', ',', '-', '"', '\'',':','(',')'
		//};

		public string Key
		{
			get
			{
				return key;
			}
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

		public bool Error { get { return error;} }

		public string Encryption(string plaintext)
		{
			
			int N = characters.Length;
			plaintext = plaintext.ToUpper();
			if (InputValidationPlaintext(ref plaintext))
			{
				return null;
			}
			string result = null;
			int keyIndex = 0;
			StringBuilder keyTmp = new StringBuilder(key.ToUpper());

			foreach (char symbol in plaintext)
			{
				if (characters.Contains(symbol))
				{
					int c = (Array.IndexOf(characters, symbol) + Array.IndexOf(characters, keyTmp[keyIndex])) % N;
					result += characters[c];
					keyIndex++;
					if (keyIndex == keyTmp.Length)
					{
						if (!DifKey)
						{
							for (int i = 0; i < key.Length; i++)
								keyTmp[i] = (keyTmp[i] == 'Я') ? keyTmp[i] = 'А' : keyTmp[i] = characters[Array.IndexOf(characters, keyTmp[i]) + 1];

						}
						keyIndex = 0;
					}
				}
				else { result += symbol; }
			}
			return result;
		}

		public string Decryption(string ciphertext)
		{
			int N = characters.Length;
			if (InputValidationPlaintext(ref ciphertext))
			{
				return null;
			}
			string result = null;
			int keyIndex = 0;
			StringBuilder keyTmp = new StringBuilder(key.ToUpper());

			foreach (char symbol in ciphertext)
			{
				if (characters.Contains(symbol))
				{
					int p = (Array.IndexOf(characters, symbol) + N - Array.IndexOf(characters, keyTmp[keyIndex])) % N;
					result += characters[p];
					keyIndex++;
					if (keyIndex == keyTmp.Length)
					{
						if (!DifKey)
						{
							for (int i = 0; i < key.Length; i++)
								keyTmp[i] = (keyTmp[i] == 'Я') ? keyTmp[i] = 'А' : keyTmp[i] = characters[Array.IndexOf(characters, keyTmp[i]) + 1];

						}
						
						keyIndex = 0;
					}
				}
				else { result += symbol; }

			}

			return result;
		}

		struct Pair //класс пары, нужен для подсчета в конце
		{
			public int Index { get; set; }
			public int Value { get; set; }
		}

		const int digramLength = 3; //количество символов, которое должно совпадать

		public static int node(int a, int b)
		{
			if (b == 0)
			{
				return a;
			}
			else
			{
				return node(b, a % b);
			}
		}

		public void TestKasiski(string plainttext)
		{
			List<int> repeatCount = new List<int>();//заполняем лист, ища расстояние между одинаковыми триграммами

			lgrams = new List<Lgram>();
			//список для хранения всех триграмм с их длинной и максимальным значением НОД
			Lgram tempLgrams = new Lgram();
			List<Pair> result = new List<Pair>();
			int i;
			for (i = 0; i < plainttext.Length - digramLength + 1; i++)
			{
				//indexLength = 0;
				string temp = plainttext.Substring(i, digramLength);
				if ((i != 0))
					if(tempLgrams.Lengths.Count >= 2)
						lgrams.Add(new Lgram(){Digram = tempLgrams.Digram, Gcd = tempLgrams.Gcd, Lengths = tempLgrams.Lengths});


				tempLgrams.Lengths = new List<int>();
				tempLgrams.Digram = temp;
				for (int j = i + 1; j < plainttext.Length - digramLength + 1; j++)
				{
					string temp2 = plainttext.Substring(j, digramLength);
					if (temp.Equals(temp2))
					{
						repeatCount.Add(j - i);
						tempLgrams.Lengths.Add(j - i);
					}
				}
			}

			for ( i = 0; i < lgrams.Count; i++)
			{
				int[] nodsDigram = new int[5000];
				//массив для подсчета количества НОД 
				//nodsAll[НОД]++
				for (int k = 0; k < lgrams[i].Lengths.Count; k++)
					for (int j = k + 1; j < lgrams[i].Lengths.Count; j++)
						nodsDigram[node(lgrams[i].Lengths[k], lgrams[i].Lengths[j])]++;
				nodsDigram[0] = 0;
				result.Clear();
				for (int k = 1; k < 5000; ++k)
				{
					result.Add(new Pair() { Index = k, Value = nodsDigram[k] });
				}
				var resultSortTake = result.OrderByDescending(u => u.Value).Take(1);
				int res = resultSortTake.Cast<Pair>().First().Index;
				lgrams[i].Gcd = res;
			}

			int[] nodsAll = new int[10000];
			for (i = 0; i < repeatCount.Count-1; ++i)
			for (int j = i + 1; j <= repeatCount.Count - 1; ++j)
			{ 
				nodsAll[node(repeatCount[i], repeatCount[j])]++;
			}
			nodsAll[0] = 0;
			result.Clear();
			for (i = 2; i < 500; ++i)
			{
				result.Add(new Pair() { Index = i, Value = nodsAll[i] });
			}
            
			var resulSortTake2 = result.OrderByDescending(u => u.Value).Take(1);

			lengthKey = resulSortTake2.Cast<Pair>().First().Index;

		}

		public string FrequencyAnalysis(string text,int lengthKey)
		{
			double[,] frequency = new double[lengthKey, characters.Length];
			int[] count = new int[lengthKey];
			int j = 0;
			for (int i = 0; i < text.Length; i++)
				if (characters.Contains(text[i]))
				{
					frequency[j % lengthKey, Array.IndexOf(characters,text[i])]++;
					count[j % lengthKey]++;
					j++;
				}
			for (int i = 0; i < lengthKey; i++)
			for (j = 0; j < characters.Length; j++)
				frequency[i, j] /= count[i];

			int index;
			double sum, maxSum;
			string newKey = "";
			//Каждый символ ключа находим из самой большой суммы строки(сумма строки = табличная частота * частату шифра текста)
			for (int k = 0; k < lengthKey; k++)
			{
				index = 0;
				maxSum = 0;
				//таблица виженера
				for (int i = 0; i < characters.Length; i++)
				{
					sum = 0;
					//i-ая строка в таблице(состоит из шифра Цезаря с ключом i)
					for (j = 0; j < characters.Length; j++)
						sum += frequency[k, j] * FREQUENCY[(j + characters.Length - i) % characters.Length];
					if (sum > maxSum)
					{
						maxSum = sum;
						index = i;
					}
				}
				newKey += characters[index];
			}

			key = newKey;
			return Decryption(text);
		}

		private bool InputValidationKey(string key)
		{
			foreach (char symbol in key)
			{
				if (!characters.Contains(symbol))
				{
					errors.WarningKey();
					return  true;
				}
			}

			return false;
		}

		private bool InputValidationPlaintext(ref string plaintext)
		{
			plaintext.ToUpper();
			plaintext = Regex.Replace(plaintext, @"[^А-ЯЁ]+", "");
			if (String.IsNullOrEmpty(plaintext))
			{
				errors.Empty();
				return true;
			}
			return false;
		}
	}
}