#region Using

using Cirrious.MvvmCross.WindowsCommon.Views;
using Snake.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Phone.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

#endregion

namespace Snake
{
    public sealed partial class GameView : MvxWindowsPage
    {
        #region Fields

        private bool isInitialized;

        #endregion

        #region Properties

        public new GameViewModel ViewModel
        {
            get { return (GameViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }

        #endregion

        #region Constructors

        public GameView()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Methods [protected]

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            HardwareButtons.BackPressed += this.HardwareButtonsBackPressed;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            HardwareButtons.BackPressed -= this.HardwareButtonsBackPressed;
        }

        #endregion

        #region Methods [private]

        private void HardwareButtonsBackPressed(object sender, BackPressedEventArgs e)
        {
            e.Handled = true;
            this.ViewModel.PauseCommand.Execute(null);
        }

        private void PauseButtonSizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (!this.isInitialized && this.PauseButton.ActualWidth > 0)
            {
                this.ViewModel.Initialize(new SizeF((float)this.CanvasControl.ActualWidth, 
                    (float)this.CanvasControl.ActualHeight), 10);

                this.isInitialized = true;
            }
        }

        #endregion
    }
}
