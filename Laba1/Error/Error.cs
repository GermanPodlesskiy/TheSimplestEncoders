using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba1.Error
{
	class Error
	{
		private string warningKey = "The key must consist of characters that correspond to the selected type of encryption / decryption.";
		private string errorOpenFile = "Error opening file.",
		errorEmptyFile = "The file is empty and does not contain any text for encryption / decryption.", 
		errorCaption = "Error!",
		errorValidationRotation = "The length of the text must be a multiple of 16.",
		errorEmpty = "The field does not contain the text for encryption / decryption.";

		public void WarningKey()
		{
			MessageBox.Show(warningKey, errorCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}

		public void OpenFile(string message)
		{
			MessageBox.Show(errorOpenFile + message, errorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
		public void EmptyFile()
		{
			MessageBox.Show(errorEmptyFile, errorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
		public void Empty()
		{
			MessageBox.Show(errorEmpty, errorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
		public void ValidationRotation()
		{
			MessageBox.Show(errorValidationRotation, errorCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}
	}
}
