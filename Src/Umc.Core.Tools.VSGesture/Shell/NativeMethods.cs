using System;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Text;

    /// <summary>
    /// This class will contain all methods that we need to import.
    /// </summary>
internal class NativeMethods
{
	public const int WM_LBUTTONDOWN = 0x0201;
	public const int WM_LBUTTONDBLCLK = 0x0203;
	public const int WM_RBUTTONDOWN = 0x0204;
	public const int WM_MBUTTONDOWN = 0x0207;

	//Including a private constructor to prevent a compiler-generated default constructor
	private NativeMethods()
	{
	}

	// Import the SendMessage function from user32.dll
	[DllImport("user32.dll")]
	public static extern IntPtr SendMessage(IntPtr hwnd,
											int Msg,
											IntPtr wParam,
											[MarshalAs(UnmanagedType.IUnknown)] out object lParam);

	public const int FILE_ATTRIBUTE_NORMAL = 0x80;
	private const string GENERICPANE = "GenericPane";
	public const int HT_CAPTION = 2;
	public static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
	public const int SB_ENDSCROLL = 8;
	public const int SB_LEFT = 6;
	public const int SB_LINELEFT = 0;
	public const int SB_LINERIGHT = 1;
	public const int SB_PAGELEFT = 2;
	public const int SB_PAGERIGHT = 3;
	public const int SB_RIGHT = 7;
	public const int SB_THUMBPOSITION = 4;
	public const int SB_THUMBTRACK = 5;
	public const int SIF_ALL = 0x17;
	public const int SIF_PAGE = 2;
	public const int SIF_POS = 4;
	public const int SIF_RANGE = 1;
	public const int SIF_TRACKPOS = 0x10;
	public const int SWP_NOACTIVATE = 0x10;
	public const int SWP_NOMOVE = 2;
	public const int SWP_NOSIZE = 1;
	public const int SWP_NOZORDER = 4;
	public const string TOOLTIPS_CLASS = "tooltips_class32";
	public const int TTF_ABSOLUTE = 0x80;
	public const int TTF_CENTERTIP = 2;
	public const int TTF_IDISHWND = 1;
	public const int TTF_PARSELINKS = 0x1000;
	public const int TTF_SUBCLASS = 0x10;
	public const int TTF_TRACK = 0x20;
	public const int TTF_TRANSPARENT = 0x100;
	public const int TTM_ADDTOOL = 0x432;
	public const int TTM_SETMAXTIPWIDTH = 0x418;
	public const int TTM_SETTITLE = 0x421;
	public const int TTM_TRACKACTIVATE = 0x411;
	public const int TTM_TRACKPOSITION = 0x412;
	public const int TTS_ALWAYSTIP = 1;
	public const int TTS_BALLOON = 0x40;
	public const int TTS_CLOSE = 0x80;
	public const int TTS_NOPREFIX = 2;
	public const int WM_HSCROLL = 0x114;
	public const int WM_NCLBUTTONDOWN = 0xa1;
	public const int WM_USER = 0x400;
	public const int WM_VSCROLL = 0x115;
	public const int WS_POPUP = -2147483648;


	[DllImport("user32.dll")]
	public  static extern void  mouse_event(int  dwFlags,int  dx,int  dy,int  cButtons,int  dwExtraInfo);

