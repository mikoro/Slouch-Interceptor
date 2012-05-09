namespace Mironworks.SlouchInterceptor
{
	using System;
	using System.IO;
	using System.Windows.Forms;
	using log4net;

	internal static class Program
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof(Program).Name);
		public static readonly string DataRootDirectory;

		static Program()
		{
#if DEBUG
			DataRootDirectory = Environment.CurrentDirectory;
#else
			DataRootDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
			                                 @"Mironworks\Slouch Interceptor");
#endif
		}

		[STAThread]
		private static void Main()
		{
			Log.Debug("Starting");

			AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
			Application.Run(new MainForm());

			Log.Debug("Stopping");
		}

		private static void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			Log.Fatal("AppDomain Unhandled Exception", (Exception)e.ExceptionObject);
		}
	}
}
