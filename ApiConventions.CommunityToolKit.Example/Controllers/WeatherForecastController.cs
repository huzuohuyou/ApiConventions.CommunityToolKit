using Microsoft.AspNetCore.Mvc;

namespace ApiConventions.CommunityToolKit.Example.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ApiConventionType(typeof(CtkApiConventions))]
    [Produces("application/json")]
    public class WeatherForecastController : CtkControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// 全量查询
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<WeatherForecast> GetAllWeather()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        /// <summary>
        /// 过滤查询
        /// </summary>
        /// <remarks>
        /// 注意路由
        /// </remarks>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost, Route("Select")]
        
        public ActionResult<IEnumerable<WeatherForecast>> Select(WeatherForecast model)
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
                .ToArray();
        }

        /// <summary>
        /// 单一实体查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetById")]
        public WeatherForecast Get(int id)
        {
            throw new Exception("a");
            return new WeatherForecast() { Date = DateTime.Now, TemperatureC = 100 };
        }


        /// <summary>
        /// 创建天气记录
        /// </summary>
        /// <param name="modelWeather"></param>
        /// <returns></returns>
        [HttpPost(Name = "PostWeather")]
        [ApiConventionMethod(typeof(CtkApiConventions),
            nameof(CtkApiConventions.Post))]
        public IActionResult Post(WeatherForecast modelWeather)
        {
            return CreatedAtRoute("GetById", new { id = modelWeather.Date }, modelWeather);
        }


    }
}