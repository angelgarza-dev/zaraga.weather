using System;

namespace zaraga.weather.Models
{
    public class WeatherRealTime
    {
        /// <summary>
        /// Hora local de la ultima actualización de los datos en tiempo real
        /// </summary>
        public DateTime last_updated { get; set; }
        /// <summary>
        /// Hora local de la ultima actualización de los datos en horario Unix
        /// </summary>
        public int last_updated_epoch { get; set; }
        public decimal temp_c { get; set; }
        public decimal temp_f { get; set; }
        public decimal feelslike_c { get; set; }
        public decimal feelslike_f { get; set; }
        public decimal windchill_c { get; set; }
        public decimal windchill_f { get; set; }
        public decimal heatindex_c { get; set; }
        public decimal heatindex_f { get; set; }
        public decimal dewpoint_c { get; set; }
        public decimal dewpoint_f { get; set; }
        public WeatherCondition condition { get; set; }
        public decimal wind_mph { get; set; }
        public decimal wind_kph { get; set; }
        public int wind_degree { get; set; }
        public string wind_dir { get; set; }
        /// <summary>
        /// Presión en milibares
        /// </summary>
        public decimal pressure_mb { get; set; }
        /// <summary>
        /// Presión en pulgadas
        /// </summary>
        public decimal pressure_in { get; set; }
        public decimal precip_mm { get; set; }
        public decimal precip_in { get; set; }
        public int humidity { get; set; }
        public int cloud { get; set; }
        /// <summary>
        /// 1 = Yes 
        /// 0 = No
        /// </summary>
        public int is_day { get; set; }
        public decimal uv { get; set; }
        public decimal gust_mph { get; set; }
        public decimal gust_kph { get; set; }

        public WeatherAirQuality air_quality { get; set; }

        public WeatherRealTime()
        {
            last_updated = DateTime.Now;
            last_updated_epoch = 0;
            temp_c = 0;
            temp_f = 0;
            feelslike_c = 0;
            feelslike_f = 0;
            windchill_c = 0;
            windchill_f = 0;
            heatindex_c = 0;
            heatindex_f = 0;
            dewpoint_c = 0;
            dewpoint_f = 0;
            condition = new();
            wind_mph = 0;
            wind_kph = 0;
            wind_degree = 0;
            wind_dir = "";
            pressure_mb = 0;
            pressure_in = 0;
            precip_mm = 0;
            precip_in = 0;
            humidity = 0;
            cloud = 0;
            is_day = 0;
            uv = 0;
            gust_mph = 0;
            gust_kph = 0;
            air_quality = new WeatherAirQuality();
        }
    }
}
