namespace Mironworks.SlouchInterceptor
{
	using System;
	using System.Windows.Forms;

	internal class Program
	{
		private OverlayForm overlayForm;
		private NotifyIconForm notifyIconForm;

		[STAThread]
		private static void Main()
		{
			new Program().Run();
		}

		public void Run()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			overlayForm = new OverlayForm();
			notifyIconForm = new NotifyIconForm(overlayForm);
			
			Application.Run();
		}
	}
}
