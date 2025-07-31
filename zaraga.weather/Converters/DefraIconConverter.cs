using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zaraga.weather.Converters
{
    internal class DefraIconConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            string stringIndex = "";
            if (string.IsNullOrEmpty(value?.ToString()))
            {
                stringIndex = "0";
            }
            else
            {
                stringIndex = value.ToString() ?? "0";
            }
            int.TryParse(stringIndex, out int index);

            switch (index)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                    return "code_green.json";
                case 4:
                case 5:
                case 6:
                    return "code_yellow.json";
                case 7:
                case 8:
                case 9:
                    return "code_orange.json";
                case 10:
                    return "code_red.json";
                default:
                    return $"{App.NotAvailableIcon}.json"; // Icono por defecto si no se encuentra el índice
            }

        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return value;
        }
    }

    public class DefraIndexIconCode()
    {
        public int GetImageCodeByIndex(int index)
        {
            var indicatorIcons = new WeatherIndicatorIcons();
            switch (index)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                    return indicatorIcons.CodeGreen;
                case 4:
                case 5:
                case 6:
                    return indicatorIcons.CodeYellow;
                case 7:
                case 8:
                case 9:
                    return indicatorIcons.CodeOrange;
                case 10:
                    return indicatorIcons.CodeRed;
                default:
                    return 0; // Icono por defecto si no se encuentra el índice
            }
        }
    }
}
