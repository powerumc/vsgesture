using System.Text;
using System;
using System.Windows.Forms;
using System.Drawing;
using Umc.Core.Tools.VSGesture;

internal class VsNativeWindow : NativeWindow, IDisposable
{
	protected const int WM_MOUSEMOVE = 0x200;
	protected const int WM_LBUTTONDOWN = 0x201;
	protected const int WM_RBUTTONDOWN = 0x204;
	protected const int WM_MBUTTONDOWN = 0x207;
	protected const int WM_LBUTTONUP = 0x202;
	protected const int WM_RBUTTONUP = 0x205;
	protected const int WM_MBUTTONUP = 0x208;
	protected const int WM_LBUTTONDBLCLK = 0x203;
	protected const int WM_RBUTTONDBLCLK = 0x206;
	protected const int WM_MBUTTONDBLCLK = 0x209;

	private System.Drawing.Graphics graphics;

	public event EventHandler Close;
	public event EventHandler Focus;
	public event EventHandler<KeyEventArgs> KeyDown;
	public event EventHandler<KeyPressEventArgs> KeyPress;
	public event EventHandler<KeyEventArgs> KeyUp;
	public event EventHandler LostFocus;
	public event EventHandler<MouseEventArgs> MouseMove;
	public event EventHandler<CancelableMouseEventArgs> MouseDown;
	public event EventHandler<CancelableMouseEventArgs> MouseUp;
	public event EventHandler<PaintEventArgs> Paint;
	public event EventHandler Resize;
	public event EventHandler<ScrollEventArgs> Scroll;
	internal VsNativeWindow()
		: this(IntPtr.Zero)
	{
	}

	internal VsNativeWindow(IntPtr handle)
	{
		this.Initialize(handle);
	}

	public virtual void Dispose()
	{
		if (this.graphics != null)
		{
			this.graphics.Dispose();
		}
	}

	protected void Initialize(IntPtr handle)
	{
		if (handle != IntPtr.Zero)
		{
			base.AssignHandle(handle);
		}
	}

	protected virtual void Onclose()
	{
		if (this.Close != null)
		{
			this.Close(this, EventArgs.Empty);
		}
	}

	private void OnClose()
	{
		throw new Exception("The method or operation is not implemented.");
	}

	protected virtual void OnFocus()
	{
	}

	protected virtual void OnKeyDown(KeyEventArgs args)
	{
		if (this.KeyDown != null)
		{
			this.KeyDown(this, args);
		}
	}

	protected virtual void OnKeyPress(KeyPressEventArgs args)
	{
		if (this.KeyPress != null)
		{
			this.KeyPress(this, args);
		}
	}

	protected virtual void OnKeyUp(KeyEventArgs args)
	{
		if (this.KeyUp != null)
		{
			this.KeyUp(this, args);
		}
	}

	protected virtual void OnLostFocus()
	{
	}

	protected virtual void OnMouseMove(MouseEventArgs args)
	{
	}

	protected virtual void OnMouseDown(MouseEventArgs args)
	{
	}

	protected virtual void OnMouseUp(MouseEventArgs args)
	{
	}

	protected virtual void OnPaint(PaintEventArgs args)
	{
	}

	protected virtual void OnResize()
	{
		if (this.Resize != null)
		{
			this.Resize(this, EventArgs.Empty);
		}
	}

	protected virtual void OnScroll(ScrollEventArgs args)
	{
		if (this.Scroll != null)
		{
			this.Scroll(this, args);
		}
	}

