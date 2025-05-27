namespace zaraga.weather.Models
{
    internal class WeatherForecast
    {
        public string? date { get; set; }
        public int date_epoch { get; set; }
        public WeatherForecastDay? day { get; set; }
        public WeatherForecastAstro? astro { get; set; }
        public WeatherAirQuality? air_quality { get; set; }
        public WeatherForecastHour? hour { get; set; }
    }
}
