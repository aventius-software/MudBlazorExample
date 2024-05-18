using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using MyWebApp.Shared.Features.Weather;

namespace MyWebApp.Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<IWeatherForecaster, ClientWeatherForecaster>();
            builder.Services.AddMudServices();

            await builder.Build().RunAsync();
        }
    }
}
