namespace Laba1
{
	partial class Home
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton = new System.Windows.Forms.RadioButton();
			this.KeyTextBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.PlainTextBox = new System.Windows.Forms.TextBox();
			this.CipherTextBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.EncryptionButton = new System.Windows.Forms.Button();
			this.DecryptionButton = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.saveAsButton = new System.Windows.Forms.Button();
			this.replacementButton = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.RottingDataGridView = new System.Windows.Forms.DataGridView();
			this.TestKasiskiButton = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.RottingDataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.radioButton3);
			this.groupBox1.Controls.Add(this.radioButton2);
			this.groupBox1.Controls.Add(this.radioButton);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.groupBox1.Location = new System.Drawing.Point(12, 29);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(184, 159);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Encryption method";
			// 
			// radioButton3
			// 
			this.radioButton3.AutoSize = true;
			this.radioButton3.Location = new System.Drawing.Point(20, 121);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(121, 21);
			this.radioButton3.TabIndex = 2;
			this.radioButton3.Text = "Viginere cipher";
			this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
			// 
			// radioButton2
			// 
			this.radioButton2.AutoSize = true;
			this.radioButton2.Location = new System.Drawing.Point(20, 77);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(113, 21);
			this.radioButton2.TabIndex = 1;
			this.radioButton2.Text = "Rotating grille";
			this.radioButton2.UseVisualStyleBackColor = true;
			this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
			// 
			// radioButton
			// 
			this.radioButton.AutoSize = true;
			this.radioButton.Location = new System.Drawing.Point(20, 37);
			this.radioButton.Name = "radioButton";
			this.radioButton.Size = new System.Drawing.Size(113, 21);
			this.radioButton.TabIndex = 0;
			this.radioButton.Text = "Railway fence";
			this.radioButton.UseVisualStyleBackColor = true;
			this.radioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
			// 
			// KeyTextBox
			// 
			this.KeyTextBox.Location = new System.Drawing.Point(220, 50);
			this.KeyTextBox.Multiline = true;
			this.KeyTextBox.Name = "KeyTextBox";
			this.KeyTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.KeyTextBox.Size = new System.Drawing.Size(147, 37);
			this.KeyTextBox.TabIndex = 1;
			this.KeyTextBox.TextChanged += new System.EventHandler(this.KeyTextBox_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(217, 34);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "Key";
			// 
			// PlainTextBox
			// 
			this.PlainTextBox.Location = new System.Drawing.Point(32, 221);
			this.PlainTextBox.Multiline = true;
			this.PlainTextBox.Name = "PlainTextBox";
			this.PlainTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.PlainTextBox.Size = new System.Drawing.Size(281, 215);
			this.PlainTextBox.TabIndex = 3;
			this.PlainTextBox.TextChanged += new System.EventHandler(this.PlainTextBox_TextChanged);
			// 
			// CipherTextBox
			// 
			this.CipherTextBox.Location = new System.Drawing.Point(406, 221);
			this.CipherTextBox.Multiline = true;
			this.CipherTextBox.Name = "CipherTextBox";
			this.CipherTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.CipherTextBox.Size = new System.Drawing.Size(281, 215);
			this.CipherTextBox.TabIndex = 4;
			this.CipherTextBox.TextChanged += new System.EventHandler(this.CipherTextBox_TextChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.Location = new System.Drawing.Point(135, 201);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(61, 17);
			this.label2.TabIndex = 5;
			this.label2.Text = "Plaintext";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label3.Location = new System.Drawing.Point(510, 201);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(71, 17);
			this.label3.TabIndex = 6;
			this.label3.Text = "Ciphertext";
			// 
			// EncryptionButton
			// 
			this.EncryptionButton.Enabled = false;
			this.EncryptionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.EncryptionButton.Location = new System.Drawing.Point(220, 99);
			this.EncryptionButton.Name = "EncryptionButton";
			this.EncryptionButton.Size = new System.Drawing.Size(100, 26);
			this.EncryptionButton.TabIndex = 7;
			this.EncryptionButton.Text = "Encryption";
			this.EncryptionButton.UseVisualStyleBackColor = true;
			this.EncryptionButton.Click += new System.EventHandler(this.EncryptionButton_Click);
			// 
			// DecryptionButton
			// 
			this.DecryptionButton.Enabled = false;
			this.DecryptionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.DecryptionButton.Location = new System.Drawing.Point(220, 139);
			this.DecryptionButton.Name = "DecryptionButton";
			this.DecryptionButton.Size = new System.Drawing.Size(100, 26);
			this.DecryptionButton.TabIndex = 8;
			this.DecryptionButton.Text = "Decryption";
			this.DecryptionButton.UseVisualStyleBackColor = true;
			this.DecryptionButton.Click += new System.EventHandler(this.DecryptionButton_Click);
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.button1.Location = new System.Drawing.Point(32, 445);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(113, 29);
			this.button1.TabIndex = 9;
			this.button1.Text = "Open...";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// saveAsButton
			// 
			this.saveAsButton.Enabled = false;
			this.saveAsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.saveAsButton.Location = new System.Drawing.Point(545, 445);
			this.saveAsButton.Name = "saveAsButton";
			this.saveAsButton.Size = new System.Drawing.Size(113, 29);
			this.saveAsButton.TabIndex = 10;
			this.saveAsButton.Text = "Save as...";
			this.saveAsButton.UseVisualStyleBackColor = true;
			this.saveAsButton.Click += new System.EventHandler(this.saveAsButton_Click);
			// 
			// replacementButton
			// 
			this.replacementButton.Enabled = false;
			this.replacementButton.FlatAppearance.BorderSize = 0;
			this.replacementButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.replacementButton.Location = new System.Drawing.Point(319, 314);
			this.replacementButton.Name = "replacementButton";
			this.replacementButton.Size = new System.Drawing.Size(75, 23);
			this.replacementButton.TabIndex = 11;
			this.replacementButton.Text = "<=>";
			this.replacementButton.UseVisualStyleBackColor = true;
			this.replacementButton.Click += new System.EventHandler(this.replacement_Click);
			// 
			// button2
			// 
			this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.button2.Location = new System.Drawing.Point(406, 445);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(113, 29);
			this.button2.TabIndex = 12;
			this.button2.Text = "Open...";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// RottingDataGridView
			// 
			this.RottingDataGridView.BackgroundColor = System.Drawing.Color.White;
			this.RottingDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.RottingDataGridView.GridColor = System.Drawing.Color.Silver;
			this.RottingDataGridView.Location = new System.Drawing.Point(406, 50);
			this.RottingDataGridView.Name = "RottingDataGridView";
			this.RottingDataGridView.RowHeadersVisible = false;
			this.RottingDataGridView.RowHeadersWidth = 10;
			this.RottingDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.RottingDataGridView.Size = new System.Drawing.Size(84, 97);
			this.RottingDataGridView.TabIndex = 13;
			this.RottingDataGridView.Visible = false;
			this.RottingDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.RottingDataGridView_CellContentClick);
			// 
			// TestKasiskiButton
			// 
			this.TestKasiskiButton.Location = new System.Drawing.Point(513, 99);
			this.TestKasiskiButton.Name = "TestKasiskiButton";
			this.TestKasiskiButton.Size = new System.Drawing.Size(113, 48);
			this.TestKasiskiButton.TabIndex = 14;
			this.TestKasiskiButton.Text = "Test Kasiski and breaking";
			this.TestKasiskiButton.UseVisualStyleBackColor = true;
			this.TestKasiskiButton.Click += new System.EventHandler(this.TestKasiskiButton_Click);
			// 
			// Home
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(755, 483);
			this.Controls.Add(this.TestKasiskiButton);
			this.Controls.Add(this.RottingDataGridView);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.replacementButton);
			this.Controls.Add(this.saveAsButton);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.DecryptionButton);
			this.Controls.Add(this.EncryptionButton);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.CipherTextBox);
			this.Controls.Add(this.PlainTextBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.KeyTextBox);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "Home";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Load += new System.EventHandler(this.Home_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.RottingDataGridView)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton;
		private System.Windows.Forms.TextBox KeyTextBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox PlainTextBox;
		private System.Windows.Forms.TextBox CipherTextBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button EncryptionButton;
		private System.Windows.Forms.Button DecryptionButton;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button saveAsButton;
		private System.Windows.Forms.Button replacementButton;
		private System.Windows.Forms.Button button2;
		private System.ComponentModel.BackgroundWorker backgroundWorker1;
		private System.Windows.Forms.DataGridView RottingDataGridView;
		private System.Windows.Forms.Button TestKasiskiButton;
	}
}

