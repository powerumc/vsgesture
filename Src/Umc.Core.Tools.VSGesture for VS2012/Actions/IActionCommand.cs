using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Umc.Core.Tools.VSGesture.Actions
{
	public interface IActionCommand
	{
		bool CanEnsure { get; }
		void Execute();
	}
}
