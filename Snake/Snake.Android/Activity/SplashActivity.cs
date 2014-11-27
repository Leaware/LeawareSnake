using System;

using Android.App;
using Android.OS;
using System.Threading.Tasks;
using Java.Lang;

namespace Snake.Android
{
    [Activity]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            this.RequestedOrientation = global::Android.Content.PM.ScreenOrientation.Portrait;
            this.OverridePendingTransition(Resource.Animation.activity_in, Resource.Animation.activity_out);
            base.OnCreate(bundle);            
            this.SetContentView(Resource.Layout.Layout_SplashActivity);
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(2000);

                RunOnUiThread(() =>
                {
                    this.StartActivity(typeof(StartActivity));
                });
            });

        }

        protected override void OnPause()
        {
            OverridePendingTransition(Resource.Animation.activity_in_back, Resource.Animation.activity_out_back);
            base.OnPause();            
        }
    }
}