namespace Mironworks.SlouchInterceptor
{
	internal sealed partial class MainForm
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.remainingTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.startStopBreakToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.disableEnableTimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.configureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.timerUpdateRemainingTexts = new System.Windows.Forms.Timer(this.components);
			this.contextMenuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// notifyIcon
			// 
			this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
			this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
			this.notifyIcon.Text = "Slouch Interceptor";
			this.notifyIcon.Visible = true;
			this.notifyIcon.MouseUp += new System.Windows.Forms.MouseEventHandler(this.NotifyIconMouseUp);
			// 
			// contextMenuStrip
			// 
			this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.remainingTextToolStripMenuItem,
            this.toolStripSeparator1,
            this.startStopBreakToolStripMenuItem,
            this.disableEnableTimerToolStripMenuItem,
            this.configureToolStripMenuItem,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem});
			this.contextMenuStrip.Name = "contextMenuStrip";
			this.contextMenuStrip.Size = new System.Drawing.Size(183, 148);
			this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStripOpening);
			// 
			// remainingTextToolStripMenuItem
			// 
			this.remainingTextToolStripMenuItem.Enabled = false;
			this.remainingTextToolStripMenuItem.Name = "remainingTextToolStripMenuItem";
			this.remainingTextToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
			this.remainingTextToolStripMenuItem.Text = "Next break in 0:00:00";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(179, 6);
			// 
			// startStopBreakToolStripMenuItem
			// 
			this.startStopBreakToolStripMenuItem.Name = "startStopBreakToolStripMenuItem";
			this.startStopBreakToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
			this.startStopBreakToolStripMenuItem.Text = "StartStop break";
			this.startStopBreakToolStripMenuItem.Click += new System.EventHandler(this.StartStopBreakToolStripMenuItemClick);
			// 
			// disableEnableTimerToolStripMenuItem
			// 
			this.disableEnableTimerToolStripMenuItem.Name = "disableEnableTimerToolStripMenuItem";
			this.disableEnableTimerToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
			this.disableEnableTimerToolStripMenuItem.Text = "DisableEnable timer";
			this.disableEnableTimerToolStripMenuItem.Click += new System.EventHandler(this.DisableEnableTimerToolStripMenuItemClick);
			// 
			// configureToolStripMenuItem
			// 
			this.configureToolStripMenuItem.Name = "configureToolStripMenuItem";
			this.configureToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
			this.configureToolStripMenuItem.Text = "Configure";
			this.configureToolStripMenuItem.Click += new System.EventHandler(this.ConfigureToolStripMenuItemClick);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(179, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
			// 
			// timerUpdateRemainingTexts
			// 
			this.timerUpdateRemainingTexts.Enabled = true;
			this.timerUpdateRemainingTexts.Interval = 1000;
			this.timerUpdateRemainingTexts.Tick += new System.EventHandler(this.TimerUpdateRemainingTextsTick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(400, 400);
			this.ControlBox = false;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MainForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Slouch Interceptor";
			this.TopMost = true;
			this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
			this.VisibleChanged += new System.EventHandler(this.MainFormVisibleChanged);
			this.contextMenuStrip.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		public System.Windows.Forms.NotifyIcon notifyIcon;
		public System.Windows.Forms.ContextMenuStrip contextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem configureToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem remainingTextToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.Timer timerUpdateRemainingTexts;
		private System.Windows.Forms.ToolStripMenuItem startStopBreakToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem disableEnableTimerToolStripMenuItem;
	}
}