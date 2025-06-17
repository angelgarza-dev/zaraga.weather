namespace zaraga.weather.Models
{
    public class WeatherForecastAstro
    {
        public WeatherForecastAstro()
        {
            //location = new();
            astronomy = new();
        }

        //public WeatherLocation location { get; set; }
        public LocationAstronomy astronomy { get; set; }
    }

    public class LocationAstronomy
    {
        public LocationAstronomy()
        {
            astro = new LocationAstro();
        }

        public LocationAstro astro { get; set; }
    }

    public class LocationAstro
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
        public string? moon_phase { get; set; }
        /// <summary>
        /// Moon illumination as percentage
        /// </summary>
        public int moon_illumination { get; set; }
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
