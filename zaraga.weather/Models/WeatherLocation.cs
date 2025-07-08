using System;

namespace zaraga.weather.Models
{
    public class WeatherLocation
    {
        public int id { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
        public string name { get; set; }
        public string region { get; set; }
        public string country { get; set; }
        public string tz_id { get; set; }
        public int localtime_epoch { get; set; }
        public DateTime localtime { get; set; }

        public WeatherLocation()
        {
            lat = 0;
            lon = 0;
            name = "";
            region = "";
            country = "";
            tz_id = "";
            localtime_epoch = 0;
            localtime = DateTime.Now;
        }
    }
}
