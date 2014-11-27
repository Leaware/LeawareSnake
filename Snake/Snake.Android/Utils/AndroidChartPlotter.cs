using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using System.Drawing;
using Android.Util;

namespace Snake.Android
{
    public class AndroidChartPlotter
    {
        private Canvas canvas;
        private Bitmap bitmap;
        private int width;
        private int height;

        public AndroidChartPlotter(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public void DrawRect(Snake.Core.RectangleF rect)
        {
            Paint shapepaint = new Paint();
            shapepaint.Color = global::Android.Graphics.Color.Black;
            canvas.DrawRect(rect.X, this.height - (rect.Y + rect.Height), 
                rect.X + rect.Width, this.height - rect.Y, shapepaint);
        }

        public Bitmap Draw(List<Snake.Core.RectangleF> shapes)
        {
            if (bitmap != null)
            {
                bitmap.Dispose();
                bitmap = null;
                canvas.Dispose();
                canvas = null;
            }
            this.bitmap = Bitmap.CreateBitmap((int)this.width, (int)this.height, Bitmap.Config.Argb8888);
            this.canvas = new Canvas(bitmap);
            foreach (Snake.Core.RectangleF shape in shapes)
            {
                this.DrawRect(shape);
            }

            return bitmap;
        }
    }
    
}