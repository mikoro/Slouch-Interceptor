namespace Mironworks.SlouchInterceptor
{
	using System;
	using System.IO;
	using System.Threading;
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
			AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;

			using (var mutex = new Mutex(false, "Global\\{e82e1f56-3192-4bd1-9cfd-fa5e4dcb1354}"))
			{
				bool mutexAcquired = false;

				try
				{
					try
					{
						mutexAcquired = mutex.WaitOne(0, false);
					}
					catch (AbandonedMutexException)
					{
						mutexAcquired = true;
					}

					if (!mutexAcquired)
					{
						DialogResult result = MessageBox.Show(null,
						                                      "The program is already running. Do you want to run a new one anyway?",
						                                      "Slouch Interceptor",
						                                      MessageBoxButtons.YesNo,
						                                      MessageBoxIcon.Warning);

						if (result != DialogResult.Yes)
							return;
					}

					Application.EnableVisualStyles();
					Application.SetCompatibleTextRenderingDefault(false);
					Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
					Application.Run(new MainForm());
				}
				finally
				{
					if (mutexAcquired)
						mutex.ReleaseMutex();
				}
			}
		}

		private static void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			Log.Fatal("AppDomain Unhandled Exception", (Exception)e.ExceptionObject);
		}
	}
}
