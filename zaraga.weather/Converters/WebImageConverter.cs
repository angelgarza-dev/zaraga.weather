using Microsoft.Maui.Controls;
using System;
using System.Globalization;

namespace zaraga.weather.Converters
{
    public class WebImageConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            string convert = "https:" + value?.ToString()?.Replace("64x64", "128x128");
            return convert;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return "";
        }
    }
}
