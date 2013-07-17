using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EnvDTE;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.TextManager.Interop;
using Umc.Core.Tools.VSGesture.Util;
using System.Windows.Forms;

namespace Umc.Core.Tools.VSGesture.Actions
{
	public class RightGestureExecuteCommand : IExecuteCommand
	{
		#region IExecuteCommand 멤버

		public void ExecuteLazyCommand()
		{
			DTE dte = Package.GetGlobalService(typeof(DTE)) as DTE;
			int? index = DteHelper.GetDocumentIndex(dte.ActiveDocument.FullName);
			
			if( index == null ) return;
			if( index == dte.Documents.Count ) index = 0;

			for (int i = (index??0)+1 ; i <= dte.Documents.Count; i++)
			{
				try
				{
					dte.Documents.Item(i).Activate();
					return;
				}
				catch { }
			}
			//dte.ExecuteCommand("View.NavigateBackward", "");
		}

		#endregion
	}
}
