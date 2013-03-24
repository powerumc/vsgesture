using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvDTE;
using Microsoft.VisualStudio.Shell;

namespace Umc.Core.Tools.VSGesture.Util
{
	public static class DteHelper
	{
		public static int? GetDocumentIndex(string fullname)
		{
			DTE dte = Package.GetGlobalService(typeof(DTE)) as DTE;

			for (int i = 1; i <= dte.Documents.Count; i++)
			{
				if (dte.Documents.Item(i).FullName == fullname)
				{
					return i;
				}
			}

			return null;
		}
	}
}
