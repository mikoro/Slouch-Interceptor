namespace Mironworks.SlouchInterceptor
{
	using System;
	using System.Drawing;
	using System.IO;
	using System.Windows.Forms;
	using log4net;

	public partial class OverlayForm : Form
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof(OverlayForm).Name);
		private int secondsRemaining;

		public OverlayForm()
		{
			InitializeComponent();
		}

		public bool CanClose { get; set; }

		private void OverlayFormLoad(object sender, EventArgs e)
		{
			labelTimeRemaining.Size = new Size(Screen.FromControl(this).Bounds.Width, 100);
			int labelVerticalLocation = (Screen.FromControl(this).Bounds.Height / 2) - (labelTimeRemaining.Size.Height / 2);

			if (MainForm.Configuration.ShowImage)
			{
				try
				{
					pictureBox.Load(MainForm.Configuration.ImagePath);
					labelVerticalLocation += (pictureBox.Image.Height / 2) + labelTimeRemaining.Size.Height;
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

			secondsRemaining = MainForm.Configuration.BreakDuration * 60;
			SetTimeRemainingText();

			timerCountdown.Enabled = true;
		}

		private void TimerCountdownTick(object sender, EventArgs e)
		{
			if (--secondsRemaining <= -1)
			{
				CanClose = true;
				Close();
			}

			SetTimeRemainingText();
		}

		private void SetTimeRemainingText()
		{
			TimeSpan t = TimeSpan.FromSeconds(secondsRemaining);
			string timeText = string.Format("{0:D2}:{1:D2}", (int)t.TotalMinutes, t.Seconds);
			labelTimeRemaining.Text = timeText;
		}

		private void OverlayFormFormClosing(object sender, FormClosingEventArgs e)
		{
			if (MainForm.Configuration.DisableClose && !CanClose)
				e.Cancel = true;
		}
	}
}
