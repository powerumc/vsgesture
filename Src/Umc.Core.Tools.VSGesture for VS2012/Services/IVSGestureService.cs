using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using Umc.Core.Tools.VSGesture.Actions;

namespace Umc.Core.Tools.VSGesture.Services
{
	[ComVisible(true)]
	[Guid("8FE33E67-B41D-4808-BA2A-F768A5252325")]
	public interface IVSGestureService
	{
		void Init();
		VSGestureInfo VSGestureInfo { get; set; }
		GestureActionList GestureActionList { get; }
		void ShowOptionPage();
	}

	[Guid("7AD219E8-FB3E-4c23-8084-7BC42B57D9FE")]
	public interface SVSGestureService
	{
	}
}
