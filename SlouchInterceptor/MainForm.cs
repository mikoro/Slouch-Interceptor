namespace Mironworks.SlouchInterceptor
{
	using System;
	using System.ComponentModel;
	using System.Reflection;
	using System.Windows.Forms;
	using Mironworks.SlouchInterceptor.Properties;
	using log4net;

	public partial class MainForm : Form
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof(MainForm).Name);
		private readonly Timer showOverlayTimer = new Timer();
		private ConfigurationForm configurationForm = new ConfigurationForm();
		private OverlayForm overlayForm = new OverlayForm();
		private DateTime showOverlayTimerTickTime = DateTime.Now;

		public MainForm()
		{
			Log.Debug("Starting");

			InitializeComponent();

			showOverlayTimer.Interval = (int)TimeSpan.FromMinutes(Settings.Default.OverlayShowInterval).TotalMilliseconds;
			showOverlayTimer.Tick += ShowOverlayTimerTick;

			StartShowOverlayTimer();

			if (Settings.Default.FirstRun)
			{
				notifyIcon.ShowBalloonTip(0, "Slouch Interceptor", "Slouch Interceptor is running", ToolTipIcon.None);
				Settings.Default.FirstRun = false;
				Settings.Default.Save();
			}

			overlayForm.FormClosed += OverlayFormOnFormClosed;
		}

		private void CheckOverlayForm()
		{
			if (overlayForm.IsDisposed)
			{
				overlayForm.FormClosed -= OverlayFormOnFormClosed;
				overlayForm = new OverlayForm();
				overlayForm.FormClosed += OverlayFormOnFormClosed;
			}
		}

		private void ShowOverlayForm()
		{
			Log.Info("Showing the overlay");

			overlayForm.Show();
			showOverlayTimer.Stop();
			showOverlayTimerTickTime = DateTime.Now;
		}

		private void StartShowOverlayTimer()
		{
			showOverlayTimer.Start();
			showOverlayTimerTickTime = DateTime.Now + TimeSpan.FromMilliseconds(showOverlayTimer.Interval);
		}

		private void ShowOverlayTimerTick(object sender, EventArgs e)
		{
			CheckOverlayForm();
			ShowOverlayForm();
		}

		private void TimerCheckIdleTick(object sender, EventArgs e)
		{
			if (LastInputInfo.GetLastInputTime() >= Settings.Default.IdleResetThreshold)
			{
				showOverlayTimer.Stop();
				StartShowOverlayTimer();
			}
		}

		private void OverlayFormOnFormClosed(object sender, FormClosedEventArgs e)
		{
			StartShowOverlayTimer();
		}

		private void NotifyIconMouseMove(object sender, MouseEventArgs e)
		{
			var t = new TimeSpan(0);

			if (showOverlayTimerTickTime >= DateTime.Now)
				t = showOverlayTimerTickTime - DateTime.Now;

			notifyIcon.Text = string.Format("Slouch Interceptor\nNext break in {0}:{1:D2}:{2:D2}", t.Hours, t.Minutes, t.Seconds);
		}

		private void NotifyIconMouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				MethodInfo mi = typeof(NotifyIcon).GetMethod("ShowContextMenu", BindingFlags.Instance | BindingFlags.NonPublic);
				mi.Invoke(notifyIcon, null);
			}
		}

		private void ContextMenuStripOpening(object sender, CancelEventArgs e)
		{
			startStopToolStripMenuItem.Text = overlayForm.Visible ? "Stop" : "Start";
		}

		private void StartStopToolStripMenuItemClick(object sender, EventArgs e)
		{
			CheckOverlayForm();

			if (!overlayForm.Visible)
				ShowOverlayForm();
			else
				overlayForm.Close();
		}

		private void ConfigureToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (configurationForm.IsDisposed)
				configurationForm = new ConfigurationForm();

			configurationForm.Show();
			configurationForm.WindowState = FormWindowState.Normal;
			configurationForm.Focus();
		}

		private void ExitToolStripMenuItemClick(object sender, EventArgs e)
		{
			Log.Debug("Closing");

			configurationForm.Close();
			overlayForm.Close();
			Close();

			Application.Exit();
		}
	}
}
