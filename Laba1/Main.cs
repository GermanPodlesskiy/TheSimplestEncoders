using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TheSimplestEncoders.Cipher;

namespace TheSimplestEncoders
{
    public partial class Home : Form
    {
        private OpenFileDialog _openFile;
        private SaveFileDialog _saveFile;
        private string _tempText;
        private string _fileName;
        private const int CountCols = 4;
        private readonly bool[,] _checkedMatrix = new bool[CountCols, CountCols];
        private readonly int[,] _keyMatrix = new int[4, 4];
        private Error _error = new Error();

        public Home()
        {
            InitializeComponent();
            _openFile = InitializeOpenFile();
            _saveFile = InitializeSaveFile();
        }

        private OpenFileDialog InitializeOpenFile()
        {
            return new OpenFileDialog
            {
                Filter = "Text files|*.txt",
                AddExtension = true,
                Title = "Open text"
            };
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

        private void PlainTextBox_TextChanged(object sender, EventArgs e)
        {
            EncryptionButton.Enabled = KeyTextBox.Text != string.Empty && PlainTextBox.Text != string.Empty;

            if (!radioButton2.Checked || PlainTextBox.Text == "")
            {
                return;
            }

            var count = _keyMatrix.Cast<int>().Count(digital => digital == 1);
            EncryptionButton.Enabled = count == 4;
        }

        private void DecryptionButton_Click(object sender, EventArgs e)
        {
            switch (_tempText)
            {
                case "Railway fence":
                    DecryptionRailwayFencer();
                    break;
                case "Rotating grille":
                    DecryptionRotatingGrilleCipher();
                    break;
                case "Vigenere cipher":
                    DecryptionViginereCipher();
                    break;
            }
        }

        private void EncryptionButton_Click(object sender, EventArgs e)
        {
            switch (_tempText)
            {
                case "Railway fence":
                    EncryptionRailwayFence();
                    break;
                case "Rotating grille":
                    EncryptionRotatingGrilleCipher();
                    break;
                case "Vigenere cipher":
                    EncryptVigenereCipher();
                    break;
            }
        }


        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            var rdo = sender as RadioButton;
            DecryptionButton.Enabled = false;
            EncryptionButton.Enabled = false;
            EncryptionButton.Enabled = KeyTextBox.Text != "" && PlainTextBox.Text != "";
            DecryptionButton.Enabled = KeyTextBox.Text != "" && CipherTextBox.Text != "";
            if (rdo?.Text == "Rotating grille")
            {
                KeyTextBox.Enabled = false;
                RottingDataGridView.Rows.Clear();
                RottingDataGridView.Visible = true;
                for (var i = 0; i < 4; i++)
                {
                    var btn = new DataGridViewButtonColumn {Width = 20};
                    RottingDataGridView.Columns.Add(btn);
                    btn.UseColumnTextForButtonValue = true;
                    if (i == 3)
                    {
                        continue;
                    }

                    var bdr = new DataGridViewRow();
                    RottingDataGridView.Rows.Add(bdr);
                }
            }
            else
            {
                KeyTextBox.Enabled = true;
                RottingDataGridView.Visible = false;
                for (var i = 0; i < CountCols; i++)
                for (var j = 0; j < CountCols; j++)
                {
                    _checkedMatrix[i, j] = false;
                    _keyMatrix[i, j] = 0;
                }
            }


            _tempText = rdo?.Text;
        }

        private void Replacement_Click(object sender, EventArgs e)
        {
            PlainTextBox.Text = CipherTextBox.Text;
            CipherTextBox.Text = string.Empty;
        }

        private void CipherTextBox_TextChanged(object sender, EventArgs e)
        {
            DecryptionButton.Enabled = KeyTextBox.Text != string.Empty && CipherTextBox.Text != string.Empty;
            saveAsButton.Enabled = replacementButton.Enabled = CipherTextBox.Text != string.Empty;
            if (!radioButton2.Checked || CipherTextBox.Text == string.Empty)
            {
                return;
            }

            var count = _keyMatrix.Cast<int>().Count(digital => digital == 1);
            DecryptionButton.Enabled = count == 4;
        }

