using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Services.WeatherForecast;

namespace WeatherScienceAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private IMemoryCache _cache;
        private IWeatherForecast _weatherForecast;

        public WeatherForecastController(IWeatherForecast weatherForecast, IMemoryCache memoryCache)
        {
            _weatherForecast = weatherForecast;
            _cache = memoryCache;
        }

        //example link: https://localhost:44390/weatherforecast/2019-12-31T22:00:00/1.5847/1.695
        [HttpGet("{date}/{lat}/{lon}")]
        public int? Get(DateTime date, double lat, double lon)
        {
            return _weatherForecast.GetWeatherForecast(date, lat, lon);
        }
    }
}
