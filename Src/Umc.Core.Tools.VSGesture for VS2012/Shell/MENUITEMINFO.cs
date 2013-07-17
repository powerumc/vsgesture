	using System;
	using System.Runtime.InteropServices;

	[StructLayout(LayoutKind.Sequential)]
	internal struct MENUITEMINFO
	{
		public long cbSize;
		public long fMask;
		public long fType;
		public long fState;
		public long wID;
		public long hSubMenu;
		public long hbmpChecked;
		public long hbmpUnchecked;
		public long dwItemData;
		public string dwTypeData;
		public long cch;
	}
