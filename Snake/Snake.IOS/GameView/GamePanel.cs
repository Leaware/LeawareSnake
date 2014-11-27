using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using System.Drawing;
using System.Collections.Generic;

namespace Snake.IOS
{
    [Register("GamePanel")]
    public partial class GamePanel : UIView
    {
        public GamePanel(IntPtr handler) :base(handler)
        {
        }

        public GamePanel(RectangleF handler) :base(handler)
        {
            this.AwakeFromNib();
        }

        public GamePanel():base()
        {

        }

        public override void AwakeFromNib ()
        {
            base.AwakeFromNib ();

           
            NSArray nibObjects = NSBundle.MainBundle.LoadNib("GamePanel", this, null);

            GamePanel instantiatedView = new GamePanel(nibObjects.ValueAt(0));
            instantiatedView.Frame = new RectangleF(0, 0, this.Frame.Width, this.Frame.Height);
            this.AddSubview(instantiatedView);
        }

        public void Draw(List<Snake.Core.RectangleF> shapes)
        {
            IOSChartPlotter plotter = new IOSChartPlotter(new SizeF(Math.Max(this.Frame.Height, this.Frame.Width), Math.Min(this.Frame.Height, this.Frame.Width)));
            UIImage image =  plotter.Draw(shapes);

            this.imgPanel.Image = image;
        }
    }
}

