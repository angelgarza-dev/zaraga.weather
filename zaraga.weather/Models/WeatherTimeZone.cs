namespace zaraga.weather.Models
{
    internal class WeatherTimeZone
    {
        public string? tz_id { get; set; }
        public int localtime_epoch { get; set; }
        public string? localtime { get; set; }
    }
}
