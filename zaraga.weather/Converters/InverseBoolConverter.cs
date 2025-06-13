using Microsoft.Maui.Controls;
using System;
using System.Globalization;

namespace zaraga.weather.Converters
{
    public class InverseBoolConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value == null || targetType != typeof(bool))
            {
                return false;
            }
            return !(bool)value;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
