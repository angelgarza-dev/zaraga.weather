namespace zaraga.weather.Models
{
    internal class WeatherIpLookup
    {
        public string? ip { get; set; }
        public string? type { get; set; }
        public string? continent_code { get; set; }
        public string? continent_name { get; set; }
        public string? country_code { get; set; }
        public string? country_name { get; set; }
        public bool is_eu { get; set; }
        public string? geoname_id { get; set; }
        public string? city { get; set; }
        public string? region { get; set; }
        public decimal lat { get; set; }
        public decimal lon { get; set; }
        public string? tz_id { get; set; }
    }
}
