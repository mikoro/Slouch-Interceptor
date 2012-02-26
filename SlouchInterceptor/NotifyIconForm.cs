﻿namespace Mironworks.SlouchInterceptor
{
	using System;
	using System.ComponentModel;
	using System.Reflection;
	using System.Windows.Forms;

	public partial class NotifyIconForm : Form
	{
		private ConfigurationForm configurationForm;
		private OverlayForm overlayForm;

		public NotifyIconForm(OverlayForm overlayForm)
		{
			this.overlayForm = overlayForm;
			InitializeComponent();
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
			if (overlayForm == null || overlayForm.IsDisposed)
				overlayForm = new OverlayForm();

			if (!overlayForm.Visible)
				overlayForm.Show();
			else
				overlayForm.Close();
		}

		private void ConfigureToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (configurationForm == null || configurationForm.IsDisposed)
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
