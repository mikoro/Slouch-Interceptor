namespace Mironworks.SlouchInterceptor
{
	using System;
	using System.Drawing;
	using System.Windows.Forms;
	using Mironworks.SlouchInterceptor.Properties;

	public partial class OverlayForm : Form
	{
		private int secondsRemaining = Settings.Default.Duration;

		public OverlayForm()
		{
			InitializeComponent();

			int screenWidth = Screen.FromControl(this).Bounds.Width;
			int screenHeight = Screen.FromControl(this).Bounds.Height;
			int pictureVerticalLocation = screenHeight / 2 + pictureBox.Image.Height / 2 + 50;

			labelTimeRemaining.Size = new Size(screenWidth, 100);
			labelTimeRemaining.Location = new Point(0, pictureVerticalLocation);

			SetTimeRemainingText();
		}

		private void OverlayFormShown(object sender, EventArgs e)
		{
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
