#region "Using"
using System;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using MonoTouch.UIKit;
using MonoTouch.Foundation;
using MonoTouch.CoreGraphics;
using MonoTouch.CoreText;
using System.Text;


#endregion

namespace Snake.IOS
{
    public class IOSChartPlotter 
	{
		#region "Members"
		private SizeF contextSize;
		#endregion

		#region "Constructors"
        public IOSChartPlotter(SizeF size)
		{
            this.contextSize = size;
		}
		#endregion

		#region IChartPlotter implementation
        public void DrawRect(Snake.Core.RectangleF rect)
        {
            UIColor color = UIColor.FromRGB(0,0, 0);

            UIGraphics.GetCurrentContext().SetFillColor(color.CGColor);
            UIGraphics.GetCurrentContext().FillRect(new RectangleF(rect.X, rect.Y, rect.Width, rect.Height));
        }
		#endregion

		#region "Drawing"
		/// <summary>
		/// Metoda odwzorowuje kształty na grafice.
		/// </summary>
		/// <param name="shapes">lista kształtów</param>
        public UIImage Draw(List<Snake.Core.RectangleF> shapes)
		{
			UIImage chartImage;

            UIGraphics.BeginImageContextWithOptions(new SizeF(this.contextSize.Width, this.contextSize.Height), true, UIScreen.MainScreen.Scale);

            UIGraphics.GetCurrentContext().TranslateCTM(0, this.contextSize.Height);
			UIGraphics.GetCurrentContext().ScaleCTM(1.0f, -1.0f);
           
            UIColor color = UIColor.FromRGB(160, 200, 120);

            UIGraphics.GetCurrentContext().SetFillColor(color.CGColor);
            UIGraphics.GetCurrentContext().FillRect(new RectangleF(0, 0, this.contextSize.Width, this.contextSize.Height));


            foreach (Snake.Core.RectangleF shape in shapes) 
			{
                    this.DrawRect(shape); 
			}

			chartImage = UIGraphics.GetImageFromCurrentImageContext();

			UIGraphics.EndImageContext();

			return chartImage;
		}
		#endregion
	}
}