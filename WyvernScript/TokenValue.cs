using System;
using System.Runtime.InteropServices;

namespace WyvernScript
{
	[StructLayout(LayoutKind.Explicit, Size = 10)] 
	public struct TokenValue
	{
		public static TokenValue Null {get; private set;} = new TokenValue();

		[FieldOffset(0)] public double Number;
		[FieldOffset(0)] public string String;
		//[FieldOffset(0)] public object Object;
		[FieldOffset(8)] public TokenValueType Type;

		public object DynamicValue
		{
			get
			{
				switch (Type)
				{
					case TokenValueType.Number:
						return Number;
					case TokenValueType.String:
						return String;
					default:
						return null;
				}
			}
		}

		public TokenValue(double v)
		{
			Number = v;
			String = "";
			Type = TokenValueType.Number;
		}

		public TokenValue(string v)
		{
			Number = 0.0;
			String = v;
			Type = TokenValueType.String;
		}

		public override string ToString()
		{
			if (Type == TokenValueType.String)
				return String.Format("\"{0}\"", String);
			return DynamicValue.ToString();
		}
	}
}

