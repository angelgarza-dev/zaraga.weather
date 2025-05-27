using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zaraga.weather.Models
{
    internal class WeatherError
    {
        public int code { get; set; }
        public string? message { get; set; }
    }
}
