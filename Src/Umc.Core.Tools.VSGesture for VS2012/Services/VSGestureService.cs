using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Shell;

using Umc.Core.Tools.VSGesture;
using Umc.Core.Tools.VSGesture.Shell;
using Umc.Core.Tools.VSGesture.Actions;

using Microsoft.VisualStudio.TextManager.Interop;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio;
using EnvDTE;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace Umc.Core.Tools.VSGesture.Services
{
	public class VSGestureService :
		IVSGestureService,
		SVSGestureService
	{
		private static IVSGestureService instance = null;
		private static IVsTextManager manager = null;
		private static VSGestureInfo _vsGestureInfo = null;
		private static GestureActionList _gestureActionList = null;

		private static object lockObj = new object();
		private VSGestureAsyncPackage package = null;

		private VSGestureService() { }

		public VSGestureService(VSGestureAsyncPackage package)
		{
			this.package	= package;
		}

		#region Current
		public static IVSGestureService Current
		{
			get
			{
				try
				{
					if (instance == null)
					{
						lock (lockObj)
						{
							if (instance == null)
							{
								instance = Package.GetGlobalService(typeof(SVSGestureService)) as IVSGestureService;
								manager = Package.GetGlobalService(typeof(SVsTextManager)) as IVsTextManager;
							}
						}
					}

					return instance;
				}
				catch (Exception ex)
				{
					throw;
				}
			}
		} 
		#endregion

		#region VSGestureInfo
		public VSGestureInfo VSGestureInfo
		{
			get
			{
				if (_vsGestureInfo == null)
				{
					lock (lockObj)
					{
						if (_vsGestureInfo == null)
						{
							_vsGestureInfo = VSGestureInfo.Load();
						}
					}
				}

				return _vsGestureInfo;
			}
			set
			{
				lock (lockObj)
				{
					_vsGestureInfo = value;

					VSGestureInfo.Save(value);
				}
			}
		} 
		#endregion

		#region GestureActionList
		public GestureActionList GestureActionList
		{
			get
			{
				if (_gestureActionList == null)
					_gestureActionList = GestureActionList.Load();

				return _gestureActionList;
			}
		} 
		#endregion

		DocumentEvents docEvent;
		WindowEvents winEvent;
		public void Init()
		{
			DTE dte = Package.GetGlobalService(typeof(DTE)) as DTE;
			
			IVsTextView view;
			manager.GetActiveView( 1, null, out view);

			docEvent = dte.Events.get_DocumentEvents(null);
			
			winEvent = dte.Events.get_WindowEvents(null);
		}

		public void ShowOptionPage()
		{
			this.package.ShowOptionPage(typeof(OptionPages.OptionPageDefault));
		}
	}
}
