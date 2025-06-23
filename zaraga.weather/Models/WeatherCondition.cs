namespace zaraga.weather.Models
{
    public class WeatherCondition
    {
        public int code { get; set; }
        public string? text { get; set; }
        public string? icon { get; set; }

        public WeatherCondition()
        {
            code = 0;
            text = string.Empty;
            icon = string.Empty;
        }
    }
}
