#region Using

using Snake.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

#endregion

namespace Snake.Controls
{
    public sealed partial class CanvasControl : UserControl
    {
        #region Properties

        public static readonly DependencyProperty ChildrenListProperty = 
            DependencyProperty.Register("ChildrenList", typeof(List<RectangleF>), 
            typeof(CanvasControl), new PropertyMetadata(null, ChildrenChanged));

        public List<RectangleF> ChildrenList
        {
            get
            {
                return (List<RectangleF>)GetValue(ChildrenListProperty);
            }

            set
            {
                SetValue(ChildrenListProperty, value);
            }
        }

        #endregion

        #region Constructor

        public CanvasControl()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Methods [private]

        private static void ChildrenChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            CanvasControl canvasControl = (CanvasControl)sender;

            if (canvasControl.ChildrenList != null)
            {
                List<RectangleF> rects = e.NewValue as List<RectangleF>;
                canvasControl.CanvasContent.Children.Clear();

                foreach (var rect in rects)
                {
                    Rectangle uiRect = new Rectangle();
                    uiRect.Margin = new Thickness(rect.Position.X,
                        canvasControl.ActualHeight - (rect.Position.Y + rect.Height),
                        rect.Position.X + rect.Width,
                        canvasControl.ActualHeight - rect.Position.Y);
                    uiRect.Width = rect.Width;
                    uiRect.Height = rect.Height;
                    uiRect.Fill = new SolidColorBrush(Colors.Black);

                    canvasControl.CanvasContent.Children.Add(uiRect);
                }
            }
        }

        #endregion
    }
}
