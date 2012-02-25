namespace Mironworks.SlouchInterceptor
{
	using System;
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

		private void StartToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (overlayForm == null || overlayForm.IsDisposed)
				overlayForm = new OverlayForm();

			overlayForm.Show();
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
