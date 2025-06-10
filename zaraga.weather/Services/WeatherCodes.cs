using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zaraga.weather.Services
{
    public static class WeatherCodes
    {
        /// <summary>
        /// Coleccion de descripciones de clima originales de weatherapi
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string GetWeatherByCode(int code)
        {
            return code switch
            {
                1000 => "Clear",
                1003 => "Partly Cloudy",
                1006 => "Cloudy",
                1009 => "Overcast",
                1030 => "Mist",
                1063 => "Patchy rain possible",
                1066 => "Patchy snow possible",
                1069 => "Patchy sleet possible",
                1072 => "Patchy freezing drizzle possible",
                1087 => "Thundery outbreaks possible",
                1114 => "Blowing snow",
                1117 => "Blizzard",
                1135 => "Fog",
                1147 => "Freezing Fog",
                1150 => "Patchy Light Drizzle",
                1153 => "Light Drizzle",
                1168 => "Freezing Drizzle",
                1171 => "Heavy Freezing Drizzle",
                1180 => "Patchy Light Rain",
                1183 => "Light Rain",
                1186 => "Moderate rain at times",
                1189 => "Moderate rain",
                1192 => "Heavy rain at times",
                1195 => "Heavy Rain",
                1198 => "Light Freezing Rain",
                1201 => "Moderate or Heavy Freezing Rain",
                1204 => "Light Sleet",
                1207 => "Moderate or Heavy Sleet",
                1210 => "Patchy Light Snow",
                1213 => "Light Snow",
                1216 => "Patchy Moderate Snow",
                1219 => "Moderate Snow",
                1222 => "Patchy Heavy Snow",
                1225 => "Heavy Snow",
                1237 => "Ice Pellets",
                1240 => "Light Rain Shower",
                1243 => "Moderate or Heavy Rain Shower",
                1246 => "Torrential Rain Shower",
                1249 => "Light Sleet Shower",
                1252 => "Moderate or Heavy Sleet Shower",
                1255 => "Light Snow Shower",
                1258 => "Moderate or Heavy Snow Shower",
                1261 => "Light showers of ice pellets",
                1264 => "Moderate or Heavy showers of ice pellets",
                1273 => "Patchy Light Rain with Thunder",
                1276 => "Moderate or heavy rain with thunder",
                1279 => "Patchy light snow with thunder",
                1282 => "Moderate or heavy snow with thunder",
                _ => "Unknown"
            };
        }

        /// <summary>
        /// Obtiene la imagen del clima segun el codigo de respuesta de weatherapi
        /// </summary>
        /// <returns></returns>
        public static string GetWeatherImageByCode(int code)
        {
            return code switch
            {
                1000 => "clear", // day | night
                1003 => "partly_cloudy", // day | night
                1006 => "cloudy",
                1009 => "overcast",
                1030 => "mist",
                1063 => "partly_cloudy_rain", // day | night
                1066 => "partly_cloudy_snow", // day | night
                1069 => "partly_cloudy_sleet", // day | night
                1072 => "drizzle",
                1087 => "thunderstorms",
                1114 => "snow",
                1117 => "wind_snow",
                1135 => "fog",
                1147 => "overcast_fog",
                1150 => "drizzle",
                1153 => "overcast_drizzle",
                1168 => "overcast_drizzle",
                1171 => "extreme_drizzle",
                1180 => "overcast_rain",
                1183 => "overcast_rain",
                1186 => "overcast_rain",
                1189 => "overcast_rain",
                1192 => "extreme_rain",
                1195 => "extreme_rain",
                1198 => "extreme_rain",
                1201 => "extreme_rain",
                1204 => "sleet",
                1207 => "overcast_sleet",
                1210 => "snow",
                1213 => "snow",
                1216 => "overcast_snow",
                1219 => "overcast_snow",
                1222 => "extreme_snow",
                1225 => "extreme_snow",
                1237 => "hail",
                1240 => "rain",
                1243 => "overcast_rain",
                1246 => "extreme_rain",
                1249 => "overcast_sleet",
                1252 => "extreme_sleet",
                1255 => "overcast_snow",
                1258 => "extreme_snow",
                1261 => "overcast_hail",
                1264 => "extreme_hail",
                1273 => "thunderstorms_rain",
                1276 => "thunderstorms_overcast_rain",
                1279 => "thunderstorms_snow",
                1282 => "thunderstorms_overcast_snow",
                _ => "not_available"
            };

        }

    }
}
