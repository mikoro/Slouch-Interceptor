using System;
using System.Windows.Forms;

namespace Mironworks.SlouchInterceptor
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void NotifyIconClick(object sender, EventArgs e)
		{
			var mouseEvent = (MouseEventArgs) e;

			if (mouseEvent.Button == MouseButtons.Left)
				Visible = !Visible;
		}

		private void ExitToolStripMenuItemClick(object sender, EventArgs e)
		{
			Application.Exit();
		}
	}
}