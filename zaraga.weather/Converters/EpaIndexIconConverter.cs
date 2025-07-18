using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zaraga.weather.Converters
{
    internal class EpaIndexIconConverter : IValueConverter
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
                    return "code_green.json";
                case 2:
                case 3:
                    return "code_yellow.json";
                case 4:
                    return "code_orange.json";
                case 5:
                case 6:
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
}
