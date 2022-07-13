namespace ApiConventions.CommunityToolKit.Example
{
    public class WeatherForecast
    {
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// 气温
        /// </summary>
        public int TemperatureC { get; set; }

        /// <summary>
        /// 华氏
        /// </summary>
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        /// <summary>
        /// 概要
        /// </summary>
        public string? Summary { get; set; }
    }
}