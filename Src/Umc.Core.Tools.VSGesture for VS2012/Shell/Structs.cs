	using System;
	using System.Runtime.InteropServices;

	internal static class Structs
	{
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public class TVITEMEX
		{
			public uint mask;
			public IntPtr hItem;
			public uint state;
			public uint stateMask;
			public string pszText;
			public int cchTextMax;
			public int iImage;
			public int iSelectedImage;
			public int cChildren;
			public int lParam;
			public int iIntegral;
		}
	}
