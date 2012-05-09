namespace Mironworks.SlouchInterceptor
{
	using System;
	using System.ComponentModel;
	using System.Diagnostics;
	using System.IO;
	using System.Xml.Serialization;
	using log4net;

	public sealed class Configuration
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof(Configuration).Name);
		private static readonly string ConfigurationFilePath = Path.Combine(Program.DataRootDirectory, @"Configuration.xml");

		private double breakDuration;
		private double breakInterval;
		private double breakNotificationTime;
		private double idleDetectionThreshold;

		public Configuration()
		{
			AutoLock = false;
			DisableClose = false;
			DisableSwitch = false;
			EnableBreakNotification = true;
			FirstRun = true;
			ShowImage = true;
			BreakDuration = 3;
			BreakInterval = 57;
			IdleDetectionThreshold = 10;
			BreakNotificationTime = 0.25;
			ImagePath = @"Images\SlouchInterceptor.png";
		}

		[Description("Whether the computer is locked after the break ends")]
		public bool AutoLock { get; set; }

		[Description("Makes the overlay windows ignore normal closing attempts")]
		public bool DisableClose { get; set; }

		[Description("Keeps the overlay window topmost all the time")]
		public bool DisableSwitch { get; set; }

		[Description("Shows a balloon tip notification before the actual break begins")]
		public bool EnableBreakNotification { get; set; }

		[Browsable(false)]
		public bool FirstRun { get; set; }

		[Description("Duration of the break in minutes")]
		[Category("Timings")]
		public double BreakDuration
		{
			get { return breakDuration; }
			set { breakDuration = (value < 0) ? 0 : value; }
		}

		[Description("Time between the breaks in minutes")]
		[Category("Timings")]
		public double BreakInterval
		{
			get { return breakInterval; }
			set { breakInterval = (value < 0) ? 0 : value; }
		}

		[Description("Idle time in minutes after which the break interval timer is reset")]
		[Category("Timings")]
		public double IdleDetectionThreshold
		{
			get { return idleDetectionThreshold; }
			set { idleDetectionThreshold = (value < 0) ? 0 : value; }
		}

		[Description("Time in minutes when a notification should be shown before the actual break")]
		[Category("Timings")]
		public double BreakNotificationTime
		{
			get { return breakNotificationTime; }
			set { breakNotificationTime = (value < 0) ? 0 : value; }
		}

		[Description("Should an image be shown with the countdown")]
		[Category("Image")]
		public bool ShowImage { get; set; }

		[Description("A relative or an absolute path to the image")]
		[Category("Image")]
		public string ImagePath { get; set; }

		public static Configuration Load()
		{
			Trace.WriteLine("Loading configuration");

			var configuration = new Configuration();

			if (File.Exists(ConfigurationFilePath))
			{
				try
				{
					var xs = new XmlSerializer(typeof(Configuration));
					var sr = new StreamReader(ConfigurationFilePath);
					configuration = (Configuration)xs.Deserialize(sr);
					sr.Close();
				}
				catch (Exception ex)
				{
					Log.Error("Could not load the configuration", ex);
				}
			}

			return configuration;
		}

		public void Save()
		{
			Trace.WriteLine("Saving configuration");

			Directory.CreateDirectory(Program.DataRootDirectory);

			try
			{
				var xs = new XmlSerializer(typeof(Configuration));
				var sw = new StreamWriter(ConfigurationFilePath);
				xs.Serialize(sw, this);
				sw.Close();
			}
			catch (Exception ex)
			{
				Log.Error("Could not save the configuration", ex);
			}
		}
	}
}
