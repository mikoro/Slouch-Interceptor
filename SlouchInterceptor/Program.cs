using System;
using System.Windows.Forms;

namespace Mironworks.SlouchInterceptor
{
	internal static class Program
	{
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			var mainForm = new MainForm { Visible = false };

			Application.Run();
		}
	}
}