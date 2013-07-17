using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Umc.Core.Tools.VSGesture.Actions
{
	public partial class GestureActionList
	{
		public static GestureActionList Load()
		{
			return ResourceUtil.PerformLoad<GestureActionList>(Assembly.GetExecutingAssembly(), "Umc.Core.Tools.VSGesture.Actions.GestureActionList.xml", false);
		}

	}
}
