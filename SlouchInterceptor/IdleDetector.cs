namespace Mironworks.SlouchInterceptor
{
	using System;
	using System.Runtime.InteropServices;
	using System.Windows.Forms;
	using Mironworks.SlouchInterceptor.Properties;

	internal class IdleDetector
	{
		private readonly Timer timer = new Timer();

		public IdleDetector()
		{
			timer.Interval = 1000;
			timer.Tick += TimerOnTick;
			timer.Start();
		}

		public bool IsIdle { get; private set; }

		public event EventHandler IdleStart;
		public event EventHandler IdleStop;

		private void TimerOnTick(object sender, EventArgs e)
		{
			if (GetLastInputTime() >= Settings.Default.IdleThreshold && !IsIdle)
			{
				IsIdle = true;

				if (IdleStart != null)
					IdleStart(this, null);
			}
			else if (IsIdle && GetLastInputTime() < Settings.Default.IdleThreshold)
			{
				IsIdle = false;

				if (IdleStop != null)
					IdleStop(this, null);
			}
		}

		[DllImport("user32.dll")]
		private static extern bool GetLastInputInfo(ref LastInputInfoStruct plii);

		private static int GetLastInputTime()
		{
			var lastInputInfo = new LastInputInfoStruct();
			lastInputInfo.cbSize = (uint)Marshal.SizeOf(lastInputInfo);
			lastInputInfo.dwTime = 0;

			int idleTime = 0;

			if (GetLastInputInfo(ref lastInputInfo))
				idleTime = (int)(Environment.TickCount - lastInputInfo.dwTime);

			return ((idleTime > 0) ? (idleTime / 1000) : 0);
		}

		[StructLayout(LayoutKind.Sequential)]
		private struct LastInputInfoStruct
		{
			private static readonly int SizeOf = Marshal.SizeOf(typeof(LastInputInfoStruct));

			[MarshalAs(UnmanagedType.U4)]
			public UInt32 cbSize;

			[MarshalAs(UnmanagedType.U4)]
			public UInt32 dwTime;
		}
	}
}
