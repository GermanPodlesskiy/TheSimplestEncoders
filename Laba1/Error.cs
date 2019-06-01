using System.Windows.Forms;

namespace TheSimplestEncoders
{
    public class Error
    {
        private string _warningKey =
            "The key must consist of characters that correspond to the selected type of encryption / decryption.";

        private string _errorOpenFile = "Error opening file.",
            _errorEmptyFile = "The file is empty and does not contain any text for encryption / decryption.",
            _errorCaption = "Error!",
            _errorValidationRotation = "The length of the text must be a multiple of 16.",
            _errorEmpty = "The field does not contain the text for encryption / decryption.";

        public void WarningKey()
        {
            MessageBox.Show(_warningKey, _errorCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void OpenFile(string message)
        {
            MessageBox.Show(_errorOpenFile + message, _errorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void EmptyFile()
        {
            MessageBox.Show(_errorEmptyFile, _errorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void Empty()
        {
            MessageBox.Show(_errorEmpty, _errorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ValidationRotation()
        {
            MessageBox.Show(_errorValidationRotation, _errorCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}