	[DllImport("User32", SetLastError = true)]
	public static extern int ClientToScreen(IntPtr hWnd, ref POINT lpRect);
	[return: MarshalAs(UnmanagedType.Bool)]
	[DllImport("user32.dll", SetLastError = true)]
	public static extern bool DestroyIcon(IntPtr hIcon);
	[DllImport("user32.dll", SetLastError = true)]
	public static extern bool DrawMenuBar(IntPtr hWnd);
	[DllImport("user32.dll", SetLastError = true)]
	public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
	[DllImport("user32.dll", SetLastError = true)]
	public static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string className, string windowTitle);
	[DllImport("User32.DLL")]
	public static extern IntPtr GetActiveWindow();
	[DllImport("User32", SetLastError = true)]
	public static extern int GetClientRect(IntPtr hWnd, ref RECT lpRect);
	[DllImport("user32.dll")]
	public static extern bool GetCursorPos(ref Point lpPoint);
	[DllImport("user32.dll")]
	public  static extern int  SetCursorPos(int  x,int  y);
	[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
	public static extern short GetKeyState(int keyCode);
	[DllImport("kernel32.dll")]
	internal static extern int GetLastError();
	[DllImport("user32.dll", SetLastError = true)]
	public static extern IntPtr GetMenu(IntPtr hWnd);
	[DllImport("user32.dll", SetLastError = true)]
	public static extern int GetMenuItemCount(IntPtr hWnd);
	[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
	public static extern IntPtr GetParent(IntPtr hWnd);
	[return: MarshalAs(UnmanagedType.Bool)]
	[DllImport("user32.dll")]
	public static extern bool GetScrollInfo(IntPtr hwnd, int fnBar, ref SCROLLINFO lpsi);
	[DllImport("user32.dll", SetLastError = true)]
	public static extern IntPtr GetSubMenu(IntPtr hMenu, int nPos);
	[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
	public static extern bool GetUpdateRect(IntPtr hWnd, ref RECT rect, ref bool bErase);
	[DllImport("User32", SetLastError = true)]
	public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);
	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);
	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	public static extern int GetWindowTextLength(IntPtr hWnd);
	[DllImport("user32.dll", SetLastError = true)]
	public static extern bool InsertMenuItem(IntPtr hMenu, uint uItem, bool fByPosition, ref MENUITEMINFO info);
	[DllImport("user32.dll")]
	public static extern bool InvalidateRect(IntPtr hWnd, IntPtr lpRect, bool bErase);
	[DllImport("User32.dll")]
	public static extern int LockWindowUpdate(IntPtr window);
	public static int MAKELONG(int loWord, int hiWord)
	{
		return ((hiWord << 0x10) | (loWord & 0xffff));
	}

	[DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true, ExactSpelling = true)]
	public static extern int MultiByteToWideChar(int CodePage, int dwFlags, byte[] lpMultiByteStr, int cchMultiByte, char[] lpWideCharStr, int cchWideChar);
	[DllImport("user32.dll")]
	public static extern bool ReleaseCapture();
	[DllImport("user32.dll")]
	public static extern bool ScreenToClient(IntPtr hWnd, ref POINT lpPoint);
	internal static IntPtr SearchForWindow(IntPtr parent, string caption)
	{
		IntPtr ptr = FindWindowEx(parent, IntPtr.Zero, "GenericPane", caption);
		if (ptr != IntPtr.Zero)
		{
			return ptr;
		}
		for (IntPtr ptr2 = FindWindowEx(parent, IntPtr.Zero, null, null); ptr2 != IntPtr.Zero; ptr2 = FindWindowEx(parent, ptr2, null, null))
		{
			ptr = SearchForWindow(ptr2, caption);
			if (ptr != IntPtr.Zero)
			{
				return ptr;
			}
		}
		return IntPtr.Zero;
	}

	[DllImport("User32", SetLastError = true)]
	public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, IntPtr lParam);
	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, [In, Out] ref RECT lParam);
	[DllImport("user32.dll")]
	public static extern IntPtr SendMessage(IntPtr hwnd, uint msg, [In, Out] IntPtr wParam, [In, Out] Structs.TVITEMEX lParam);
	[DllImport("User32.dll")]
	public static extern int SendMessage(IntPtr hWnd, uint msg, [In, Out] IntPtr wParam, [In, Out] uint lParam);
	[DllImport("User32.dll")]
	public static extern int SendMessage(IntPtr hWnd, uint msg, [In, Out] uint wParam, [In, Out] uint lParam);
	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, ref TV_ITEM lParam);
	[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
	public static extern IntPtr SetFocus(HandleRef hWnd);
	[DllImport("User32", SetLastError = true)]
	public static extern int SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
	[DllImport("User32", SetLastError = true)]
	public static extern int SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, int uFlags);
	[DllImport("shell32.dll", CharSet = CharSet.Auto)]
	public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbFileInfo, uint uFlags);
	public static int SignedHIWORD(int n)
	{
		return (short)((n >> 0x10) & 0xffff);
	}

	public static int SignedHIWORD(IntPtr n)
	{
		return SignedHIWORD((int)((long)n));
	}

	public static int SignedLOWORD(int n)
	{
		return (short)(n & 0xffff);
	}

	public static int SignedLOWORD(IntPtr n)
	{
		return SignedLOWORD((int)((long)n));
	}

	[DllImport("user32.dll")]
	public static extern bool UpdateWindow(IntPtr hWnd);

	[StructLayout(LayoutKind.Sequential)]
	public struct POINT
	{
		public int X;
		public int Y;
		public POINT(int x, int y)
		{
			this.X = x;
			this.Y = y;
		}

		public static implicit operator Point(NativeMethods.POINT p)
		{
			return new Point(p.X, p.Y);
		}

		public static implicit operator NativeMethods.POINT(Point p)
		{
			return new NativeMethods.POINT(p.X, p.Y);
		}
	}
}