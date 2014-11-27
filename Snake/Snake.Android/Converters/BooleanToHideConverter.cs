using Android.Views;
using Cirrious.CrossCore.Converters;
using System;

namespace Snake.Android
{
    public sealed class BooleanToHideConverter : IMvxValueConverter
    {
        #region Methods [public]

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (value is bool && (bool)value) ? global::Android.Views.ViewStates.Gone : global::Android.Views.ViewStates.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value is global::Android.Views.ViewStates && (global::Android.Views.ViewStates)value == global::Android.Views.ViewStates.Gone;
        }

        #endregion
    }
}