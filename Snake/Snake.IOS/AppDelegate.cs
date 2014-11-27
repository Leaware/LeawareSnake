using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Touch.Views.Presenters;
using Cirrious.MvvmCross.Touch.Platform;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.ViewModels;
using System.Drawing;

namespace Snake.IOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : MvxApplicationDelegate
    {
        // class-level declarations
        public override UIWindow Window
        {
            get; 
            set;
        }

        //
        // This method is invoked when the application has loaded and is ready to run. In this
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            this.Window = new UIWindow(new RectangleF(0, 0, UIScreen.MainScreen.Bounds.Width, UIScreen.MainScreen.Bounds.Height));

            var presenter = new MvxTouchViewPresenter(this, this.Window);
            var setup = new Setup(this,presenter);
            setup.Initialize();

            var startUp = Mvx.Resolve<IMvxAppStart>();
            startUp.Start();

            this.Window.MakeKeyAndVisible();
			
            return true;
        }
    }
}

