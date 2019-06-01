using System;
using System.Windows.Forms;

namespace TheSimplestEncoders
{
	static class TheSimplestEncoders
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Home());
		}
	}
}
