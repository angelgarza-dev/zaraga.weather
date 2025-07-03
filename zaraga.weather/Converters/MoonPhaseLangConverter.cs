using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zaraga.weather.Converters
{
    internal class MoonPhaseLangConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            string? moonPhaseEng = value?.ToString();
            return moonPhaseEng switch
            {
                "New Moon" => "Luna Nueva",
                "Waxing Crescent" => "Luna Creciente",
                "First Quarter" => "Cuarto Creciente",
                "Waxing Gibbous" => "Gibosa Creciente",
                "Full Moon" => "Luna Llena",
                "Waning Gibbous" => "Gibosa Menguante",
                "Last Quarter" => "Cuarto Menguante",
                "Waning Crescent" => "Luna Menguante",
                _ => moonPhaseEng,
            };
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
