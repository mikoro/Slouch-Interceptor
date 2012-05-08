﻿namespace Mironworks.SlouchInterceptor
{
	using System;
	using System.ComponentModel;
	using System.Diagnostics;
	using System.IO;
	using System.Xml.Serialization;
	using log4net;

	internal sealed class Configuration
	{
		private static readonly string ConfigurationFilePath =
			Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
			             @"Mironworks\Slouch Interceptor\Configuration.xml");

		private static readonly ILog Log = LogManager.GetLogger(typeof(Configuration).Name);

		private double breakDuration;
		private double breakInterval;
		private double idleDetectionThreshold;

		private Configuration()
		{
			AutoLock = false;
			DisableClose = false;
			DisableSwitch = false;
			FirstRun = true;
			ShowImage = true;
			breakDuration = 3;
			breakInterval = 57;
			idleDetectionThreshold = 10;
			ImagePath = @"Images\SlouchInterceptor.png";
		}

		[Description("Whether the computer is locked after the break ends")]
		public bool AutoLock { get; set; }

		[Description("Makes the overlay windows ignore normal closing attempts")]
		public bool DisableClose { get; set; }

		[Description("Keeps the overlay window topmost all the time")]
		public bool DisableSwitch { get; set; }

		[Browsable(false)]
		public bool FirstRun { get; set; }

		[Description("The duration of the break in minutes")]
		[Category("Timings")]
		public double BreakDuration
		{
			get { return breakDuration; }

			set
			{
				if (value <= 0)
					value = 1;

				if (value > 99)
					value = 99;

				breakDuration = value;
			}
		}

		[Description("The time between the breaks in minutes")]
		[Category("Timings")]
		public double BreakInterval
		{
			get { return breakInterval; }

			set
			{
				if (value <= 0)
					value = 1;

				if (value > 9999)
					value = 9999;

				breakInterval = value;
			}
		}

		[Description("The idle time in minutes after which the break interval timer is reset")]
		[Category("Timings")]
		public double IdleDetectionThreshold
		{
			get { return idleDetectionThreshold; }

			set
			{
				if (value <= 0)
					value = 1;

				if (value > 99)
					value = 99;

				idleDetectionThreshold = value;
			}
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
