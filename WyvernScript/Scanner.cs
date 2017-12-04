using System;

namespace WyvernScript
{
	internal class Scanner
	{
		internal static TokenStream Scan(Source source)
		{
			var stream = new TokenStream();
			for (var i = 0; i < source.Code.Length; i++)
			{
				var c = source.Code[i];
				if (c.IsWordStart())
				{
					stream.Add(ScanIdentifier(source, i, out i));
					continue;
				}
				if (c.IsDigit())
				{
					stream.Add(ScanNumber(source, i, out i));
					continue;
				}
				if (c <= ' ')
					continue;
			}
			return stream;
		}

		static Token ScanIdentifier(Source source, int position, out int newPosition)
		{
			var sb = new System.Text.StringBuilder();
			do
			{
				sb.Append(source.Code[position++]);
			}
			while (position < source.Code.Length && source.Code[position].IsWord());

			newPosition = position;
			return new Token(TokenType.Identifier, new TokenValue(sb.ToString()));
		}

		static Token ScanNumber(Source source, int position, out int newPosition)
		{
			var wasPoint = false;
			var sb = new System.Text.StringBuilder();
			do
			{
				if (source.Code[position] == '.')
				{
					if (wasPoint)
						throw new CompileException("malformed number");
					wasPoint = true;
				}
				sb.Append(source.Code[position++]);
			}
			while (position < source.Code.Length && (source.Code[position].IsDigit() || source.Code[position] == '.'));

			double num;
			if (!Double.TryParse(sb.ToString(), out num))
				throw new CompileException("malformed number");
			newPosition = position;
			return new Token(TokenType.Number, new TokenValue(num));
		}
	}
}

