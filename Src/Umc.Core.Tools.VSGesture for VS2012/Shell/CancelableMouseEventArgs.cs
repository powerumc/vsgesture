using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Umc.Core.Tools.VSGesture
{
	public class CancelableMouseEventArgs : MouseEventArgs
	{
		public CancelableMouseEventArgs(MouseButtons button, int clicks, int x, int y, int delta)
			: base(button, clicks, x, y, delta)
		{
		}

		public bool Cancel { get; set; }
		public Message Message { get; set; }
		public bool IsRunned { get; set; }
	}
}
