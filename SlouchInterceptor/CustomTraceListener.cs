namespace Mironworks.SlouchInterceptor
{
	using System.Diagnostics;
	using log4net;

	public class CustomTraceListener : TraceListener
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof(CustomTraceListener).Name);

		public override void Write(string message)
		{
			Log.Debug(message);
		}

		public override void WriteLine(string message)
		{
			Log.Debug(message);
		}
	}
}
