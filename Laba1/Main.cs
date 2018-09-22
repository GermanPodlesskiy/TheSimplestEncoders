using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Laba1.Cipher;

namespace Laba1
{
	public partial class Home : Form
	{
		OpenFileDialog openFile;
		SaveFileDialog saveFile;
		string tempText;
		string fileName = null;
		static int COUNT_COLS = 4;
		bool[,] checkedMatr = new bool[COUNT_COLS, COUNT_COLS];
		int[,] keyMatr = new int[4, 4];
		Error.Error error = new Error.Error();
		public Home()
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

		private void Home_Load(object sender, EventArgs e)
		{

		}

		private void PlainTextBox_TextChanged(object sender, EventArgs e)
		{
			EncryptionButton.Enabled = ((KeyTextBox.Text != "") && (PlainTextBox.Text != ""));

			if (radioButton2.Checked && (PlainTextBox.Text != ""))
			{
				int count = 0;
				foreach (int digital in keyMatr)
					if (digital == 1)
						count++;
				if (count == 4)
					EncryptionButton.Enabled = true;
				else
					EncryptionButton.Enabled = false;
			}
		}

		private void DecryptionButton_Click(object sender, EventArgs e)
		{
			switch (tempText)
			{
				case "Railway fence":
					DecryptionRailwayFencer();
					break;
				case "Rotating grille":
					DecryptionRotatingGrilleCipher();
					break;
				case "Viginere cipher":
					DecryptionViginereCipher();
					break;
			}
		}

		private void EncryptionButton_Click(object sender, EventArgs e)
		{
			switch (tempText)
			{
				case "Railway fence":
					EncryptionRailwayFence();
					break;
				case "Rotating grille":
					EncryptionRotatingGrilleCipher();
					break;
				case "Viginere cipher":
					EncryptionViginereCipher();
					break;
			}
		}


		private void radioButton_CheckedChanged(object sender, EventArgs e)
		{
			RadioButton radioButton = sender as RadioButton;
			DecryptionButton.Enabled = false;
			EncryptionButton.Enabled = false;
			EncryptionButton.Enabled = ((KeyTextBox.Text != "") && (PlainTextBox.Text != ""));
			DecryptionButton.Enabled = ((KeyTextBox.Text != "") && (CipherTextBox.Text != ""));
			if (radioButton.Text == "Rotating grille")
			{
				KeyTextBox.Enabled = false;
				RottingDataGridView.Rows.Clear();
				RottingDataGridView.Visible = true;
				int count = 0;
				for (int i = 0; i < 4; i++)
				{
					DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
					btn.Width = 20;
					RottingDataGridView.Columns.Add(btn);
					btn.UseColumnTextForButtonValue = true;
					if (i != 3)
					{
						DataGridViewRow bdr = new DataGridViewRow();
						RottingDataGridView.Rows.Add(bdr);
					}
				}
			}
			else
			{
				KeyTextBox.Enabled = true;
				RottingDataGridView.Visible = false;
				for (int i = 0; i < COUNT_COLS; i++)
				for (int j = 0; j < COUNT_COLS; j++)
				{
					checkedMatr[i, j] = false;
					keyMatr[i, j] = 0;
				}
					
			}
				
			
			tempText = radioButton.Text;
		}

		private void replacement_Click(object sender, EventArgs e)
		{
			PlainTextBox.Text = CipherTextBox.Text;
			CipherTextBox.Text = "";
		}

		private void CipherTextBox_TextChanged(object sender, EventArgs e)
		{
			DecryptionButton.Enabled = ((KeyTextBox.Text != "") && (CipherTextBox.Text != ""));
			saveAsButton.Enabled = replacementButton.Enabled = (CipherTextBox.Text != "");
			if (radioButton2.Checked && (CipherTextBox.Text != ""))
			{
				int count = 0;
				foreach (int digital in keyMatr)
					if (digital == 1)
						count++;
				if (count == 4)
					DecryptionButton.Enabled = true;
				else
					DecryptionButton.Enabled = false;
			}
		}

		private void EncryptionRailwayFence()
		{
			RailwayFenceCipher cipher = new RailwayFenceCipher();
			cipher.Key = KeyTextBox.Text;
			if (!cipher.Error)
				CipherTextBox.Text = cipher.Encryption(PlainTextBox.Text);
		}

