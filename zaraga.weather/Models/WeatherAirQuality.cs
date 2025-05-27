namespace zaraga.weather.Models
{
    internal class WeatherAirQuality
    {
        /// <summary>
        /// Carbon Monoxide (μg/m3)
        /// </summary>
        public float co { get; set; }
        /// <summary>
        /// Ozone (μg/m3)
        /// </summary>
        public float o3 { get; set; }
        /// <summary>
        /// Nitrogen dioxide (μg/m3)
        /// </summary>
        public float no2 { get; set; }
        /// <summary>
        /// Sulphur dioxide (μg/m3)
        /// </summary>
        public float so2 { get; set; }
        /// <summary>
        /// PM2.5 (μg/m3)
        /// </summary>
        public float pm2_5 { get; set; }
        /// <summary>
        /// PM10 (μg/m3)
        /// </summary>
        public float pm10 { get; set; }
        /// <summary>
        /// 1 means Good
        /// 2 means Moderate
        /// 3 means Unhealthy for sensitive group
        /// 4 means Unhealthy
        /// 5 means Very Unhealthy
        /// 6 means Hazardous
        /// </summary>
        public int usepaindex { get; set; }
        /// <summary>
        /// 0-11 low
        /// 12-13 low
        /// 14-35 low
        /// 36-41 moderate
        /// 42-47 moderate
        /// 48-53 moderate
        /// 54-58 High
        /// 59-64 High
        /// 65-70 High
        /// >=71 Very High
        /// </summary>
        public int gbdefraindex { get; set; }
    }
}
