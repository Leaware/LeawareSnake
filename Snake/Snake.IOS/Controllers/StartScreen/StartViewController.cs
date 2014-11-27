
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Touch.Views;
using Cirrious.MvvmCross.Binding.BindingContext;
using Snake.Core;

namespace Snake.IOS
{
    public partial class StartViewController : MvxViewController
    {
        public StartViewController() : base("StartViewController", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
			
            this.NavigationController.NavigationBarHidden = true;
            this.InitializeBinding();
            this.SetupFonts();
        }

        private void InitializeBinding()
        {
            var bind = this.CreateBindingSet<StartViewController, StartViewModel>();

            bind.Bind(this.btnStart).To(x => x.StartTouchCommand);
            bind.Bind(this.vwLevelSelector).For(x => x.Hidden).To(x => x.SelectLevelHidden);
            bind.Bind(this.btnEasy).To(x => x.EasyChoicedCommand);
            bind.Bind(this.btnMedium).To(x => x.MediumChoicedCommand);
            bind.Bind(this.btnHard).To(x => x.HardChoicedCommand);

            bind.Bind(this.lblEasyValue).To(x => x.EasyMaxScore);
            bind.Bind(this.lblHighValue).To(x => x.HardMaxScore);
            bind.Bind(this.lblMediumValue).To(x => x.MediumMaxScore);

            bind.Bind(this.btnClose).To(x => x.CloseCommand);

            bind.Apply();
        }

        private void SetupFonts()
        {
            this.lblTitle.Font = UIFont.FromName("NokiaCellphoneFC-Small", 30);

            this.lblEasy.Font = UIFont.FromName("NokiaCellphoneFC-Small", 20);
            this.lblEasyValue.Font = UIFont.FromName("NokiaCellphoneFC-Small", 20);
            this.lblMedium.Font = UIFont.FromName("NokiaCellphoneFC-Small", 20);
            this.lblMediumValue.Font = UIFont.FromName("NokiaCellphoneFC-Small", 20);
            this.lblHigh.Font = UIFont.FromName("NokiaCellphoneFC-Small", 20);
            this.lblHighValue.Font = UIFont.FromName("NokiaCellphoneFC-Small", 20);

            this.btnStart.Font = UIFont.FromName("NokiaCellphoneFC-Small", 40);

            this.btnEasy.Font = UIFont.FromName("VCROSDMono", 40);
            this.btnHard.Font = UIFont.FromName("VCROSDMono", 40);
            this.btnMedium.Font = UIFont.FromName("VCROSDMono", 40);
        }
    }
}

