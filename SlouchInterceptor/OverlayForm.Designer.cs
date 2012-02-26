namespace Mironworks.SlouchInterceptor
{
	partial class OverlayForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OverlayForm));
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.timerCountdown = new System.Windows.Forms.Timer(this.components);
			this.labelTimeRemaining = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox
			// 
			this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureBox.ErrorImage = null;
			this.pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox.Image")));
			this.pictureBox.InitialImage = null;
			this.pictureBox.Location = new System.Drawing.Point(0, 0);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(800, 800);
			this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.pictureBox.TabIndex = 0;
			this.pictureBox.TabStop = false;
			// 
			// timerCountdown
			// 
			this.timerCountdown.Interval = 1000;
			this.timerCountdown.Tick += new System.EventHandler(this.TimerCountdownTick);
			// 
			// labelTimeRemaining
			// 
			this.labelTimeRemaining.Font = new System.Drawing.Font("Verdana", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelTimeRemaining.ForeColor = System.Drawing.Color.LightGray;
			this.labelTimeRemaining.Location = new System.Drawing.Point(0, 0);
			this.labelTimeRemaining.Margin = new System.Windows.Forms.Padding(0);
			this.labelTimeRemaining.Name = "labelTimeRemaining";
			this.labelTimeRemaining.Size = new System.Drawing.Size(243, 78);
			this.labelTimeRemaining.TabIndex = 1;
			this.labelTimeRemaining.Text = "00:00";
			this.labelTimeRemaining.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// OverlayForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(800, 800);
			this.ControlBox = false;
			this.Controls.Add(this.labelTimeRemaining);
			this.Controls.Add(this.pictureBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "OverlayForm";
			this.Opacity = 0.95D;
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Slouch Interceptor";
			this.TopMost = true;
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Shown += new System.EventHandler(this.OverlayFormShown);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.Timer timerCountdown;
		private System.Windows.Forms.Label labelTimeRemaining;
	}
}

