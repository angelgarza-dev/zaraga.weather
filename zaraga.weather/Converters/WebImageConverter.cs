using Microsoft.Maui.Controls;
using System;
using System.Globalization;

namespace zaraga.weather.Converters
{
    public class WebImageConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {

            return "https:" + value?.ToString();
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return "";
        }
    }
}
