// VsPkg.cs : Implementation of Umc_Core_Tools_VSGesture
//

using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Threading;
using Umc.Core.Tools.VSGesture.Services;

namespace Umc.Core.Tools.VSGesture
{
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    //[DefaultRegistryRoot("Software\\Microsoft\\VisualStudio\\9.0")]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400, LanguageIndependentName = "Umc.Core.Tools.VSGesture")]
    [ProvideLoadKey("Standard", "1.0", "Umc.Core.Tools.VSGesture", "Umc.Core", 1)]
    [ProvideMenuResource(1000, 1)]
    [Guid(GuidList.guidUmc_Core_Tools_VSGesturePkgString)]

    #region OptionPages
    [ProvideOptionPage(typeof(OptionPages.OptionPageDefault), "VSGesture", "Default", 200, 201, true)]
    [ProvideOptionPage(typeof(OptionPages.OptionPageMouseAction), "VSGesture", "Mouse Gesture", 200, 202, true)]
    [ProvideOptionPage(typeof(OptionPages.OptionPageManual), "VSGesture", "Manual", 200, 203, true)]
    [ProvideOptionPage(typeof(OptionPages.OptionPageAbout), "VSGesture", "About", 200, 204, true)]
    #endregion

    [ProvideService(typeof(SVSGestureService), ServiceName = "VSGesture Service", IsAsyncQueryable = true)]
    [ProvideAutoLoad(UIContextGuids.SolutionExists, PackageAutoLoadFlags.BackgroundLoad)]
    public sealed class VSGestureAsyncPackage : AsyncPackage, IVsInstalledProduct
    {
        public VSGestureAsyncPackage()
        {
            Trace.WriteLine(string.Format(CultureInfo.CurrentCulture, "Entering constructor for: {0}", this.ToString()));
        }

        #region Initialize

        protected override System.Threading.Tasks.Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            Trace.WriteLine(string.Format(CultureInfo.CurrentCulture, "Entering Initialize() of: {0}", this.ToString()));
            base.InitializeAsync(cancellationToken, progress);

            initMenu();
            initService();

            return System.Threading.Tasks.Task.CompletedTask;
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
            this.AddService(typeof(SVSGestureService), new AsyncServiceCreatorCallback(CreateService), true);
        }

        public System.Threading.Tasks.Task<object> CreateService(IAsyncServiceContainer container, CancellationToken cancellationToken, Type serviceType)
        {
            if (serviceType == typeof(SVSGestureService))
            {
                return System.Threading.Tasks.Task.FromResult<object>(new VSGestureService(this));
            }

            throw new Exception("Null Service");
        }
        #endregion

        internal void MenuItemShowOptionPage(object sender, EventArgs e)
        {
            VSGestureService.Current.ShowOptionPage();
        }

        #region IVsInstalledProduct ¸â¹ö

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
            int hr = resourceManager.LoadResourceString(ref packageGuid, -1, resourceName, out resourceValue);
            Microsoft.VisualStudio.ErrorHandler.ThrowOnFailure(hr);
            return resourceValue;
        }
    }
}