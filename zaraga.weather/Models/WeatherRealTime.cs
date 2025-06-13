using System;

namespace zaraga.weather.Models
{
    public class WeatherRealTime
    {
        /// <summary>
        /// Hora local de la ultima actualización de los datos en tiempo real
        /// </summary>
        public DateTime? last_updated { get; set; }
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
        public WeatherCondition? condition { get; set; }
        public decimal wind_mph { get; set; }
        public decimal wind_kph { get; set; }
        public int wind_degree { get; set; }
        public string? wind_dir { get; set; }
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

        public WeatherRealTime()
        {
            condition = new WeatherCondition();
        }
    }
}