        private void EncryptionRailwayFence()
        {
            var cipher = new RailwayFenceCipher {Key = KeyTextBox.Text};
            if (!cipher.Error)
            {
                CipherTextBox.Text = cipher.Encryption(PlainTextBox.Text);
            }
        }

        private void DecryptionRailwayFencer()
        {
            var cipher = new RailwayFenceCipher {Key = KeyTextBox.Text};
            if (!cipher.Error)
            {
                PlainTextBox.Text = cipher.Decryption(CipherTextBox.Text);
            }
        }

        private void SaveAsButton_Click(object sender, EventArgs e)
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

        private void EncryptionRotatingGrilleCipher()
        {
            var cipher = new RotatingGrilleCipher {KeyMatrix = _keyMatrix};
            CipherTextBox.Text = cipher.Encryption(PlainTextBox.Text);
        }

        private void DecryptionRotatingGrilleCipher()
        {
            var cipher = new RotatingGrilleCipher {KeyMatrix = _keyMatrix};
            PlainTextBox.Text = cipher.Decryption(CipherTextBox.Text);
        }

        private void EncryptVigenereCipher()
        {
            var cipher = new VigenereCipher {Key = KeyTextBox.Text, DifKey = false};
            if (!cipher.Error)
            {
                CipherTextBox.Text = cipher.Encryption(PlainTextBox.Text);
            }
        }


        private void Button2_Click(object sender, EventArgs e)
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

        private void RottingDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            for (var i = 0; i < CountCols; i++)
            {
                for (var j = 0; j < CountCols; j++)
                    if (RottingDataGridView.Rows[i].Cells[j].Selected)
                    {
                        Enable(i, j);
                    }
            }

            if (PlainTextBox.Text == string.Empty)
            {
                return;
            }

            var count = _keyMatrix.Cast<int>().Count(digital => digital == 1);
            EncryptionButton.Enabled = count == 4;
        }

        private void Enable(int i, int j)
        {
            if (_checkedMatrix[i, j] != false)
            {
                return;
            }

            _keyMatrix[i, j] = 1;
            _checkedMatrix[i, j] = true;
            RottingDataGridView.Rows[i].Cells[j].Style.BackColor = System.Drawing.Color.Blue;

            // поворот решетки на 90 градусов по часовой стрелке
            _checkedMatrix[CountCols - j - 1, i] = true;
            RottingDataGridView.Rows[CountCols - j - 1].Cells[i].Style.BackColor = System.Drawing.Color.Red;
            _keyMatrix[CountCols - j - 1, i] = 0;

            // поворот решетки на 180 градусов по часовой стрелке
            _checkedMatrix[CountCols - i - 1, CountCols - j - 1] = true;
            RottingDataGridView.Rows[CountCols - i - 1].Cells[CountCols - j - 1].Style.BackColor =
                System.Drawing.Color.Red;
            _keyMatrix[CountCols - i - 1, CountCols - j - 1] = 0;

            // поворот решетки на 270 градусов по часовой стрелке
            _checkedMatrix[j, CountCols - i - 1] = true;
            RottingDataGridView.Rows[j].Cells[CountCols - 1 - i].Style.BackColor = System.Drawing.Color.Red;
            _keyMatrix[j, CountCols - i - 1] = 0;
        }

        private void KeyTextBox_TextChanged(object sender, EventArgs e)
        {
            EncryptionButton.Enabled = ((KeyTextBox.Text != "") && (PlainTextBox.Text != ""));
            DecryptionButton.Enabled = ((KeyTextBox.Text != "") && (CipherTextBox.Text != ""));
        }

        private void DecryptionViginereCipher()
        {
            var cipher = new VigenereCipher {Key = KeyTextBox.Text, DifKey = false};
            if (!cipher.Error)
            {
                PlainTextBox.Text = cipher.Decryption(CipherTextBox.Text);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
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

        private void TestKasiskiButton_Click(object sender, EventArgs e)
        {
            var frm2 = new Form2();
            frm2.Show();
        }
    }
}