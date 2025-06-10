using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zaraga.weather.Services;

namespace zaraga.weather.Converters
{
    internal class IconCodeConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (int.TryParse(value?.ToString(), out int code) == true)
            {
                return WeatherCodes.GetWeatherImageByCode(code);
            }
            return App.NotAvailableIcon; // or a default image if you prefer
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return App.NotAvailableIcon;
        }
    }
}
