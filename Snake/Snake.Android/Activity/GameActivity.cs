using Android.App;
using Android.Views;
using Cirrious.MvvmCross.Droid.Views;
using Snake.Android.Widgets;
using Snake.Core;

namespace Snake.Android
{
    [Activity]
    public class GameActivity : MvxActivity, ViewTreeObserver.IOnGlobalLayoutListener
    {
        public new GameViewModel ViewModel
        {
            get { return (GameViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }

        private GameView GamePanel
        {
            get
            {
                return this.FindViewById<GameView>(Resource.Id.GamePanel);
            }
        }

        protected override void OnViewModelSet()
        {
            this.OverridePendingTransition(Resource.Animation.activity_in, Resource.Animation.activity_out);
            base.OnViewModelSet();
            SetContentView(Resource.Layout.Layout_GameActivity);
            this.GamePanel.ViewTreeObserver.AddOnGlobalLayoutListener(this);
        }

        public void OnGlobalLayout()
        {
            int pixelSize = (int)this.Resources.GetDimension(Resource.Dimension.PixelSize);
            int borderSize = (int)Resources.GetDimension(Resource.Dimension.GameViewBorderWidth) * 2;
            this.GamePanel.Initialize(this.GamePanel.MeasuredWidth - borderSize, this.GamePanel.MeasuredHeight - borderSize);
            (this.ViewModel as GameViewModel).Initialize(new SizeF(this.GamePanel.MeasuredWidth - borderSize, this.GamePanel.MeasuredHeight - borderSize), pixelSize);
            this.GamePanel.ViewTreeObserver.RemoveGlobalOnLayoutListener(this);
        }

        public override void OnBackPressed()
        {
            (this.ViewModel as GameViewModel).PauseCommand.Execute(null);
        }

        protected override void OnStop()
        {
            base.OnStop();
            (this.ViewModel as GameViewModel).PauseCommand.Execute(null);
        }
    }
}