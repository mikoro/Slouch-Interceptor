﻿namespace Mironworks.SlouchInterceptor
{
	using System;
	using System.Windows.Forms;
	using Mironworks.SlouchInterceptor.Properties;
	using log4net;
	using log4net.Config;

	internal class Program
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof(Program).Name);

		[STAThread]
		private static void Main()
		{
			new Program().Run();
		}

		public void Run()
		{
			XmlConfigurator.Configure();

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
			AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;

			var mainForm = new MainForm { Visible = false };

			Log.Debug("Starting");

			Application.Run();

			Log.Debug("Stopping");

			Settings.Default.Save();
		}

		private static void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			Log.Fatal("AppDomain Unhandled Exception", (Exception)e.ExceptionObject);
		}
	}
}
