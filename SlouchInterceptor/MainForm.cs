namespace Mironworks.SlouchInterceptor
{
	using System;
	using System.ComponentModel;
	using System.Diagnostics;
	using System.Reflection;
	using System.Windows.Forms;
	using Microsoft.Win32;
	using Mironworks.SlouchInterceptor.Properties;

	public partial class MainForm : Form
	{
		private readonly IdleDetector idleDetector = new IdleDetector();
		private readonly Timer showOverlayTimer = new Timer();
		private ConfigurationForm configurationForm = new ConfigurationForm();
		private bool isTimerEnabled = true;
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

			showOverlayTimer.Tick += ShowOverlayTimerOnTick;
			overlayForm.FormClosed += OverlayFormOnFormClosed;
			idleDetector.IdleStart += OnIdleStart;
			idleDetector.IdleStop += OnIdleStop;
			SystemEvents.PowerModeChanged += OnPowerModeChanged;

			Settings.Default.BreakInterval = 1;
			Settings.Default.BreakDuration = 5;
			Settings.Default.IdleThreshold = 1;

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
			showOverlayTimer.Interval = Settings.Default.BreakInterval * 60 * 1000;
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
			if (!idleDetector.IsIdle && isTimerEnabled)
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

			if (!overlayForm.Visible && isTimerEnabled)
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

				if (isTimerEnabled)
					RestartShowOverlayTimer();
			}
		}

		private void TimerUpdateRemainingTextsTick(object sender, EventArgs e)
		{
			var t = new TimeSpan(0);

			if (showOverlayTimerTickTime > DateTime.Now)
				t = showOverlayTimerTickTime - DateTime.Now;

			string text = "Next break in 0:00:00";

			if (isTimerEnabled)
				text = string.Format("Next break in {0}:{1:D2}:{2:D2}", t.Hours, t.Minutes, t.Seconds);

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
			startStopBreakToolStripMenuItem.Text = overlayForm.Visible ? "Stop break" : "Start break";
			disableEnableTimerToolStripMenuItem.Text = isTimerEnabled ? "Disable timer" : "Enable timer";
			configureToolStripMenuItem.Enabled = disableEnableTimerToolStripMenuItem.Enabled = !overlayForm.Visible;
		}

		private void StartStopBreakToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (!overlayForm.Visible)
				ShowOverlayForm();
			else
				CloseOverlayForm();
		}

		private void DisableEnableTimerToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (isTimerEnabled)
			{
				StopShowOverlayTimer();
				isTimerEnabled = false;
			}
			else
			{
				RestartShowOverlayTimer();
				isTimerEnabled = true;
			}
		}

		private void ConfigureToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (configurationForm.IsDisposed)
				configurationForm = new ConfigurationForm();

			if (!configurationForm.Visible)
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
