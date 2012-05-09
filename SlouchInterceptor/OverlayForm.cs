namespace Mironworks.SlouchInterceptor
{
	using System;
	using System.Drawing;
	using System.IO;
	using System.Windows.Forms;
	using log4net;

	internal sealed partial class OverlayForm : Form
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof(OverlayForm).Name);
		private int secondsRemaining;

		public OverlayForm()
		{
			InitializeComponent();
		}

		public bool CanClose { private get; set; }

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

			secondsRemaining = (int)(MainForm.Configuration.BreakDuration * 60.0);
			SetTimeRemainingText();

			if (MainForm.Configuration.DisableSwitch)
				timerForceFocus.Start();

			timerFadeIn.Start();
		}

		private void TimerForceFocusTick(object sender, EventArgs e)
		{
			TopMost = true;
			BringToFront();
			Focus();
			Activate();
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

		private void TimerFadeInTick(object sender, EventArgs e)
		{
			Opacity += 0.02;

			if (Opacity >= 0.9)
			{
				Opacity = 0.9;
				timerFadeIn.Stop();
				TimerCountdownTick(null, null);
				timerCountdown.Start();
			}
		}
	}
}
