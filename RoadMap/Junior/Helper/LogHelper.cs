using System;
using System.Diagnostics;
using System.Net.Http;
using Serilog;

namespace Junior.Helper
{
	public static class LogHelper
	{
		public static void Test(string text)
		{
			Log.Logger = new LoggerConfiguration()
				.MinimumLevel.Information()
				.WriteTo.Console()
				.WriteTo.File("Log/log.txt",
					rollingInterval: RollingInterval.Day,
					rollOnFileSizeLimit: true)
				.CreateLogger();
			Serilog.Debugging.SelfLog.Enable(msg => Debug.WriteLine(msg));
			Serilog.Debugging.SelfLog.Enable(Console.Error);
			
			Log.Information("Hello!");
			Log.Error(text);

			Log.CloseAndFlush();
		}

		public static void LogError(int status,string message)
		{
			Log.Logger = new LoggerConfiguration()
				.WriteTo.File("Log/error.txt",
					rollingInterval: RollingInterval.Day,
					rollOnFileSizeLimit: true)
				.CreateLogger();

			Log.Error("["+status+"]:"+message);
			Log.CloseAndFlush();
		}
	}
}
