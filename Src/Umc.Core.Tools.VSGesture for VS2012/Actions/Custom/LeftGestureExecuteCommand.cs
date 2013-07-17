using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvDTE;
using Microsoft.VisualStudio.Shell;
using Umc.Core.Tools.VSGesture.Util;

namespace Umc.Core.Tools.VSGesture.Actions
{
	public class LeftGestureExecuteCommand : IExecuteCommand
	{
		#region IExecuteCommand 멤버

		public void ExecuteLazyCommand()
		{
			DTE dte = Package.GetGlobalService(typeof(DTE)) as DTE;
			int? index = DteHelper.GetDocumentIndex(dte.ActiveDocument.FullName);
			
			if( index == null ) return;
			if( index == 1 ) index = dte.Documents.Count + 1;

			for (int i = (index??0)-1; i >= 1; i--)
			{
				try
				{
					dte.Documents.Item(i).Activate();
					break;
				}
				catch { }
			}
			//dte.ExecuteCommand("View.NavigateForward", "");
		}

		#endregion
	}
}
