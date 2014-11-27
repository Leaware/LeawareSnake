using Android.Content;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.Binding.Bindings.Target.Construction;
using Cirrious.MvvmCross.Droid.Platform;
using Cirrious.MvvmCross.ViewModels;
using Snake.Android.Widgets;
using Snake.Core;

namespace Snake.Android
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) 
            : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }

        protected override void InitializePlatformServices()
        {
            base.InitializePlatformServices();
            Mvx.RegisterType<ITimer, Timer>();
        }

        protected override void FillAxmlViewTypeResolver(Cirrious.MvvmCross.Binding.Droid.Binders.ViewTypeResolvers.IMvxAxmlNameViewTypeResolver viewTypeResolver)
        {
            base.FillAxmlViewTypeResolver(viewTypeResolver);
        }

        protected override void FillTargetFactories(Cirrious.MvvmCross.Binding.Bindings.Target.Construction.IMvxTargetBindingFactoryRegistry registry)
        {
            base.FillTargetFactories(registry);
            registry.RegisterFactory(new MvxCustomBindingFactory<GameView>("Shapes", view => new GameViewBinding(view)));
        }
		
        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }
    }
}