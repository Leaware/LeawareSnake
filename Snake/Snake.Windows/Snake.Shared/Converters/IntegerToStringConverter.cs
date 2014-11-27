#region Using

using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

#endregion

namespace Snake.Converters
{
    public sealed class IntegerToStringConverter : IValueConverter
    {
        #region Methods [public]

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return ((int)value).ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}