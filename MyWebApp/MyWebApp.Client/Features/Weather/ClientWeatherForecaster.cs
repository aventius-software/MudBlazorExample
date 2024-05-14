using MyWebApp.Shared.Features.Weather;
using System.Net.Http.Json;

internal sealed class ClientWeatherForecaster(HttpClient httpClient) : IWeatherForecaster
{
    public async Task<IEnumerable<WeatherForecast>> GetWeatherForecastAsync() =>
        await httpClient.GetFromJsonAsync<WeatherForecast[]>("WeatherForecast")
        ?? throw new IOException("No weather forecast!");
}
