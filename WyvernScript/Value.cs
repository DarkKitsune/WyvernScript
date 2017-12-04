using System;
using System.Runtime.InteropServices;

namespace WyvernScript
{
	[StructLayout(LayoutKind.Explicit, Size = 10)] 
	public struct Value
	{
		[FieldOffset(0)] public int Int;
		[FieldOffset(0)] public long Long;
		[FieldOffset(0)] public float Float;
		[FieldOffset(0)] public double Double;
		[FieldOffset(0)] public string String;
		[FieldOffset(0)] public object Object;
		[FieldOffset(8)] public short Type;
	}
}

