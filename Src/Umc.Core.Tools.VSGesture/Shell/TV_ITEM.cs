	using System;
	using System.Runtime.InteropServices;

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	internal struct TV_ITEM
	{
		public int mask;
		public IntPtr hItem;
		public int state;
		public int stateMask;
		public IntPtr pszText;
		public int cchTextMax;
		public int iImage;
		public int iSelectedImage;
		public int cChildren;
		public IntPtr lParam;
	}
