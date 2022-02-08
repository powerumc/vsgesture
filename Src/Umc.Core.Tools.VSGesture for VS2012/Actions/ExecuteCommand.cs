using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvDTE;
using Microsoft.VisualStudio.Shell;

namespace Umc.Core.Tools.VSGesture.Actions
{
	public class ExecuteCommand : Umc.Core.Tools.VSGesture.Actions.IExecuteCommand
	{
		private string command;
		private string argument;

		public ExecuteCommand(string command) : this(command, null)
		{
		}

		public ExecuteCommand(string command, string argument)
		{
			this.command = command;
			this.argument = argument;
		}

		public void ExecuteLazyCommand()
		{
            ThreadHelper.ThrowIfNotOnUIThread();
            DTE dte = Package.GetGlobalService(typeof(DTE)) as DTE;

			dte.ExecuteCommand(this.command, this.argument ?? "");
		}
	}
}
