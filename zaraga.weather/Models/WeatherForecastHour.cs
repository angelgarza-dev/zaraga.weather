using System;

namespace zaraga.weather.Models
{
    public class WeatherForecastHour
    {
        public int time_epoch { get; set; }
        public DateTime time { get; set; }
        public decimal temp_c { get; set; }
        public decimal temp_F { get; set; }
        public WeatherCondition condition { get; set; }
        public decimal wind_mph { get; set; }
        public decimal wind_kph { get; set; }
        public int wind_degree { get; set; }
        public string? wind_dir { get; set; }
        public decimal pressure_mb { get; set; }
        public decimal pressure_in { get; set; }
        public decimal precip_mm { get; set; }
        public decimal precip_in { get; set; }
        public decimal snow_cm { get; set; }
        /// <summary>
        /// Humidity as percentage
        /// </summary>
        public int humidity { get; set; }
        /// <summary>
        /// Cloud cover as percentage
        /// </summary>
        public int cloud { get; set; }
        public decimal feelslike_c { get; set; }
        public decimal feelslike_f { get; set; }
        public decimal windchill_c { get; set; }
        public decimal windchill_f { get; set; }
        public decimal heatindex_c { get; set; }
        public decimal heatindex_f { get; set; }
        public decimal dewpoint_c { get; set; }
        public decimal dewpoint_f { get; set; }
        /// <summary>
        /// 1 = Yes 
        /// 0 = No
        /// </summary>
        public int will_it_rain { get; set; }
        /// <summary>
        /// 1 = Yes 
        /// 0 = No
        /// </summary>
        public int will_it_snow { get; set; }
        /// <summary>
        /// 1 = Yes 
        /// 0 = No
        /// </summary>
        public int is_day { get; set; }
        public decimal vis_km { get; set; }
        public decimal vis_miles { get; set; }
        public int chance_of_rain { get; set; }
        public int chance_of_snow { get; set; }
        public decimal gust_mph { get; set; }
        public decimal gust_kph { get; set; }
        public decimal uv { get; set; }
        /// <summary>
        /// Shortwave solar radiation or Global horizontal irradiation (GHI) W/m²
        /// </summary>
        public decimal short_rad { get; set; }
        public decimal diff_rad { get; set; }
        public WeatherAirQuality? air_quality { get; set; }

        public WeatherForecastHour()
        {
            time_epoch = 0;
            time = DateTime.Now;
            temp_c = 0;
            temp_F = 0;
            condition = new();
            wind_mph = 0;
            wind_kph = 0;
            wind_degree = 0;
            wind_dir = "";
            pressure_mb = 0;
            pressure_in = 0;
            precip_mm = 0;
            precip_in = 0;
            snow_cm = 0;
            humidity = 0;
            cloud = 0;
            feelslike_c = 0;
            feelslike_f = 0;
            windchill_c = 0;
            windchill_f = 0;
            heatindex_c = 0;
            heatindex_f = 0;
            dewpoint_c = 0;
            dewpoint_f = 0;
            will_it_rain = 0;
            will_it_snow = 0;
            is_day = 0;
            vis_km = 0;
            vis_miles = 0;
            chance_of_rain = 0;
            chance_of_snow = 0;
            gust_mph = 0;
            gust_kph = 0;
            uv = 0;
            short_rad = 0;
            diff_rad = 0;
            air_quality = new();
        }
    }
}
