
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Touch.Views;
using System.Timers;
using Snake.Core;
using Cirrious.MvvmCross.Binding.BindingContext;

namespace Snake.IOS
{
    public partial class GameViewController : MvxViewController
    {
        public GameViewController() : base("GameViewController", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            this.NavigationController.NavigationBarHidden = true;
            this.InitializeBinding();

            this.SetupFonts();
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            (this.ViewModel as GameViewModel).Initialize(new Snake.Core.SizeF(Math.Max(this.Panel.Frame.Width, this.Panel.Frame.Height), Math.Min(this.Panel.Frame.Width, this.Panel.Frame.Height)), 10);
        }
           
        #region Methods
        private void SetupFonts()
        {
            this.lblLevel.Font = UIFont.FromName("VCROSDMono", 16);
            this.lblScore.Font = UIFont.FromName("VCROSDMono", 16);

            this.lblTiles[0].Font = UIFont.FromName("VCROSDMono", 16);
            this.lblTiles[1].Font = UIFont.FromName("VCROSDMono", 16);

            this.btnRestart.Font = UIFont.FromName("VCROSDMono", 40);
            this.btnQuit.Font = UIFont.FromName("VCROSDMono", 40);

            this.btnClose.Font = UIFont.FromName("NokiaCellphoneFC-Small", 25);
        }

        private void InitializeBinding()
        {
            var bind = this.CreateBindingSet<GameViewController, GameViewModel>();

            bind.Bind(this.Panel).For("Shapes").To(x => x.Shapes);
            bind.Bind(this.lblScore).To(x => x.Points);
            bind.Bind(this.lblLevel).To(x => x.Level);
            bind.Bind(this.btnTop).To(x => x.TopTouchCommand);
            bind.Bind(this.btnRight).To(x => x.RightTouchCommand);
            bind.Bind(this.btnLeft).To(x => x.LeftTouchCommand);
            bind.Bind(this.btnBottom).To(x => x.BottomTouchCommand);
            bind.Bind(this.btnRestart).To(x => x.RestartCommand);
            bind.Bind(this.vwFinishDialog).For(x => x.Hidden).To(x => x.FinishDialogHidden);
            bind.Bind(this.btnPause).To(x => x.PauseCommand);
            bind.Bind(this.btnQuit).To(x => x.QuitCommand);
            bind.Bind(this.btnClose).To(x => x.CloseCommand);
            bind.Apply();
        }
        #endregion

        #region Actions
        partial void OnCloseApp(NSObject sender)
        {
            (this.ViewModel as GameViewModel).SaveScore();
            System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow(); 
        }
        #endregion
    }
}

