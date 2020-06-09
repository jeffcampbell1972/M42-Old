using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using M42.Sports;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace M42.API.Controllers
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
        private readonly IService<Sport> _sportsService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IService<Sport> sportsService)
        {
            _logger = logger;
            _sportsService = sportsService;
        }

        [HttpGet]
        public IEnumerable<Sport> Get()
        {
            //var rng = new Random();
            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateTime.Now.AddDays(index),
            //    TemperatureC = rng.Next(-20, 55),
            //    Summary = Summaries[rng.Next(Summaries.Length)]
            //})
            //.ToArray();

            var sports = _sportsService.Get();

            return sports.ToArray();
        }
    }
}
