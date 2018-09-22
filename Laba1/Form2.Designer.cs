namespace Laba1
{
	partial class Form2
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
			this.button2 = new System.Windows.Forms.Button();
			this.replacementButton = new System.Windows.Forms.Button();
			this.saveAsButton = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.CipherTextBox = new System.Windows.Forms.TextBox();
			this.PlainTextBox = new System.Windows.Forms.TextBox();
			this.ResultTextBox = new System.Windows.Forms.TextBox();
			this.DecryptionButton = new System.Windows.Forms.Button();
			this.EncryptionButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.KeyTextBox = new System.Windows.Forms.TextBox();
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.buttonTestKasiski = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// button2
			// 
			this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.button2.Location = new System.Drawing.Point(344, 415);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(113, 29);
			this.button2.TabIndex = 20;
			this.button2.Text = "Open...";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// replacementButton
			// 
			this.replacementButton.Enabled = false;
			this.replacementButton.FlatAppearance.BorderSize = 0;
			this.replacementButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.replacementButton.Location = new System.Drawing.Point(299, 284);
			this.replacementButton.Name = "replacementButton";
			this.replacementButton.Size = new System.Drawing.Size(33, 23);
			this.replacementButton.TabIndex = 19;
			this.replacementButton.Text = "<=>";
			this.replacementButton.UseVisualStyleBackColor = true;
			this.replacementButton.Click += new System.EventHandler(this.replacementButton_Click);
			// 
			// saveAsButton
			// 
			this.saveAsButton.Enabled = false;
			this.saveAsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.saveAsButton.Location = new System.Drawing.Point(483, 415);
			this.saveAsButton.Name = "saveAsButton";
			this.saveAsButton.Size = new System.Drawing.Size(113, 29);
			this.saveAsButton.TabIndex = 18;
			this.saveAsButton.Text = "Save as...";
			this.saveAsButton.UseVisualStyleBackColor = true;
			this.saveAsButton.Click += new System.EventHandler(this.saveAsButton_Click);
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.button1.Location = new System.Drawing.Point(12, 415);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(113, 29);
			this.button1.TabIndex = 17;
			this.button1.Text = "Open...";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label3.Location = new System.Drawing.Point(448, 171);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(71, 17);
			this.label3.TabIndex = 16;
			this.label3.Text = "Ciphertext";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.Location = new System.Drawing.Point(115, 171);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(61, 17);
			this.label2.TabIndex = 15;
			this.label2.Text = "Plaintext";
			// 
			// CipherTextBox
			// 
			this.CipherTextBox.Location = new System.Drawing.Point(344, 191);
			this.CipherTextBox.Multiline = true;
			this.CipherTextBox.Name = "CipherTextBox";
			this.CipherTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.CipherTextBox.Size = new System.Drawing.Size(281, 215);
			this.CipherTextBox.TabIndex = 14;
			this.CipherTextBox.TextChanged += new System.EventHandler(this.CipherTextBox_TextChanged);
			// 
			// PlainTextBox
			// 
			this.PlainTextBox.Location = new System.Drawing.Point(12, 191);
			this.PlainTextBox.Multiline = true;
			this.PlainTextBox.Name = "PlainTextBox";
			this.PlainTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.PlainTextBox.Size = new System.Drawing.Size(281, 215);
			this.PlainTextBox.TabIndex = 13;
			this.PlainTextBox.TextChanged += new System.EventHandler(this.PlainTextBox_TextChanged);
			// 
			// ResultTextBox
			// 
			this.ResultTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.ResultTextBox.ForeColor = System.Drawing.Color.Black;
			this.ResultTextBox.Location = new System.Drawing.Point(686, 67);
			this.ResultTextBox.Multiline = true;
			this.ResultTextBox.Name = "ResultTextBox";
			this.ResultTextBox.ReadOnly = true;
			this.ResultTextBox.Size = new System.Drawing.Size(181, 355);
			this.ResultTextBox.TabIndex = 21;
			// 
			// DecryptionButton
			// 
			this.DecryptionButton.Enabled = false;
			this.DecryptionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.DecryptionButton.Location = new System.Drawing.Point(29, 127);
			this.DecryptionButton.Name = "DecryptionButton";
			this.DecryptionButton.Size = new System.Drawing.Size(100, 26);
			this.DecryptionButton.TabIndex = 25;
			this.DecryptionButton.Text = "Decryption";
			this.DecryptionButton.UseVisualStyleBackColor = true;
			this.DecryptionButton.Click += new System.EventHandler(this.DecryptionButton_Click);
			// 
			// EncryptionButton
			// 
			this.EncryptionButton.Enabled = false;
			this.EncryptionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.EncryptionButton.Location = new System.Drawing.Point(29, 87);
			this.EncryptionButton.Name = "EncryptionButton";
			this.EncryptionButton.Size = new System.Drawing.Size(100, 26);
			this.EncryptionButton.TabIndex = 24;
			this.EncryptionButton.Text = "Encryption";
			this.EncryptionButton.UseVisualStyleBackColor = true;
			this.EncryptionButton.Click += new System.EventHandler(this.EncryptionButton_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(26, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 16);
			this.label1.TabIndex = 23;
			this.label1.Text = "Key";
			// 
			// KeyTextBox
			// 
			this.KeyTextBox.Location = new System.Drawing.Point(29, 38);
			this.KeyTextBox.Multiline = true;
			this.KeyTextBox.Name = "KeyTextBox";
			this.KeyTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.KeyTextBox.Size = new System.Drawing.Size(147, 37);
			this.KeyTextBox.TabIndex = 22;
			this.KeyTextBox.TextChanged += new System.EventHandler(this.KeyTextBox_TextChanged);
			// 
			// buttonTestKasiski
			// 
			this.buttonTestKasiski.Enabled = false;
			this.buttonTestKasiski.Location = new System.Drawing.Point(397, 82);
			this.buttonTestKasiski.Name = "buttonTestKasiski";
			this.buttonTestKasiski.Size = new System.Drawing.Size(113, 31);
			this.buttonTestKasiski.TabIndex = 26;
			this.buttonTestKasiski.Text = "Run";
			this.buttonTestKasiski.UseVisualStyleBackColor = true;
			this.buttonTestKasiski.Click += new System.EventHandler(this.buttonTestKasiski_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label4.Location = new System.Drawing.Point(341, 58);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(214, 17);
			this.label4.TabIndex = 27;
			this.label4.Text = "Cachetty test and text decryption";
			// 
			// Form2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(893, 450);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.buttonTestKasiski);
			this.Controls.Add(this.DecryptionButton);
			this.Controls.Add(this.EncryptionButton);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.KeyTextBox);
			this.Controls.Add(this.ResultTextBox);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.replacementButton);
			this.Controls.Add(this.saveAsButton);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.CipherTextBox);
			this.Controls.Add(this.PlainTextBox);
			this.Name = "Form2";
			this.Text = "TestKasiski&Breaking";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button replacementButton;
		private System.Windows.Forms.Button saveAsButton;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox CipherTextBox;
		private System.Windows.Forms.TextBox PlainTextBox;
		private System.Windows.Forms.TextBox ResultTextBox;
		private System.Windows.Forms.Button DecryptionButton;
		private System.Windows.Forms.Button EncryptionButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox KeyTextBox;
		private System.ComponentModel.BackgroundWorker backgroundWorker1;
		private System.Windows.Forms.Button buttonTestKasiski;
		private System.Windows.Forms.Label label4;
	}
}