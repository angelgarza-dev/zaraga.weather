namespace zaraga.weather.Models
{
    internal class WeatherSports
    {
        public string? stadium { get; set; }
        public int country { get; set; }
        public string? region { get; set; }
        public string? tournament { get; set; }
        /// <summary>
        /// Start local date and time for event in yyyy-MM-dd HH:mm format
        /// </summary>
        public string? start { get; set; }
        public string? match { get; set; }
    }
}
