using System;

namespace WyvernScript
{
	internal struct Token
	{
		internal static Token Null = new Token();
		internal static SourceRef Location;

		TokenType Type;
		TokenValue Value;

		internal Token(TokenType type)
		{
			Value = TokenValue.Null;
			Type = type;
		}

		internal Token(TokenType type, TokenValue value)
		{
			Value = value;
			Type = type;
		}

		public override string ToString()
		{
			return string.Format("{0}: {1}", Type, Value);
		}
	}
}

