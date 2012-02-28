namespace Mironworks.SlouchInterceptor
{
	using System;
	using System.ComponentModel;
	using System.Diagnostics;
	using System.Reflection;
	using System.Windows.Forms;
	using Microsoft.Win32;
	using Mironworks.SlouchInterceptor.Properties;
	using log4net;

	public partial class MainForm : Form
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof(MainForm).Name);
		private readonly IdleDetector idleDetector = new IdleDetector();
		private readonly Timer showOverlayTimer = new Timer();
		private ConfigurationForm configurationForm = new ConfigurationForm();
		private OverlayForm overlayForm = new OverlayForm();
		private DateTime showOverlayTimerTickTime = DateTime.Now;

		public MainForm()
		{
			InitializeComponent();

			if (Settings.Default.FirstRun)
			{
				notifyIcon.ShowBalloonTip(0, "Slouch Interceptor", "Slouch Interceptor is running", ToolTipIcon.None);
				Settings.Default.FirstRun = false;
				Settings.Default.Save();
			}

			showOverlayTimer.Interval = Settings.Default.OverlayShowInterval * 1000;
			showOverlayTimer.Tick += ShowOverlayTimerOnTick;

			overlayForm.FormClosed += OverlayFormOnFormClosed;
			idleDetector.IdleStart += OnIdleStart;
			idleDetector.IdleStop += OnIdleStop;

			SystemEvents.PowerModeChanged += OnPowerModeChanged;

			RestartShowOverlayTimer();
		}

		private void ShowOverlayForm()
		{
			Trace.WriteLine("Show overlay form");

			StopShowOverlayTimer();
			showOverlayTimerTickTime = DateTime.Now;

			if (overlayForm.IsDisposed)
			{
				overlayForm.FormClosed -= OverlayFormOnFormClosed;
				overlayForm = new OverlayForm();
				overlayForm.FormClosed += OverlayFormOnFormClosed;
			}

			overlayForm.Show();
		}

		private void CloseOverlayForm()
		{
			Trace.WriteLine("Close overlay form");

			overlayForm.Close();
		}

		private void RestartShowOverlayTimer()
		{
			Trace.WriteLine("Restart show overlay timer");

			showOverlayTimer.Stop();
			showOverlayTimer.Start();
			showOverlayTimerTickTime = DateTime.Now + TimeSpan.FromMilliseconds(showOverlayTimer.Interval);
		}

		private void StopShowOverlayTimer()
		{
			Trace.WriteLine("Stop show overlay timer");

			showOverlayTimer.Stop();
		}

		private void ShowOverlayTimerOnTick(object sender, EventArgs e)
		{
			Trace.WriteLine("Show overlay timer tick");

			ShowOverlayForm();
		}

		private void OverlayFormOnFormClosed(object sender, FormClosedEventArgs e)
		{
			if (!idleDetector.IsIdle)
				RestartShowOverlayTimer();
		}

		private void OnIdleStart(object sender, EventArgs e)
		{
			Trace.WriteLine("Idle start");

			StopShowOverlayTimer();
		}

		private void OnIdleStop(object sender, EventArgs e)
		{
			Trace.WriteLine("Idle stop");

			if (!overlayForm.Visible)
				RestartShowOverlayTimer();
		}

		private void OnPowerModeChanged(object sender, PowerModeChangedEventArgs e)
		{
			if (e.Mode == PowerModes.Suspend)
			{
				Trace.WriteLine("Suspending");

				CloseOverlayForm();
			}
			else if (e.Mode == PowerModes.Resume)
			{
				Trace.WriteLine("Resuming");

				RestartShowOverlayTimer();
			}
		}

		private void TimerUpdateRemainingTextsTick(object sender, EventArgs e)
		{
			var t = new TimeSpan(0);

			if (showOverlayTimerTickTime > DateTime.Now)
				t = showOverlayTimerTickTime - DateTime.Now;

			string text = string.Format("Next break in {0}:{1:D2}:{2:D2}", t.Hours, t.Minutes, t.Seconds);

			notifyIcon.Text = "Slouch Interceptor\n" + text;
			remainingTextToolStripMenuItem.Text = text;
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
			showHideToolStripMenuItem.Text = overlayForm.Visible ? "Hide" : "Show";
			resetTimerToolStripMenuItem.Enabled = configureToolStripMenuItem.Enabled = !overlayForm.Visible;
		}

		private void ShowHideToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (!overlayForm.Visible)
				ShowOverlayForm();
			else
				CloseOverlayForm();
		}

		private void ResetTimerToolStripMenuItemClick(object sender, EventArgs e)
		{
			RestartShowOverlayTimer();
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
			Close();
			Application.Exit();
		}
	}
}
