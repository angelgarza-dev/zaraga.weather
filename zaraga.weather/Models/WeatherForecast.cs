using System;
using System.Collections.Generic;

namespace zaraga.weather.Models
{
    public class WeatherForecast
    {
        public WeatherLocation location { get; set; }
        public WeatherRealTime current { get; set; }
        public WeatherForecastDayly forecast { get; set; }

        public WeatherForecast()
        {
            location = new();
            current = new();
            forecast = new();
        }
    }

    public class WeatherForecastDayly
    {
        public List<WeatherForecastDaySchedule> forecastday { get; set; }

        public WeatherForecastDayly()
        {
            forecastday = new();
        }
    }

    public class WeatherForecastDaySchedule
    {
        public DateTime date { get; set; }
        public int date_epoch { get; set; }
        public WeatherForecastDay day { get; set; }
        public WeatherForecastAstro astro { get; set; }
        public WeatherAirQuality air_quality { get; set; }
        public List<WeatherForecastHour> hour { get; set; }

        public WeatherForecastDaySchedule()
        {
            date = DateTime.Now;
            date_epoch = 0;
            day = new();
            astro = new();
            air_quality = new();
            hour = new();
        }
    }
}
