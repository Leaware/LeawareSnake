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
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

#endregion

namespace Snake
{
    public sealed partial class StartView : MvxWindowsPage
    {
        #region Properties

        public new StartViewModel ViewModel
        {
            get { return (StartViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }

        #endregion

        #region Constructors

        public StartView()
        {
            this.InitializeComponent();
            this.Inititalize();
        }

        #endregion

        #region Methods [private]

        private async void Inititalize()
        {          
            DisplayInformation.AutoRotationPreferences = DisplayOrientations.Landscape;

            await StatusBar.GetForCurrentView().HideAsync();
        }

        #endregion
    }
}
