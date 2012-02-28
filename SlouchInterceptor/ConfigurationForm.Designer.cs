namespace Mironworks.SlouchInterceptor
{
	partial class ConfigurationForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigurationForm));
			this.numericUpDownBreakInterval = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownBreakDuration = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownIdleThreshold = new System.Windows.Forms.NumericUpDown();
			this.textBoxImagePath = new System.Windows.Forms.TextBox();
			this.groupBoxBreakInterval = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBoxBreakDuration = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBoxIdleThreshold = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBoxImagePath = new System.Windows.Forms.GroupBox();
			this.buttonBrowse = new System.Windows.Forms.Button();
			this.buttonClose = new System.Windows.Forms.Button();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.checkBoxShowImage = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownBreakInterval)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownBreakDuration)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownIdleThreshold)).BeginInit();
			this.groupBoxBreakInterval.SuspendLayout();
			this.groupBoxBreakDuration.SuspendLayout();
			this.groupBoxIdleThreshold.SuspendLayout();
			this.groupBoxImagePath.SuspendLayout();
			this.SuspendLayout();
			// 
			// numericUpDownBreakInterval
			// 
			this.numericUpDownBreakInterval.Location = new System.Drawing.Point(6, 19);
			this.numericUpDownBreakInterval.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
			this.numericUpDownBreakInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownBreakInterval.Name = "numericUpDownBreakInterval";
			this.numericUpDownBreakInterval.Size = new System.Drawing.Size(80, 20);
			this.numericUpDownBreakInterval.TabIndex = 0;
			this.numericUpDownBreakInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// numericUpDownBreakDuration
			// 
			this.numericUpDownBreakDuration.Location = new System.Drawing.Point(6, 19);
			this.numericUpDownBreakDuration.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
			this.numericUpDownBreakDuration.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownBreakDuration.Name = "numericUpDownBreakDuration";
			this.numericUpDownBreakDuration.Size = new System.Drawing.Size(80, 20);
			this.numericUpDownBreakDuration.TabIndex = 1;
			this.numericUpDownBreakDuration.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// numericUpDownIdleThreshold
			// 
			this.numericUpDownIdleThreshold.Location = new System.Drawing.Point(6, 19);
			this.numericUpDownIdleThreshold.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
			this.numericUpDownIdleThreshold.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownIdleThreshold.Name = "numericUpDownIdleThreshold";
			this.numericUpDownIdleThreshold.Size = new System.Drawing.Size(80, 20);
			this.numericUpDownIdleThreshold.TabIndex = 2;
			this.numericUpDownIdleThreshold.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// textBoxImagePath
			// 
			this.textBoxImagePath.Location = new System.Drawing.Point(6, 19);
			this.textBoxImagePath.Name = "textBoxImagePath";
			this.textBoxImagePath.Size = new System.Drawing.Size(267, 20);
			this.textBoxImagePath.TabIndex = 3;
			// 
			// groupBoxBreakInterval
			// 
			this.groupBoxBreakInterval.Controls.Add(this.label1);
			this.groupBoxBreakInterval.Controls.Add(this.numericUpDownBreakInterval);
			this.groupBoxBreakInterval.Location = new System.Drawing.Point(12, 12);
			this.groupBoxBreakInterval.Name = "groupBoxBreakInterval";
			this.groupBoxBreakInterval.Size = new System.Drawing.Size(360, 52);
			this.groupBoxBreakInterval.TabIndex = 4;
			this.groupBoxBreakInterval.TabStop = false;
			this.groupBoxBreakInterval.Text = "Break interval";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(92, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(43, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "minutes";
			// 
			// groupBoxBreakDuration
			// 
			this.groupBoxBreakDuration.Controls.Add(this.label2);
			this.groupBoxBreakDuration.Controls.Add(this.numericUpDownBreakDuration);
			this.groupBoxBreakDuration.Location = new System.Drawing.Point(12, 70);
			this.groupBoxBreakDuration.Name = "groupBoxBreakDuration";
			this.groupBoxBreakDuration.Size = new System.Drawing.Size(360, 52);
			this.groupBoxBreakDuration.TabIndex = 5;
			this.groupBoxBreakDuration.TabStop = false;
			this.groupBoxBreakDuration.Text = "Break duration";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(92, 21);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(47, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "seconds";
			// 
			// groupBoxIdleThreshold
			// 
			this.groupBoxIdleThreshold.Controls.Add(this.label3);
			this.groupBoxIdleThreshold.Controls.Add(this.numericUpDownIdleThreshold);
			this.groupBoxIdleThreshold.Location = new System.Drawing.Point(12, 128);
			this.groupBoxIdleThreshold.Name = "groupBoxIdleThreshold";
			this.groupBoxIdleThreshold.Size = new System.Drawing.Size(360, 52);
			this.groupBoxIdleThreshold.TabIndex = 5;
			this.groupBoxIdleThreshold.TabStop = false;
			this.groupBoxIdleThreshold.Text = "Idle threshold";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(92, 21);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(43, 13);
			this.label3.TabIndex = 3;
			this.label3.Text = "minutes";
			// 
			// groupBoxImagePath
			// 
			this.groupBoxImagePath.Controls.Add(this.checkBoxShowImage);
			this.groupBoxImagePath.Controls.Add(this.buttonBrowse);
			this.groupBoxImagePath.Controls.Add(this.textBoxImagePath);
			this.groupBoxImagePath.Location = new System.Drawing.Point(12, 186);
			this.groupBoxImagePath.Name = "groupBoxImagePath";
			this.groupBoxImagePath.Size = new System.Drawing.Size(360, 72);
			this.groupBoxImagePath.TabIndex = 5;
			this.groupBoxImagePath.TabStop = false;
			this.groupBoxImagePath.Text = "Image path";
			// 
			// buttonBrowse
			// 
			this.buttonBrowse.Location = new System.Drawing.Point(279, 17);
			this.buttonBrowse.Name = "buttonBrowse";
			this.buttonBrowse.Size = new System.Drawing.Size(75, 23);
			this.buttonBrowse.TabIndex = 4;
			this.buttonBrowse.Text = "Browse";
			this.buttonBrowse.UseVisualStyleBackColor = true;
			this.buttonBrowse.Click += new System.EventHandler(this.ButtonBrowseClick);
			// 
			// buttonClose
			// 
			this.buttonClose.Location = new System.Drawing.Point(297, 264);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new System.Drawing.Size(75, 23);
			this.buttonClose.TabIndex = 6;
			this.buttonClose.Text = "Close";
			this.buttonClose.UseVisualStyleBackColor = true;
			this.buttonClose.Click += new System.EventHandler(this.ButtonCloseClick);
			// 
			// openFileDialog
			// 
			this.openFileDialog.RestoreDirectory = true;
			// 
			// checkBoxShowImage
			// 
			this.checkBoxShowImage.AutoSize = true;
			this.checkBoxShowImage.Location = new System.Drawing.Point(6, 45);
			this.checkBoxShowImage.Name = "checkBoxShowImage";
			this.checkBoxShowImage.Size = new System.Drawing.Size(84, 17);
			this.checkBoxShowImage.TabIndex = 5;
			this.checkBoxShowImage.Text = "Show image";
			this.checkBoxShowImage.UseVisualStyleBackColor = true;
			// 
			// ConfigurationForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(386, 298);
			this.Controls.Add(this.buttonClose);
			this.Controls.Add(this.groupBoxImagePath);
			this.Controls.Add(this.groupBoxIdleThreshold);
			this.Controls.Add(this.groupBoxBreakDuration);
			this.Controls.Add(this.groupBoxBreakInterval);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "ConfigurationForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Slouch Interceptor configuration";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ConfigurationFormFormClosed);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownBreakInterval)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownBreakDuration)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownIdleThreshold)).EndInit();
			this.groupBoxBreakInterval.ResumeLayout(false);
			this.groupBoxBreakInterval.PerformLayout();
			this.groupBoxBreakDuration.ResumeLayout(false);
			this.groupBoxBreakDuration.PerformLayout();
			this.groupBoxIdleThreshold.ResumeLayout(false);
			this.groupBoxIdleThreshold.PerformLayout();
			this.groupBoxImagePath.ResumeLayout(false);
			this.groupBoxImagePath.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.NumericUpDown numericUpDownBreakInterval;
		private System.Windows.Forms.NumericUpDown numericUpDownBreakDuration;
		private System.Windows.Forms.NumericUpDown numericUpDownIdleThreshold;
		private System.Windows.Forms.TextBox textBoxImagePath;
		private System.Windows.Forms.GroupBox groupBoxBreakInterval;
		private System.Windows.Forms.GroupBox groupBoxBreakDuration;
		private System.Windows.Forms.GroupBox groupBoxIdleThreshold;
		private System.Windows.Forms.GroupBox groupBoxImagePath;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button buttonBrowse;
		private System.Windows.Forms.Button buttonClose;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.CheckBox checkBoxShowImage;
	}
}