	protected override void WndProc(ref Message m)
	{
		switch (m.Msg)
		{
			case 7:
				if (this.Focus != null)
				{
					this.Focus(this, EventArgs.Empty);
				}
				break;

			case 8:
				if (this.LostFocus != null)
				{
					this.LostFocus(this, EventArgs.Empty);
				}
				break;

			case 15:
				{
					RECT rect = new RECT();
					bool bErase = false;
					NativeMethods.GetUpdateRect(base.Handle, ref rect, ref bErase);
					base.WndProc(ref m);
					if (this.Paint != null)
					{
						PaintEventArgs e = new PaintEventArgs(this.Graphics, new Rectangle(rect.left, rect.top, rect.right - rect.left, rect.bottom - rect.top));
						this.Paint(this, e);
					}
					return;
				}
			case 0x10:
				this.OnClose();
				break;

			case 20:
				return;

			case 0x114:
			case 0x115:
				{
					ScrollEventArgs args = new ScrollEventArgs(ScrollEventType.First, 0, ScrollOrientation.HorizontalScroll);
					this.OnScroll(args);
					break;
				}
			case 0x200:
				if (this.MouseMove != null)
				{
					this.MouseMove(this, new MouseEventArgs(MouseButtons, 0, NativeMethods.SignedLOWORD(m.LParam), NativeMethods.SignedHIWORD(m.LParam), 0));
				}
				break;

			case WM_LBUTTONDOWN:
				if (this.MouseDown != null)
				{
					var args = new CancelableMouseEventArgs(MouseButtons, 1, NativeMethods.SignedLOWORD(m.LParam), NativeMethods.SignedHIWORD(m.LParam), 0);
					args.Message = m;

					this.MouseDown(this, args);

					if( args.Cancel ) return;
				}
				break;

			case WM_MBUTTONDOWN:
				if (this.MouseDown != null)
				{
					var args = new CancelableMouseEventArgs(MouseButtons, 1, NativeMethods.SignedLOWORD(m.LParam), NativeMethods.SignedHIWORD(m.LParam), 0);
					args.Message = m;

					this.MouseDown(this, args);

					if( args.Cancel ) return;
				}
				break;

			case WM_RBUTTONDOWN:
				if (this.MouseDown != null)
				{
					var args = new CancelableMouseEventArgs(MouseButtons, 1, NativeMethods.SignedLOWORD(m.LParam), NativeMethods.SignedHIWORD(m.LParam), 0);
					args.Message = m;

					this.MouseDown(this, args);

					if( args.Cancel ) return;
				}
				break;

			case WM_LBUTTONUP:
				if(this.MouseUp != null )
				{
					var args = new CancelableMouseEventArgs(MouseButtons, 0, NativeMethods.SignedLOWORD(m.LParam), NativeMethods.SignedHIWORD(m.LParam), 0);
					args.Message = m;

					this.MouseUp(this, args);

					if( args.Cancel ) return;
				}
				break;

			case WM_RBUTTONUP:
				if(this.MouseUp != null )
				{
					var args = new CancelableMouseEventArgs(MouseButtons, 0, NativeMethods.SignedLOWORD(m.LParam), NativeMethods.SignedHIWORD(m.LParam), 0);
					args.Message = m;

					this.MouseUp(this, args);

					if (args.Cancel) return;
				}
				break;

			case WM_MBUTTONUP:
				if(this.MouseUp != null )
				{
					var args = new CancelableMouseEventArgs(MouseButtons, 0, NativeMethods.SignedLOWORD(m.LParam), NativeMethods.SignedHIWORD(m.LParam), 0);
					args.Message = m;

					this.MouseUp(this, args);

					if( args.Cancel ) return;
				}
				break;

			case 0x100:
				{
					base.WndProc(ref m);
					Keys keyData = ((Keys)((int)m.WParam)) | ModifierKeys;
					this.OnKeyDown(new KeyEventArgs(keyData));
					return;
				}
			case 0x101:
				{
					base.WndProc(ref m);
					Keys keys2 = ((Keys)((int)m.WParam)) | ModifierKeys;
					this.OnKeyUp(new KeyEventArgs(keys2));
					return;
				}
			case 0x102:
			case 0x106:
				this.OnKeyPress(new KeyPressEventArgs((char)((ushort)((long)m.WParam))));
				break;

			case 0x47:
				this.OnResize();
				break;
		}
		base.WndProc(ref m);
	}

	public Rectangle Bounds
	{
		get
		{
			RECT lpRect = new RECT();
			NativeMethods.GetWindowRect(base.Handle, out lpRect);
			return new Rectangle(lpRect.left, lpRect.top, lpRect.right - lpRect.left, lpRect.bottom - lpRect.top);
		}
	}

	public string Caption
	{
		get
		{
			int windowTextLength = NativeMethods.GetWindowTextLength(base.Handle);
			if (SystemInformation.DbcsEnabled)
			{
				windowTextLength = (windowTextLength * 2) + 1;
			}
			StringBuilder lpString = new StringBuilder(windowTextLength + 1);
			NativeMethods.GetWindowText(base.Handle, lpString, lpString.Capacity);
			return lpString.ToString();
		}
	}

	public System.Drawing.Graphics Graphics
	{
		get
		{
			if (this.graphics == null)
			{
				this.graphics = System.Drawing.Graphics.FromHwndInternal(base.Handle);
			}
			return this.graphics;
		}
		set
		{
			this.graphics = value;
		}
	}

	public Point Location
	{
		get
		{
			return this.Bounds.Location;
		}
	}

	public static Keys ModifierKeys
	{
		get
		{
			Keys none = Keys.None;
			if (NativeMethods.GetKeyState(0x10) < 0)
			{
				none |= Keys.Shift;
			}
			if (NativeMethods.GetKeyState(0x11) < 0)
			{
				none |= Keys.Control;
			}
			if (NativeMethods.GetKeyState(0x12) < 0)
			{
				none |= Keys.Alt;
			}
			return none;
		}
	}

	internal static System.Windows.Forms.MouseButtons MouseButtons
	{
		get
		{
			System.Windows.Forms.MouseButtons none = System.Windows.Forms.MouseButtons.None;
			if (NativeMethods.GetKeyState(1) < 0)
			{
				none |= System.Windows.Forms.MouseButtons.Left;
			}
			if (NativeMethods.GetKeyState(2) < 0)
			{
				none |= System.Windows.Forms.MouseButtons.Right;
			}
			if (NativeMethods.GetKeyState(4) < 0)
			{
				none |= System.Windows.Forms.MouseButtons.Middle;
			}
			if (NativeMethods.GetKeyState(5) < 0)
			{
				none |= System.Windows.Forms.MouseButtons.XButton1;
			}
			if (NativeMethods.GetKeyState(6) < 0)
			{
				none |= System.Windows.Forms.MouseButtons.XButton2;
			}
			return none;
		}
	}

	public IntPtr ParentHandle
	{
		get
		{
			return NativeMethods.GetParent(base.Handle);
		}
	}
}