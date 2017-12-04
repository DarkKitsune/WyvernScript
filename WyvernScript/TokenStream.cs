using System;
using System.Collections.Generic;

namespace WyvernScript
{
	internal class TokenStream : List<Token>
	{
		public override string ToString()
		{
			return String.Format("[TokenStream: {0}]", String.Join(", ", this));
		}
	}
}

