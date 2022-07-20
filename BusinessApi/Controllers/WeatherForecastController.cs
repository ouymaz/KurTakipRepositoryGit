using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace BusinessApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IDistributedCache _distributedCache;


        public WeatherForecastController(ILogger<WeatherForecastController> logger, IDistributedCache distributedCache)
        {
            _logger = logger;
            _distributedCache = distributedCache;
        }

        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    var cached = await _cache.GetStringAsync("temperatures");
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}
        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IEnumerable<WeatherForecast>> GetAsync()
        {
            var cached = await _distributedCache.GetStringAsync("temperatures");

            if (cached == null)
            {

                Random r = new Random();
                var result = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = r.Next(-20, 55),
                    Summary = Summaries[r.Next(Summaries.Length)]
                }).ToArray();

                await _distributedCache.SetStringAsync(
                "temperatures",
                System.Text.Json.JsonSerializer.Serialize(result),
            new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5),
                SlidingExpiration = TimeSpan.FromSeconds(60)
            });

                return result;
            }
            else
            {
                return JsonSerializer.Deserialize<IEnumerable<WeatherForecast>>(cached);
            }
        }
    }
}

