using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Umc.Core.Tools.VSGesture.Actions
{
	public class ExecuteCustomCommand : IExecuteCommand
	{
		private Type type;

		public ExecuteCustomCommand(string type) : this(Type.GetType(type))
		{
		}

		public ExecuteCustomCommand(Type type)
		{
			this.type = type;
		}

		#region IExecuteCommand 멤버

		public void ExecuteLazyCommand()
		{
			IExecuteCommand command = Activator.CreateInstance(this.type) as IExecuteCommand;
			command.ExecuteLazyCommand();
		}

		#endregion
	}
}
