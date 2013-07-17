	using System;
	using System.Runtime.InteropServices;

	[StructLayout(LayoutKind.Sequential)]
	internal struct SCROLLINFO
	{
		public uint cbSize;
		public uint fMask;
		public int nMin;
		public int nMax;
		public uint nPage;
		public int nPos;
		public int nTrackPos;
	}
