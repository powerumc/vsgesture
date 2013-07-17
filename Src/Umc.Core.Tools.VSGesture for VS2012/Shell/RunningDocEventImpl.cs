using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.TextManager.Interop;
using System.ComponentModel.Design;
using Umc.Core.Tools.VSGesture.Services;
using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Editor;

namespace Umc.Core.Tools.VSGesture.Shell
{
	public class RunningDocEventImpl : IVsRunningDocTableEvents
	{
		internal static uint docCookie	= 0;

		#region IVsRunningDocTableEvents 멤버

		public int OnAfterAttributeChange(uint docCookie, uint grfAttribs)
		{
			return VSConstants.S_OK;
		}

		public int OnAfterDocumentWindowHide(uint docCookie, IVsWindowFrame pFrame)
		{
			var view = VsShellUtilities.GetTextView(pFrame);

			if (list.ContainsKey(view.GetWindowHandle()))
			{
				list[view.GetWindowHandle()].ReleaseHandle();
			    list.Remove(view.GetWindowHandle());
			}

			return VSConstants.S_OK;
		}

		public int OnAfterFirstDocumentLock(uint docCookie, uint dwRDTLockType, uint dwReadLocksRemaining, uint dwEditLocksRemaining)
		{
			return VSConstants.S_OK;
		}

		public int OnAfterSave(uint docCookie)
		{
			return VSConstants.S_OK;
		}

		[Import(typeof(IVsEditorAdaptersFactoryService))]
		IVsEditorAdaptersFactoryService VsEditorAdapterFactoryService { get; set; }

		Dictionary<IntPtr, GestureNativeWindow> list = new Dictionary<IntPtr,GestureNativeWindow>();
		public int OnBeforeDocumentWindowShow(uint docCookie, int fFirstShow, IVsWindowFrame pFrame)
		{
			if( VSGestureService.Current.VSGestureInfo.UserSettings.EnableVSGesture == false ) return VSConstants.S_OK;

			var win = VsShellUtilities.GetWindowObject(pFrame);
			if( win == null ) return VSConstants.S_OK;
			
			var view = VsShellUtilities.GetTextView(pFrame);
			if( view == null ) return VSConstants.S_OK;

			IDesignerHost host = win.Object as IDesignerHost;

			
			var handler = view.GetWindowHandle();

			var hwnd = handler;
			if (list.ContainsKey(hwnd) == true) return VSConstants.S_OK;


			
			


			GestureNativeWindow window = new GestureNativeWindow(hwnd);
			list.Add(hwnd, window);

			if (VSGestureService.Current.VSGestureInfo.UserSettings.EnableVSGestureAlram == true)
			{
				// Welcome 메시지
				VSGesture.Controls.frmWelcome frm = new Umc.Core.Tools.VSGesture.Controls.frmWelcome();
				frm.ShowInTaskbar = false;
				frm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
				frm.Show();

				VSGestureService.Current.VSGestureInfo.UserSettings.EnableVSGestureAlram = false;
				VSGestureService.Current.VSGestureInfo = VSGestureService.Current.VSGestureInfo;
			}

			return VSConstants.S_OK;
		}

		public int OnBeforeLastDocumentUnlock(uint docCookie, uint dwRDTLockType, uint dwReadLocksRemaining, uint dwEditLocksRemaining)
		{
			return VSConstants.S_OK;
		}

		#endregion
	}
}
