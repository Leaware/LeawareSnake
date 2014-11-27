#region Using

using Cirrious.CrossCore;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.WindowsCommon.Platform;
using Snake.Core;
using Windows.UI.Xaml.Controls;

#endregion

namespace Snake
{
    public class Setup : MvxWindowsSetup
    {
        public Setup(Frame rootFrame) : base(rootFrame)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new Snake.Core.App();
        }

        protected override void InitializePlatformServices()
        {
            base.InitializePlatformServices();
            Mvx.RegisterType<ITimer, Timer>();
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new MvxDebugTrace();
        }
    }
}