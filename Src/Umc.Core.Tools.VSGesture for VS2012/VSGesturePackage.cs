// VsPkg.cs : Implementation of Umc_Core_Tools_VSGesture
//

using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.ComponentModel.Design;
using Microsoft.Win32;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell;

using Umc.Core.Tools.VSGesture.Services;
using Microsoft.VisualStudio;
using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Editor;
using System.Threading;
using System.Threading.Tasks;

namespace Umc.Core.Tools.VSGesture
{
    [PackageRegistration(UseManagedResourcesOnly = true)]
	//[DefaultRegistryRoot("Software\\Microsoft\\VisualStudio\\9.0")]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400, LanguageIndependentName="Umc.Core.Tools.VSGesture")]
    [ProvideLoadKey("Standard", "1.0", "Umc.Core.Tools.VSGesture", "Umc.Core", 1)]
    [ProvideMenuResource(1000, 1)]
    [Guid(GuidList.guidUmc_Core_Tools_VSGesturePkgString)]

	#region OptionPages
	[ProvideOptionPage(typeof(OptionPages.OptionPageDefault), "VSGesture", "Default", 200, 201, true)]
	[ProvideOptionPage(typeof(OptionPages.OptionPageMouseAction), "VSGesture", "Mouse Gesture", 200, 202, true)] 
	[ProvideOptionPage(typeof(OptionPages.OptionPageManual), "VSGesture", "Manual", 200, 203, true)]
	[ProvideOptionPage(typeof(OptionPages.OptionPageAbout), "VSGesture", "About", 200, 204, true)]
	#endregion

	[ProvideService(typeof(IVSGestureService), ServiceName="VSGesture Service")]
	[ProvideAutoLoad(UIContextGuids.SolutionExists)]
    public sealed class VSGesturePackage : AsyncPackage, IVsInstalledProduct
    {
        public VSGesturePackage()
        {
            Trace.WriteLine(string.Format(CultureInfo.CurrentCulture, "Entering constructor for: {0}", this.ToString()));
		}

        #region Initialize

        protected override System.Threading.Tasks.Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            Trace.WriteLine(string.Format(CultureInfo.CurrentCulture, "Entering Initialize() of: {0}", this.ToString()));
            base.Initialize();

            initMenu();

            initService();

            VSGestureService.Current.Init();

            return base.InitializeAsync(cancellationToken, progress);
        }

		private void initMenu()
		{
			OleMenuCommandService mcs = GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
			if (null != mcs)
			{
				CommandID menuCommandID = new CommandID(GuidList.guidUmc_Core_Tools_VSGestureCmdSet, (int)PkgCmdIDList.cmdidVSGesture);
				MenuCommand menuItem = new MenuCommand(MenuItemShowOptionPage, menuCommandID);
				mcs.AddCommand(menuItem);
			}
		}

		private void initService()
		{
            IServiceContainer container = this as IAsyncServiceContainer;
			if( container == null ) return;

			container.AddService(typeof(SVSGestureService),
				new AsyncServiceCreatorCallback(CreateService),
				true);
		}

		public System.Threading.Tasks.Task<object> CreateService(IAsyncServiceContainer container, Type serviceType)
		{
			if( container != this )
				return null;

			if (serviceType == typeof(SVSGestureService))
			{
                return System.Threading.Tasks.Task.FromResult<object>(new VSGestureService(this));
            }

			throw new Exception("Null Service");
		}
        #endregion

        internal void MenuItemShowOptionPage(object sender, EventArgs e)
        {
			#region
			//IVsUIShell uiShell = (IVsUIShell)GetService(typeof(SVsUIShell));
			//Guid clsid = Guid.Empty;
			//int result;
			//Microsoft.VisualStudio.ErrorHandler.ThrowOnFailure(uiShell.ShowMessageBox(
			//           0,
			//           ref clsid,
			//           "VSGesture",
			//           string.Format(CultureInfo.CurrentCulture, "Inside {0}.MenuItemCallback()", this.ToString()),
			//           string.Empty,
			//           0,
			//           OLEMSGBUTTON.OLEMSGBUTTON_OK,
			//           OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST,
			//           OLEMSGICON.OLEMSGICON_INFO,
			//           0,        // false
			//           out result)); 
			#endregion
			
			VSGestureService.Current.ShowOptionPage();
        }

		#region IVsInstalledProduct 멤버

		public int IdBmpSplash(out uint pIdBmp)
		{
			pIdBmp = 400;
			return VSConstants.S_OK;
		}

		public int IdIcoLogoForAboutbox(out uint pIdIco)
		{
			pIdIco = 400;
			return VSConstants.S_OK;
		}

		public int OfficialName(out string pbstrName)
		{
			pbstrName = GetResourceString("@110");
			return VSConstants.S_OK;
		}

		public int ProductDetails(out string pbstrProductDetails)
		{
			pbstrProductDetails = GetResourceString("@112");
			return VSConstants.S_OK;
		}

		public int ProductID(out string pbstrPID)
		{
			pbstrPID = "1.0";
			return VSConstants.S_OK;
		}

		#endregion

		public string GetResourceString(string resourceName)
		{
			string resourceValue;
			IVsResourceManager resourceManager =
				(IVsResourceManager)GetService(typeof(SVsResourceManager));
			if (resourceManager == null)
			{
				throw new InvalidOperationException(
					"Could not get SVsResourceManager service. Make sure that the package is sited before calling this method");
			}
			Guid packageGuid = this.GetType().GUID;
			int hr = resourceManager.LoadResourceString(
				ref packageGuid, -1, resourceName, out resourceValue);
			Microsoft.VisualStudio.ErrorHandler.ThrowOnFailure(hr);
			return resourceValue;
		}
	}
}