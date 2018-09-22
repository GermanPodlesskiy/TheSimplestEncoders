using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Laba1.Cipher;

namespace Laba1
{
	public partial class Form2 : Form
	{
		private OpenFileDialog openFile;
		private SaveFileDialog saveFile;
		private Error.Error error;
		private string fileName = null;
		public Form2()
		{
			InitializeComponent();
			openFile = InitializeOpenFile();
			saveFile = InitializeSaveFile();
		}

		private OpenFileDialog InitializeOpenFile()
		{
			OpenFileDialog file = new OpenFileDialog();
			file.Filter = "Text files|*.txt";
			file.AddExtension = true;
			file.Title = "Open text";
			return file;
		}

		private SaveFileDialog InitializeSaveFile()
		{
			SaveFileDialog file = new SaveFileDialog();
			file.Filter = "Text files|*.txt";
			file.AddExtension = true;
			file.Title = "Save text";
			return file;
		}

		private void OutputTestKasiski(string str, int node, List<int> lengths)
		{
			ResultTextBox.Text += Environment.NewLine + str + "  (NODE = " + node + ')' + Environment.NewLine; 
			ResultTextBox.Text += "   " + lengths[0];
			for (int i = 1; i < lengths.Count; i++)
				ResultTextBox.Text += ", " + lengths[i];
		}

		private void buttonTestKasiski_Click(object sender, EventArgs e)
		{
			ViginereCipher cipher = new ViginereCipher();
			cipher.TestKasiski(CipherTextBox.Text);
			cipher.DifKey = true;
			int keyLength = cipher.LengthKey;
			PlainTextBox.Text = cipher.FrequencyAnalysis(CipherTextBox.Text, keyLength);
			ResultTextBox.Text = "Key length: " + Convert.ToString(keyLength) + "  Key: " +cipher.Key + Environment.NewLine;
			List<Lgram> lgrams = cipher.Lgrams;
			foreach (var lgram in lgrams)
				OutputTestKasiski(lgram.Digram, lgram.Gcd, lgram.Lengths);
		}

		private void KeyTextBox_TextChanged(object sender, EventArgs e)
		{
			EncryptionButton.Enabled = ((KeyTextBox.Text != "") && (PlainTextBox.Text != ""));
			DecryptionButton.Enabled = ((KeyTextBox.Text != "") && (CipherTextBox.Text != ""));

		}

		private void EncryptionButton_Click(object sender, EventArgs e)
		{
			EncryptionViginereCipher();
		}
		private void EncryptionViginereCipher()
		{
			ViginereCipher cipher = new ViginereCipher();
			cipher.Key = KeyTextBox.Text;
			cipher.DifKey = true;
			if (!cipher.Error)
				CipherTextBox.Text = cipher.Encryption(PlainTextBox.Text);
		}

		private void DecryptionButton_Click(object sender, EventArgs e)
		{
			DecryptionViginereCipher();
		}
		private void DecryptionViginereCipher()
		{
			ViginereCipher cipher = new ViginereCipher();
			cipher.Key = KeyTextBox.Text;
			cipher.DifKey = true;
			if (!cipher.Error)
				PlainTextBox.Text = cipher.Decryption(CipherTextBox.Text);
		}

		private void PlainTextBox_TextChanged(object sender, EventArgs e)
		{
			EncryptionButton.Enabled = ((KeyTextBox.Text != "") && (PlainTextBox.Text != ""));
		}

		private void CipherTextBox_TextChanged(object sender, EventArgs e)
		{
			DecryptionButton.Enabled = ((KeyTextBox.Text != "") && (CipherTextBox.Text != ""));
			saveAsButton.Enabled = replacementButton.Enabled = buttonTestKasiski.Enabled = (CipherTextBox.Text != "");
		}

		private void replacementButton_Click(object sender, EventArgs e)
		{
			PlainTextBox.Text = CipherTextBox.Text;
			CipherTextBox.Text = "";
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (openFile.ShowDialog(this) == DialogResult.OK)
				try
				{
					string text = File.ReadAllText(openFile.FileName, Encoding.Default);
					if (text != "")
					{
						fileName = openFile.FileName;
						PlainTextBox.Text = text;
					}
					else
						error.EmptyFile();
				}
				catch (IOException exc)
				{
					error.OpenFile(exc.Message);
				}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (openFile.ShowDialog(this) == DialogResult.OK)
				try
				{
					string text = File.ReadAllText(openFile.FileName, Encoding.Default);
					if (text != "")
					{
						fileName = openFile.FileName;
						CipherTextBox.Text = text;
					}
					else
						error.EmptyFile();
				}
				catch (IOException exc)
				{
					error.OpenFile(exc.Message);
				}
		}

		private void saveAsButton_Click(object sender, EventArgs e)
		{
			if (saveFile.ShowDialog(this) == DialogResult.OK)
				try
				{
					fileName = saveFile.FileName;
					File.WriteAllText(fileName, CipherTextBox.Text, Encoding.Default);
					saveAsButton.Enabled = false;
				}
				catch (IOException exc)
				{
					error.OpenFile(exc.Message);
				}
		}
	}
}
