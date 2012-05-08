namespace Mironworks.SlouchInterceptor
{
	using System;
	using System.Windows.Forms;

	public sealed partial class ConfigurationForm : Form
	{
		public ConfigurationForm()
		{
			InitializeComponent();

			propertyGridSettings.SelectedObject = MainForm.Configuration;
		}

		private void ButtonCloseClick(object sender, EventArgs e)
		{
			Close();
		}

		private void ConfigurationFormFormClosed(object sender, FormClosedEventArgs e)
		{
			MainForm.Configuration.Save();
		}
	}
}
