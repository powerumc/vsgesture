using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Configuration.Install;

namespace Umc.Core.Tools.VSGesture
{
	[System.ComponentModel.RunInstaller(true)]
	public class VSExplorerInstaller : Installer
	{
		protected override void OnAfterInstall(System.Collections.IDictionary savedState)
		{
			base.OnAfterInstall(savedState);
			setupVS();
		}

		protected override void  OnAfterUninstall(System.Collections.IDictionary savedState)
		{
			base.OnAfterUninstall(savedState);
			setupVS();
		}

		private static void setupVS()
		{
			try { string path = System.Environment.GetEnvironmentVariable("VS80COMNTOOLS") + @"..\IDE\devenv.exe"; Process.Start(path, "/setup").WaitForExit(); }
			catch { }

			try { string path = System.Environment.GetEnvironmentVariable("VS90COMNTOOLS") + @"..\IDE\devenv.exe"; Process.Start(path, "/setup /nosetupvstemplates").WaitForExit(); }
			catch { }
		}
	}
}
