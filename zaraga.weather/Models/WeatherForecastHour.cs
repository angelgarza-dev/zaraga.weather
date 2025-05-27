namespace zaraga.weather.Models
{
    internal class WeatherForecastHour
    {
        public int time_epoch { get; set; }
        public string? time { get; set; }
        public decimal temp_c { get; set; }
        public decimal temp_F { get; set; }
        /// <summary>
        /// condition:text
        /// </summary>
        public string? conditionText { get; set; }
        /// <summary>
        /// condition:icon
        /// </summary>
        public string? conditionIcon { get; set; }
        /// <summary>
        /// condition:code
        /// </summary>
        public int conditionCode { get; set; }
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

    }
}
