using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zaraga.weather.Converters
{
    internal class WindDirConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            string? windRose = value?.ToString();
            return windRose switch
            {
                "N" => "Norte",
                "NNE" => "Norte-Nordeste",
                "NE" => "Nordeste",
                "ENE" => "Este-Nordeste",
                "E" => "Este",
                "ESE" => "Este-Sudeste",
                "SE" => "Sudeste",
                "SSE" => "Sur-Sudeste",
                "S" => "Sur",
                "SSW" => "Sur-Sudoeste",
                "SW" => "Sudoeste",
                "WSW" => "Oeste-Sudoeste",
                "W" => "Oeste",
                "WNW" => "Oeste-Noroeste",
                "NW" => "Noroeste",
                "NNW" => "Norte-Noroeste",
                _ => windRose,
            };
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
