using System;
using System.Linq;

namespace WyvernScript
{
	public static class Util
	{
		public static double BenchmarkMS(int executions, Action action)
		{
			var sw = new System.Diagnostics.Stopwatch();
			sw.Start();
			for (var i = 0; i < executions; i++)
			{
				action.Invoke();
			}
			sw.Stop();
			return (double)sw.ElapsedTicks / (double)TimeSpan.TicksPerMillisecond;
		}

		public static double BenchmarkMSPrint(string name, int executions, Action action)
		{
			var sw = new System.Diagnostics.Stopwatch();
			sw.Start();
			for (var i = 0; i < executions; i++)
			{
				action.Invoke();
			}
			sw.Stop();
			var time = (double)sw.ElapsedTicks / (double)TimeSpan.TicksPerMillisecond;
			Console.WriteLine(String.Format("[Benchmark] {0} took {1} ms", name, time));
			return time;
		}

		public static string RemoveAll(this string str, char ch)
		{
			var sb = new System.Text.StringBuilder();
			foreach (var c in str)
			{
				if (c != ch)
					sb.Append(c);
			}
			return sb.ToString();
		}

		public static string Unwindowsify(this string str)
		{
			return str.RemoveAll('\r'); // get that trash outta here
		}

		internal static bool IsAlpha(this char c)
		{
			return (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z');
		}

		internal static bool IsDigit(this char c)
		{
			return c >= '0' && c <= '9';
		}

		internal static bool IsWordStart(this char c)
		{
			return c.IsAlpha() || c == '_';
		}

		internal static bool IsWord(this char c)
		{
			return c.IsWordStart() || c.IsDigit();
		}
	}
}

