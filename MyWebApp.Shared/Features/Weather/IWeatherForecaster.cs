using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebApp.Shared.Features.Weather
{
    public interface IWeatherForecaster
    {
        public Task<IEnumerable<WeatherForecast>> GetWeatherForecastAsync();
    }

}
