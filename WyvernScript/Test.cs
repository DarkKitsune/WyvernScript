using System;

namespace WyvernScript
{
	public static class Test
	{
		public static void TestStuff()
		{
			string code = @"
test
124.2";
			Console.WriteLine(Scanner.Scan(Source.FromString("test", code)));
		}
	}
}

