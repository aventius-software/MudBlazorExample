using Microsoft.AspNetCore.Mvc;
using MyWebApp.Shared.Features.Weather;

namespace MyWebApp.Features.Weather
{
    [ApiController]
    [Route("[controller]")]    
    public class WeatherForecastController : Controller
    {
        private readonly IWeatherForecaster _weatherForecaster;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(IWeatherForecaster weatherForecaster, ILogger<WeatherForecastController> logger)
        {
            _weatherForecaster = weatherForecaster;
            _logger = logger;
        }

        [HttpGet]
        public Task<IEnumerable<WeatherForecast>> Get() => _weatherForecaster.GetWeatherForecastAsync();
    }
}
