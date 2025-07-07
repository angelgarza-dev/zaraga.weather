namespace zaraga.weather.Models
{
    public class WeatherForecastDay
    {
        public decimal maxtemp_c { get; set; }
        public decimal maxtemp_f { get; set; }
        public decimal mintemp_c { get; set; }
        public decimal mintemp_f { get; set; }
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
        public WeatherCondition condition { get; set; }
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

        public WeatherForecastDay()
        {
            maxtemp_c = 0.0m;
            maxtemp_f = 0.0m;
            mintemp_c = 0.0m;
            mintemp_f = 0.0m;
            avgtemp_c = 0.0m;
            avgtemp_f = 0.0m;
            maxwind_kph = 0.0m;
            maxwind_mph = 0.0m;
            totalprecip_mm = 0.0m;
            totalprecip_in = 0.0m;
            totalsnow_cm = 0.0m;
            avgvis_km = 0.0m;
            avgvis_miles = 0.0m;
            avghumidity = 0;
            condition = new();
            uv = 0.0m;
            daily_will_it_rain = 0;
            daily_will_it_snow = 0;
            daily_chance_of_rain = 0;
            daily_chance_of_snow = 0;
        }
    }

}
