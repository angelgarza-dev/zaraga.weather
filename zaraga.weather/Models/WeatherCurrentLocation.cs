namespace zaraga.weather.Models
{
    public class WeatherCurrentLocation
    {
        public WeatherLocation? location { get; set; }
        public WeatherRealTime? current { get; set; }
        
        public WeatherCurrentLocation()
        {
            location = new();
            current = new();
        }
    }
}
