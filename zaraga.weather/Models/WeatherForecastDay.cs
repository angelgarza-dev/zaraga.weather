namespace zaraga.weather.Models
{
    internal class WeatherForecastDay
    {
        public decimal max_temp_c { get; set; }
        public decimal max_temp_f { get; set; }
        public decimal min_temp_c { get; set; }
        public decimal min_temp_f { get; set; }
        public decimal avgtemp_c { get; set; }
        public decimal avgtemp_f { get; set; }
        public decimal maxwind_kph { get; set; }
        public decimal maxwind_mph { get; set; }
        public decimal totalprecip_mm { get; set; }
        public decimal totalprecip_in { get; set; }
        public decimal totalsnow_cm { get; set; }
        public decimal avgvis_km { get; set; }
        public decimal avgvis_miles { get; set; }
        public int avghumidity { get; set; }
        public WeatherCondition? condition { get; set; }
        public decimal uv { get; set; }
        /// <summary>
        /// 1 = Yes 
        /// 0 = No
        /// </summary>
        public int daily_will_it_rain { get; set; }
        /// <summary>
        /// 1 = Yes 
        /// 0 = No
        /// </summary>
        public int daily_will_it_snow { get; set; }
        /// <summary>
        /// Chance of rain as percentage
        /// </summary>
        public int daily_chance_of_rain { get; set; }
        /// <summary>
        /// Chance of snow as percentage
        /// </summary>
        public int daily_chance_of_snow { get; set; }
    }

}
