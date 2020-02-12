using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace TimeForChorein.Utility
{
    public class ToStringConverter : IValueConverter
    {
        public object ConvertTo(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value?.ToString();
        }

        public void ConvertFrom(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value?.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value?.ToString();
        }
    }
}
