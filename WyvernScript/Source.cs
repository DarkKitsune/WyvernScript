using System;
using System.Linq;
using System.IO;

namespace WyvernScript
{
	public class Source
	{
		public string Name {get; private set;}
		public string Code {get; private set;}
		internal SourceRef[] Locations {get; private set;}

		internal static Source FromString(string name, string code)
		{
			code = code.Unwindowsify();

			var source = new Source {
				Name = name,
				Code = code
			};
			source.PopulateLocations();
			return source;
		}

		internal static Source FromFile(string name, string path)
		{
			try
			{
				var source = FromString(name, File.ReadAllText(path));
				return source;
			}
			catch (IOException e)
			{
				throw new CouldNotReadSourceFileException(path);
			}
		}

		internal static Source FromFile(string path)
		{
			string name;
			try
			{
				name = Path.GetFileName(path);
			}
			catch (Exception e)
			{
				name = path;
			}
			return FromFile(name, path);
		}

		void PopulateLocations()
		{
			Locations = new SourceRef[Code.Length];
			var column = 0;
			var line = 0;
			var n = 0;
			foreach (var c in Code)
			{
				Locations[n++] = new SourceRef { Source = this, Line = line, Column = column };
				if (c == '\n')
				{
					line++;
					column = 0;
				}
				else
					column++;
			}
		}
	}
}

