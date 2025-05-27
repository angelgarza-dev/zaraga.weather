using System.Collections.Generic;

namespace zaraga.weather.Models
{
    internal class WeatherErrorCodes
    {
        internal WeatherErrorCodes()
        {
            ErrorCodes = new Dictionary<int, string>()
            {
                {1002, "API key not provided"},
                {1003, "Parameter 'q' not provided"},
                {1005, "API request url is invalid"},
                {1006, "No location found matching parameter 'q'"},
                {2006, "API key provided is invalid"},
                {2007, "API key has exceeded calls per month quota"},
                {2008, "API key has been disabled"},
                {2009, "API key does not have access to the resource. Please check pricing page for what is allowed in your API subscription plan"},
                {9000, "Json body passed in bulk request is invalid. Please make sure it is valid json with utf-8 encoding"},
                {9001, "Json body contains too many locations for bulk request. Please keep it below 50 in a single request."},
                {9999, "Internal application error"}
            };
        }

        public Dictionary<int, string> ErrorCodes { get; set; }
    }
}
