using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvDTE;
using Microsoft.VisualStudio.Shell;

namespace Umc.Core.Tools.VSGesture.Actions
{
	public class ActionCommand : IActionCommand
	{
		private IExecuteCommand command;
		public ActionCommand(IExecuteCommand command)
		{
			this.command = command;
		}

		#region IAction 멤버

		public bool CanEnsure
		{
			get { return true; }
		}

		public void Execute()
		{
			command.ExecuteLazyCommand();
		}

		#endregion
	}
}
