using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zaraga.weather.Models
{
    internal class WeatherAlert
    {
        public string? headline { get; set; }
        public string? msgType { get; set; }
        public string? severity { get; set; }
        public string? urgency { get; set; }
        public string? areas { get; set; }
        public string? category { get; set; }
        public string? certainty { get; set; }
        public string? @event { get; set; }
        public string? note { get; set; }
        public DateTime effective { get; set; }
        public string? expires { get; set; }
        public string? desc { get; set; }
        public string? instruction { get; set; }

    }
}
