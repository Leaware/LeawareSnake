using System;

using Android.App;
using Android.Widget;
using Android.Content;
using Android.Util;
using Android.Runtime;
using System.Collections.Generic;
using Android.Graphics;
using Cirrious.MvvmCross.Binding.Droid.Views;

namespace Snake.Android.Widgets
{
    public class GameView : ImageView
    {
        private AndroidChartPlotter plotter;

        public GameView(Context context)
            : base(context)
        {            
        }

        public GameView(Context context, IAttributeSet attrs) :
            base(context, attrs)
        {
        }

        public GameView(IntPtr ptr, JniHandleOwnership handleOnwerShip)
            : base(ptr, handleOnwerShip)
        {
        }

        public GameView(Context context, IAttributeSet attrs, int defstyle) :
            base(context, attrs, defstyle)
        {            
        }        

        public void Initialize(int plotterWidth, int plotterHeight)
        {            
            this.plotter = new AndroidChartPlotter(plotterWidth, plotterHeight);  
        }

        public void Draw(List<Snake.Core.RectangleF> shapes)
        {                
            Bitmap bitmap = this.plotter.Draw(shapes);
            this.SetScaleType(ImageView.ScaleType.CenterInside);   
            this.SetImageBitmap(bitmap);
        }
       
    }
}