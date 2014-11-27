using System;
using Cirrious.MvvmCross.Touch.Platform;
using Cirrious.MvvmCross.Touch.Views.Presenters;
using Cirrious.MvvmCross.Binding.Bindings.Target.Construction;
using Cirrious.CrossCore;
using Snake.Core;

namespace Snake.IOS
{
    public class Setup : MvxTouchSetup
    {
        public Setup(MvxApplicationDelegate delegat, IMvxTouchViewPresenter presenter)
            :base(delegat, presenter)
        {
        }

        protected override Cirrious.MvvmCross.ViewModels.IMvxApplication CreateApp()
        {
            return new Snake.Core.App();
        }

        protected override void InitializePlatformServices()
        {
            base.InitializePlatformServices();
            Mvx.RegisterType<ITimer,Timer>();
        }

        protected override void FillTargetFactories(Cirrious.MvvmCross.Binding.Bindings.Target.Construction.IMvxTargetBindingFactoryRegistry registry)
        {
            registry.RegisterCustomBindingFactory<GamePanel>("Shapes", binary=> 
            {
                return new GameViewBinding(binary);
            });
            base.FillTargetFactories(registry);
        }

        protected override Cirrious.CrossCore.Platform.IMvxTrace CreateDebugTrace()
        {
            return new MvxDebugTrace();
        }
    }
}

