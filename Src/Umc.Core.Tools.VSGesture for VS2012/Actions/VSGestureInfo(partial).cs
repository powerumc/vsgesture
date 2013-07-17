using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using Microsoft.Win32;
using System.Windows.Forms;

namespace Umc.Core.Tools.VSGesture.Actions
{
	public partial class VSGestureInfo
	{
		public static void Save(VSGestureInfo mapper)
		{
			string codebase = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			string path = Path.Combine(codebase, @"VSGestureInfo.xml");

			FileUtil.PerformSave<VSGestureInfo>(path, mapper, false, false);
		}

		public static VSGestureInfo Load()
		{
			string codebase = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			string path = Path.Combine(codebase, @"VSGestureInfo.xml");
			
			// CHANGE : 
			return FileUtil.PerformLoad<VSGestureInfo>(path, true);
			//return FileUtil.PerformLoad<VSGestureInfo>(path, false);
		}
	}
}