		private void DecryptionRailwayFencer()
		{
			RailwayFenceCipher cipher = new RailwayFenceCipher();
			cipher.Key = KeyTextBox.Text;
			if (!cipher.Error)
				PlainTextBox.Text = cipher.Decryption(CipherTextBox.Text);
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

		private void EncryptionRotatingGrilleCipher()
		{
			RotatingGrilleCipher cipher = new RotatingGrilleCipher();
			cipher.KeyMatr = keyMatr;
			CipherTextBox.Text = cipher.Encryption(PlainTextBox.Text);
		}
		private void DecryptionRotatingGrilleCipher()
		{
			RotatingGrilleCipher cipher = new RotatingGrilleCipher();
			cipher.KeyMatr = keyMatr;
			PlainTextBox.Text = cipher.Decryption(CipherTextBox.Text);
		}
		private void EncryptionViginereCipher()
		{
			ViginereCipher cipher = new ViginereCipher();
			cipher.Key = KeyTextBox.Text;
			cipher.DifKey = false;
			if (!cipher.Error)
				CipherTextBox.Text = cipher.Encryption(PlainTextBox.Text);
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

		private void RottingDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			for (int i = 0; i < COUNT_COLS; i++)
			{
				for (int j = 0; j < COUNT_COLS; j++)
					if (RottingDataGridView.Rows[i].Cells[j].Selected)
					{
						Enabled(i, j);
					}
			}
			if (PlainTextBox.Text != "")
			{
				int count = 0;
				foreach (int digital in keyMatr)
					if (digital == 1)
						count++;
				if (count == 4)
					EncryptionButton.Enabled = true;
				else
					EncryptionButton.Enabled = false;
			}
		}
		
		private void Enabled(int i, int j)
		{
			if (checkedMatr[i, j] == false)
			{
				keyMatr[i, j] = 1;
				checkedMatr[i, j] = true;
				RottingDataGridView.Rows[i].Cells[j].Style.BackColor = System.Drawing.Color.Blue;

				// поворот решетки на 90 градусов по часовой стрелке
				checkedMatr[COUNT_COLS - j - 1, i] = true;
				RottingDataGridView.Rows[COUNT_COLS - j - 1].Cells[i].Style.BackColor = System.Drawing.Color.Red;
				keyMatr[COUNT_COLS - j - 1, i] = 0;

				// поворот решетки на 180 градусов по часовой стрелке
				checkedMatr[COUNT_COLS - i - 1, COUNT_COLS - j - 1] = true;
				RottingDataGridView.Rows[COUNT_COLS - i - 1].Cells[COUNT_COLS - j - 1].Style.BackColor = System.Drawing.Color.Red;
				keyMatr[COUNT_COLS - i - 1, COUNT_COLS - j - 1] = 0;

				// поворот решетки на 270 градусов по часовой стрелке
				checkedMatr[j, COUNT_COLS - i - 1] = true;
				RottingDataGridView.Rows[j].Cells[COUNT_COLS - 1 - i].Style.BackColor = System.Drawing.Color.Red;
				keyMatr[j, COUNT_COLS - i - 1] = 0;
			}
		}

		private void KeyTextBox_TextChanged(object sender, EventArgs e)
		{
			EncryptionButton.Enabled = ((KeyTextBox.Text != "") && (PlainTextBox.Text != ""));
			DecryptionButton.Enabled = ((KeyTextBox.Text != "") && (CipherTextBox.Text != ""));
		}

		private void DecryptionViginereCipher()
		{
			ViginereCipher cipher = new ViginereCipher();
			cipher.Key = KeyTextBox.Text;
			cipher.DifKey = false;
			if (!cipher.Error)
				PlainTextBox.Text = cipher.Decryption(CipherTextBox.Text);
		}

		private void button1_Click(object sender, EventArgs e)
		{ 
			if (openFile.ShowDialog(this) == DialogResult.OK)
				try
				{
					string text = File.ReadAllText(openFile.FileName,Encoding.Default);
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

		private void TestKasiskiButton_Click(object sender, EventArgs e)
		{
			Form frm2 = new Form2();
			frm2.Show();
		}
	}
}