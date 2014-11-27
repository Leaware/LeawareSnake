using Android.App;
using Cirrious.MvvmCross.Droid.Views;
using Cirrious.MvvmCross.ViewModels;
using Snake.Core;

namespace Snake.Android
{
    [Activity]
    public class StartActivity : MvxActivity
    {
        public new StartViewModel ViewModel
        {
            get { return (StartViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }

        protected override void OnViewModelSet()
        {
            this.RequestedOrientation = global::Android.Content.PM.ScreenOrientation.Landscape;
            this.OverridePendingTransition(Resource.Animation.activity_in, Resource.Animation.activity_out);
            base.OnViewModelSet();            
            SetContentView(Resource.Layout.Layout_StartActivity);
        }

        protected override void OnPause()
        {
            this.OverridePendingTransition(Resource.Animation.activity_in_back, Resource.Animation.activity_out_back);
            base.OnPause();
        }

        public override void OnBackPressed()
        {            
            this.MoveTaskToBack(true);
        }
    }
}