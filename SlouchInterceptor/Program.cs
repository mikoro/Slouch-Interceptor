namespace Mironworks.SlouchInterceptor
{
	using System;
	using System.Windows.Forms;

	internal class Program
	{
		[STAThread]
		private static void Main()
		{
			new Program().Run();
		}

		public void Run()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			var mainForm = new MainForm { Visible = false };

			Application.Run();
		}
	}
}
