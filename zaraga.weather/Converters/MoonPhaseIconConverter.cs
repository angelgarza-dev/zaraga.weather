using Microsoft.Maui.Controls;
using System;
using System.Globalization;

namespace zaraga.weather.Converters
{
    internal class MoonPhaseIconConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            string? moonPhaseEng = value?.ToString();
            return moonPhaseEng switch
            {
                "New Moon" => "moon_new.json",
                "Waxing Crescent" => "moon_waxing_crescent.json",
                "First Quarter" => "moon_first_quarter.json",
                "Waxing Gibbous" => "moon_waxing_gibbous.json",
                "Full Moon" => "moon_full.json",
                "Waning Gibbous" => "moon_waning_gibbous.json",
                "Last Quarter" => "moon_last_quarter.json",
                "Waning Crescent" => "moon_waning_crescent.json",
                _ => "na.json",
            };
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return value;
        }
    }

    internal class MoonPhaseIconCode
    {
        internal int GetImageCodeByPhase(string? moonPhaseEng)
        {
            var indicatorIcons = new WeatherIndicatorIcons();
            return moonPhaseEng switch
            {
                "New Moon" => indicatorIcons.MoonNew,
                "Waxing Crescent" => indicatorIcons.MoonWaxingCrescent,
                "First Quarter" => indicatorIcons.MoonFirstQuarter,
                "Waxing Gibbous" => indicatorIcons.MoonWaxingGibbous,
                "Full Moon" => indicatorIcons.MoonFull,
                "Waning Gibbous" => indicatorIcons.MoonWaningGibbous,
                "Last Quarter" => indicatorIcons.MoonLastQuarter,
                "Waning Crescent" => indicatorIcons.MoonWaningCrescent,
                _ => 0,
            };
        }
    }
}
