namespace zaraga.weather.Models
{
    internal class WeatherForecastAstro
    {
        public string? sunrise { get; set; }
        public string? sunset { get; set; }
        public string? moonrise { get; set; }
        public string? moonset { get; set; }
        /// <summary>
        /// New Moon
        /// Waxing Crescent
        /// First Quarter
        /// Waxing Gibbous
        /// Full Moon
        /// Waning Gibbous
        /// Last Quarter
        /// Waning Crescent
        /// </summary>
        public decimal moon_phase { get; set; }
        /// <summary>
        /// Moon illumination as percentage
        /// </summary>
        public string? moon_illumination { get; set; }
        /// <summary>
        /// 1 = Yes 
        /// 0 = No
        /// </summary>
        public int is_moon_up { get; set; }
        /// <summary>
        /// 1 = Yes 
        /// 0 = No
        /// </summary>
        public int is_sun_up { get; set; }
    }

}
