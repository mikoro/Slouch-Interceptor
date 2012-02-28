namespace Mironworks.SlouchInterceptor
{
	using System;
	using System.Drawing;
	using System.IO;
	using System.Windows.Forms;
	using Mironworks.SlouchInterceptor.Properties;
	using log4net;

	public partial class OverlayForm : Form
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof(OverlayForm).Name);
		private int secondsRemaining = Settings.Default.BreakDuration;

		public OverlayForm()
		{
			InitializeComponent();
		}

		private void OverlayFormLoad(object sender, EventArgs e)
		{
			int labelVerticalLocation = Screen.FromControl(this).Bounds.Height / 2;
			labelTimeRemaining.Size = new Size(Screen.FromControl(this).Bounds.Width, 100);

			if (Settings.Default.ShowImage)
			{
				try
				{
					pictureBox.Load(Settings.Default.ImagePath);
					labelVerticalLocation += pictureBox.Image.Height / 2 + labelTimeRemaining.Size.Height / 2;
				}
				catch (Exception ex)
				{
					if (ex is InvalidOperationException || ex is ArgumentException || ex is FileNotFoundException)
						Log.Warn("Could not load the image", ex);
					else
						throw;
				}
			}

			labelTimeRemaining.Location = new Point(0, labelVerticalLocation);

			SetTimeRemainingText();

			timerCountdown.Enabled = true;
		}

		private void TimerCountdownTick(object sender, EventArgs e)
		{
			if (--secondsRemaining <= -1)
				Close();

			SetTimeRemainingText();
		}

		private void SetTimeRemainingText()
		{
			TimeSpan t = TimeSpan.FromSeconds(secondsRemaining);
			string timeText = string.Format("{0:D2}:{1:D2}", t.Minutes, t.Seconds);
			labelTimeRemaining.Text = timeText;
		}
	}
}
