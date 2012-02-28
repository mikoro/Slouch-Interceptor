namespace Mironworks.SlouchInterceptor
{
	using System;
	using System.Windows.Forms;
	using Mironworks.SlouchInterceptor.Properties;

	public partial class ConfigurationForm : Form
	{
		public ConfigurationForm()
		{
			InitializeComponent();

			numericUpDownBreakInterval.DataBindings.Add("Value", Settings.Default, "BreakInterval");
			numericUpDownBreakDuration.DataBindings.Add("Value", Settings.Default, "BreakDuration");
			numericUpDownIdleThreshold.DataBindings.Add("Value", Settings.Default, "IdleThreshold");
			textBoxImagePath.DataBindings.Add("Text", Settings.Default, "ImagePath");
			checkBoxShowImage.DataBindings.Add("Checked", Settings.Default, "ShowImage");
		}

		private void ButtonBrowseClick(object sender, EventArgs e)
		{
			if (openFileDialog.ShowDialog(this) == DialogResult.OK)
				Settings.Default.ImagePath = openFileDialog.FileName;
		}

		private void ButtonCloseClick(object sender, EventArgs e)
		{
			Close();
		}

		private void ConfigurationFormFormClosed(object sender, FormClosedEventArgs e)
		{
			Settings.Default.Save();
		}
	}
}
