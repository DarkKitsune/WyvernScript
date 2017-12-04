using System;

namespace WyvernScript
{
	public struct SourceRef
	{
		public Source Source {get; internal set;}
		public int Line {get; internal set;}
		public int Column {get; internal set;}

	}
}

