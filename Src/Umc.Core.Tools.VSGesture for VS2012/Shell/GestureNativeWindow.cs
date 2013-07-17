using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualStudio.TextManager.Interop;
using System.IO;
using Umc.Core.Tools.VSGesture;
using EnvDTE;
using Microsoft.VisualStudio.Shell;
using System.Drawing;
using Umc.Core.Tools.VSGesture.Services;

namespace Umc.Core.Tools.VSGesture.Shell
{
	internal class GestureNativeWindow : VsNativeWindow, IDisposable
	{
		private NativeWindow nativeWindow;
		private Pen pen = new Pen(Brushes.Red, 5);
		private VSGestureAnalyzer analyzer = new VSGestureAnalyzer();
		private IntPtr handler;

		private IVsTextManager manager = null;

		private bool isMouseDown;
		private int preX, preY;

		public GestureNativeWindow(IntPtr handler) : base(handler)
		{
			this.handler = handler;

			init();
		}

		private void init()
		{
			DTE dte = Package.GetGlobalService(typeof(DTE)) as DTE;
			
			manager = Package.GetGlobalService(typeof(SVsTextManager)) as IVsTextManager;

			
			this.MouseMove += new EventHandler<MouseEventArgs>(GestureNativeWindow_MouseMove);
			this.MouseUp += new EventHandler<CancelableMouseEventArgs>(GestureNativeWindow_MouseUp);
			this.MouseDown += new EventHandler<CancelableMouseEventArgs>(GestureNativeWindow_MouseDown);
		}

		#region Mouse Actions
		void GestureNativeWindow_MouseDown(object sender, CancelableMouseEventArgs e)
		{
			try
			{
				if (e.Clicks == 1 &&
					e.Button == System.Windows.Forms.MouseButtons.Right)
				{
					isMouseDown = true;
					preX = e.X;
					preY = e.Y;

					e.Cancel = true;

					preMsg = e.Message;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private Message preMsg;
		void GestureNativeWindow_MouseUp(object sender, CancelableMouseEventArgs e)
		{
			if (isMouseDown == true)
			{
				NativeMethods.InvalidateRect(this.handler, IntPtr.Zero, true);
				Application.DoEvents();

				e.Cancel = analyzer.Count > 10;

				if (e.Cancel)
				{
				}
				else
				{
					e.Cancel = false;
					base.WndProc(ref preMsg);
				}

				analyzer.Analyzer();
			}
			isMouseDown = false;
		}

		void GestureNativeWindow_MouseMove(object sender, MouseEventArgs e)
		{
			try
			{
				if (isMouseDown == true &&
					e.Button == System.Windows.Forms.MouseButtons.Right)
				{
					this.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

					string lineColor = Services.VSGestureService.Current.VSGestureInfo.UserSettings.LineColor;
					string thickness = Services.VSGestureService.Current.VSGestureInfo.UserSettings.LineThickness;

					string[] rgb = lineColor.Split(',');

					Pen userPen = new Pen(Color.FromArgb(	int.Parse(rgb[0]), 
															int.Parse(rgb[1]), 
															int.Parse(rgb[2])),
										  (float)(Controls.LineThicknessStyle)Enum.Parse(typeof(Controls.LineThicknessStyle), thickness));


					this.Graphics.DrawLine(userPen, preX, preY, e.X, e.Y);

					analyzer.Add(new System.Windows.Input.StylusPoint(e.X, e.Y));

					preX = e.X;
					preY = e.Y;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		#endregion

		#region IDisposable 멤버

		void IDisposable.Dispose()
		{
			analyzer	= null;
			pen			= null;
		}

		#endregion
	}
}
