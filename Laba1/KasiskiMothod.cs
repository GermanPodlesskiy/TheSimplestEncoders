using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using TheSimplestEncoders.Cipher;

namespace TheSimplestEncoders
{
    public partial class Form2 : Form
    {
        private readonly OpenFileDialog _openFile;
        private readonly SaveFileDialog _saveFile;
        private Error _error;
        private string _fileName;

        public Form2()
        {
            InitializeComponent();
            _openFile = InitializeOpenFile();
            _saveFile = InitializeSaveFile();
        }

        private OpenFileDialog InitializeOpenFile()
        {
            return new OpenFileDialog {Filter = "Text files|*.txt", AddExtension = true, Title = "Open text"};
        }

        private SaveFileDialog InitializeSaveFile()
        {
            return new SaveFileDialog
            {
                Filter = "Text files|*.txt",
                AddExtension = true,
                Title = "Save text"
            };
        }

        private void OutputTestKasiski(string str, int node, List<int> lengths)
        {
            ResultTextBox.Text += Environment.NewLine + str + "  (NODE = " + node + ')' + Environment.NewLine;
            ResultTextBox.Text += "   " + lengths[0];
            for (var i = 1; i < lengths.Count; i++)
            {
                ResultTextBox.Text += ", " + lengths[i];
            }
        }

        private void buttonTestKasiski_Click(object sender, EventArgs e)
        {
            var cipher = new VigenereCipher();
            cipher.TestKasiski(CipherTextBox.Text);
            cipher.DifKey = true;
            var keyLength = cipher.LengthKey;
            PlainTextBox.Text = cipher.FrequencyAnalysis(CipherTextBox.Text, keyLength);
            ResultTextBox.Text = "Key length: " + Convert.ToString(keyLength) + "  Key: " + cipher.Key +
                                 Environment.NewLine;

            var lgrams = cipher.Lgrams;
            foreach (var lgram in lgrams)
            {
                OutputTestKasiski(lgram.Digram, lgram.Gcd, lgram.Lengths);
            }
        }

        private void KeyTextBox_TextChanged(object sender, EventArgs e)
        {
            EncryptionButton.Enabled = (KeyTextBox.Text != string.Empty && PlainTextBox.Text != string.Empty);
            DecryptionButton.Enabled = KeyTextBox.Text != "" && CipherTextBox.Text != string.Empty;
        }

        private void EncryptionButton_Click(object sender, EventArgs e)
        {
            EncryptionVigenereCipher();
        }

        private void EncryptionVigenereCipher()
        {
            var cipher = new VigenereCipher {Key = KeyTextBox.Text, DifKey = true};
            if (!cipher.Error)
            {
                CipherTextBox.Text = cipher.Encryption(PlainTextBox.Text);
            }
        }

        private void DecryptionButton_Click(object sender, EventArgs e)
        {
            DecryptionViginereCipher();
        }

        private void DecryptionViginereCipher()
        {
            var cipher = new VigenereCipher {Key = KeyTextBox.Text, DifKey = true};
            if (!cipher.Error)
            {
                PlainTextBox.Text = cipher.Decryption(CipherTextBox.Text);
            }
        }

        private void PlainTextBox_TextChanged(object sender, EventArgs e)
        {
            EncryptionButton.Enabled = KeyTextBox.Text != string.Empty && PlainTextBox.Text != string.Empty;
        }

        private void CipherTextBox_TextChanged(object sender, EventArgs e)
        {
            DecryptionButton.Enabled = KeyTextBox.Text != string.Empty && CipherTextBox.Text != string.Empty;
            saveAsButton.Enabled = replacementButton.Enabled =
                buttonTestKasiski.Enabled = CipherTextBox.Text != string.Empty;
        }

        private void replacementButton_Click(object sender, EventArgs e)
        {
            PlainTextBox.Text = CipherTextBox.Text;
            CipherTextBox.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_openFile.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            try
            {
                var text = File.ReadAllText(_openFile.FileName, Encoding.Default);
                if (text != string.Empty)
                {
                    _fileName = _openFile.FileName;
                    PlainTextBox.Text = text;
                }
                else
                {
                    _error.EmptyFile();
                }
            }
            catch (IOException exc)
            {
                _error.OpenFile(exc.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_openFile.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            try
            {
                var text = File.ReadAllText(_openFile.FileName, Encoding.Default);
                if (text != string.Empty)
                {
                    _fileName = _openFile.FileName;
                    CipherTextBox.Text = text;
                }
                else
                {
                    _error.EmptyFile();
                }
            }
            catch (IOException exc)
            {
                _error.OpenFile(exc.Message);
            }
        }

        private void saveAsButton_Click(object sender, EventArgs e)
        {
            if (_saveFile.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            try
            {
                _fileName = _saveFile.FileName;
                File.WriteAllText(_fileName, CipherTextBox.Text, Encoding.Default);
                saveAsButton.Enabled = false;
            }
            catch (IOException exc)
            {
                _error.OpenFile(exc.Message);
            }
        }
    }
}