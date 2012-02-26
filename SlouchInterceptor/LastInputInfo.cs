namespace Mironworks.SlouchInterceptor
{
	using System;
	using System.Runtime.InteropServices;

	internal class LastInputInfo
	{
		[StructLayout(LayoutKind.Sequential)]
		private struct LastInputInfoStruct
		{
			private static readonly int SizeOf = Marshal.SizeOf(typeof(LastInputInfoStruct));

			[MarshalAs(UnmanagedType.U4)]
			public UInt32 cbSize;

			[MarshalAs(UnmanagedType.U4)]
			public UInt32 dwTime;
		}

		[DllImport("user32.dll")]
		private static extern bool GetLastInputInfo(ref LastInputInfoStruct plii);

		public static int GetLastInputTime()
		{
			var lastInputInfo = new LastInputInfoStruct();
			lastInputInfo.cbSize = (uint)Marshal.SizeOf(lastInputInfo);
			lastInputInfo.dwTime = 0;

			int idleTime = 0;

			if (GetLastInputInfo(ref lastInputInfo))
				idleTime = (int)(Environment.TickCount - lastInputInfo.dwTime);

			return ((idleTime > 0) ? (idleTime / 1000) : 0);
		}
	}
}
