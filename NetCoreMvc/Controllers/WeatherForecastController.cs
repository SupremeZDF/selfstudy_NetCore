using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Orm.MVC;
using Orm.MVC.Implate;

namespace NetCoreMvc.Controllers
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

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }


        //[HttpGet]
        //public void OneIOC([FromServices] Ittansient ittansient, [FromServices] Ittansient ittansient2,
        //    [FromServices] Iscope iscope, [FromServices] Iscope iscope2, [FromServices] ISingleton singleton, ISingleton singleton2)
        //{

        //    Console.WriteLine(ittansient.GetHashCode());  // A hash code for the current object. 当前对象的散列代码
        //    Console.WriteLine(ittansient2.GetHashCode());

        //    Console.WriteLine(iscope.GetHashCode());
        //    Console.WriteLine(iscope2.GetHashCode());

        //    Console.WriteLine(singleton.GetHashCode());
        //    Console.WriteLine(singleton2.GetHashCode());
        //}
    }
}
