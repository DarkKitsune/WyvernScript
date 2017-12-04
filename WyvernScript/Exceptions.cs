using System;

namespace WyvernScript
{
	public class CouldNotReadSourceFileException : Exception
	{
		public string Path {get; private set;}

		public CouldNotReadSourceFileException(string path) :
		base("could not read source file \"" + path + "\"")
		{
			Path = path;
		}
	}
}

