using Microsoft.AspNetCore.Mvc;

namespace ExperimentalCaller.Controllers;

[ApiController]
[Route("[controller]/[Action]")]
public class TestAsyncIEnumerableController : ControllerBase
{
    // private static readonly string[] Summaries = new[]
    // {
    //     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    // };
    //
    // static long startMemSize = 0;
    //
    // private readonly ILogger<TestAsyncIEnumerableController> _logger;
    // private WeatherForecastService _weatherForecaster = new WeatherForecastService();
    //
    // public TestAsyncIEnumerableController(ILogger<TestAsyncIEnumerableController> logger)
    // {
    //     _logger = logger;
    // }
    //
    // [HttpGet(Name = "TestAsyncIEnumerable")]
    // public IAsyncEnumerable<WeatherForecast> TestAsyncIEnumerable()
    // {
    //     async IAsyncEnumerable<WeatherForecast> streamWeatherForecastsAsync()
    //     {
    //             WeatherForecast weatherForecast =
    //                 await _weatherForecaster.GetWeatherForecastAsyncEnumerable();
    //             yield return weatherForecast;
    //     }
    //     return streamWeatherForecastsAsync();
    // }
    //
    // [HttpGet(Name = "TestAsync")]
    // public IAsyncEnumerable<WeatherForecast> TestAsync()
    // {
    //     async IAsyncEnumerable<WeatherForecast> streamWeatherForecastsAsync()
    //     {
    //             WeatherForecast weatherForecast = await _weatherForecaster.GetWeatherForecastAsync();
    //             yield return weatherForecast;
    //     }
    //
    //     return streamWeatherForecastsAsync();
    // }
    //
    // [HttpGet(Name = "TestList")]
    // public IAsyncEnumerable<WeatherForecast> TestList()
    // {
    //     async IAsyncEnumerable<WeatherForecast> streamWeatherForecastsAsync()
    //     {
    //         WeatherForecast weatherForecast = await _weatherForecaster.GetWeatherForecastList();
    //         yield return weatherForecast;
    //     }
    //
    //     return streamWeatherForecastsAsync();
    // }
}

internal class WeatherForecastService
{
    // public async Task<WeatherForecast> GetWeatherForecastAsyncEnumerable()
    // {
    //
    //     MyGcService.Reset();
    //     Console.WriteLine($"[{DateTime.UtcNow:hh:mm:ss.fff}] Receving weather forecasts . . .");
    //
    //     using HttpClient httpClient = new();
    //
    //     using HttpResponseMessage response = await httpClient.GetAsync(
    //         "http://localhost:5264/TestAsyncIEnumerable/GetWeatherForecastYieldReturn/GetWeatherForecastYieldReturn?delay=1&count=100000",
    //         HttpCompletionOption.ResponseHeadersRead
    //     ).ConfigureAwait(false);
    //
    //     response.EnsureSuccessStatusCode();
    //
    //     IAsyncEnumerable<WeatherForecast> weatherForecasts = await response.Content
    //         .ReadFromJsonAsync<IAsyncEnumerable<WeatherForecast>>().ConfigureAwait(false);
    //     MyGcService.PrintMemorySize();
    //     var a = new List<WeatherForecast>();
    //     await foreach (var weatherForecast in weatherForecasts)
    //     {
    //         a.Add(weatherForecast);
    //     }
    //     
    //     Console.WriteLine("Received");
    //     MyGcService.PrintMemorySize();
    //     Console.WriteLine("first");
    //     var first = (await weatherForecasts.FirstAsync());
    //     MyGcService.PrintMemorySize();
    //     Console.WriteLine("Where and first");
    //     var whereAndFirst = await weatherForecasts.Where(x=>x.Summary == "Freezing").FirstAsync();
    //     MyGcService.PrintMemorySize();
    //     Console.WriteLine("Where");
    //     var where = weatherForecasts.Where(x=>x.Summary == "Freezing").ToEnumerable().ToList();
    //     MyGcService.PrintMemorySize();
    //     Console.WriteLine("Total");
    //     MyGcService.PrintMemorySize();
    //
    //
    //     Console.WriteLine($"[{DateTime.UtcNow:hh:mm:ss.fff}] Weather forecasts has been received.");
    //     return null;
    // }
    //
    // public async Task<WeatherForecast> GetWeatherForecastAsync()
    // {
    //
    //     MyGcService.Reset();
    //     Console.WriteLine($"[{DateTime.UtcNow:hh:mm:ss.fff}] Receving weather forecasts . . .");
    //
    //     using HttpClient httpClient = new();
    //
    //     httpClient.Timeout = TimeSpan.FromMinutes(5);
    //     using HttpResponseMessage response = await httpClient.GetAsync(
    //         "http://localhost:5264/TestAsyncIEnumerable/GetWeatherForecastNormal?delay=1&count=100000",
    //         HttpCompletionOption.ResponseHeadersRead
    //     ).ConfigureAwait(false);
    //
    //     response.EnsureSuccessStatusCode();
    //
    //     IEnumerable<WeatherForecast> weatherForecasts = await response.Content
    //         .ReadFromJsonAsync<IEnumerable<WeatherForecast>>().ConfigureAwait(false);
    //     Console.WriteLine("Received");
    //     MyGcService.PrintMemorySize();
    //     Console.WriteLine("first");
    //     var first = weatherForecasts.First();
    //     MyGcService.PrintMemorySize();
    //
    //     Console.WriteLine("Where and first");
    //     var whereAndFirst = weatherForecasts.Where(x=>x.Summary == "Freezing").First();
    //     MyGcService.PrintMemorySize();
    //
    //     Console.WriteLine("Where");
    //     var where = weatherForecasts.Where(x=>x.Summary == "Freezing").ToList();
    //     MyGcService.PrintMemorySize();
    //
    //     Console.WriteLine("Total");
    //     MyGcService.PrintMemorySize();
    //
    //     Console.WriteLine($"[{DateTime.UtcNow:hh:mm:ss.fff}] Weather forecasts has been received.");
    //     return null;
    // }
    //
    // private void GetMemorySize(long startMemSize)
    // {
    //     var memory = GC.GetTotalMemory(false) - startMemSize;
    //     GC.Collect(2, GCCollectionMode.Forced, true, false);
    //     Console.WriteLine(memory);
    // }
    //
    // public async Task<WeatherForecast> GetWeatherForecastList()
    // {
    //     GC.Collect(2, GCCollectionMode.Forced, true, false);
    //     var startMemSize = GC.GetTotalMemory(false);
    //     Console.WriteLine($"[{DateTime.UtcNow:hh:mm:ss.fff}] Receving weather forecasts . . .");
    //
    //     using HttpClient httpClient = new();
    //
    //     httpClient.Timeout = TimeSpan.FromMinutes(5);
    //     using HttpResponseMessage response = await httpClient.GetAsync(
    //         "http://localhost:5264/TestAsyncIEnumerable/GetWeatherForecastNormal?delay=1&count=100000",
    //         HttpCompletionOption.ResponseHeadersRead
    //     ).ConfigureAwait(false);
    //
    //     response.EnsureSuccessStatusCode();
    //
    //     List<WeatherForecast> weatherForecasts = await response.Content
    //         .ReadFromJsonAsync<List<WeatherForecast>>().ConfigureAwait(false);
    //     Console.WriteLine("Received");
    //     GetMemorySize(startMemSize);
    //     Console.WriteLine("first");
    //     var first = weatherForecasts.First();
    //     GetMemorySize(startMemSize);
    //     Console.WriteLine("Where and first");
    //     var whereAndFirst = weatherForecasts.Where(x=>x.Summary == "Freezing").First();
    //     GetMemorySize(startMemSize);
    //     Console.WriteLine("Where");
    //     var where = weatherForecasts.Where(x=>x.Summary == "Freezing").ToList();
    //     GetMemorySize(startMemSize);
    //     Console.WriteLine("Total");
    //     GetMemorySize(startMemSize);
    //     Console.WriteLine($"[{DateTime.UtcNow:hh:mm:ss.fff}] Weather forecasts has been received.");
    //     return null;
    //
    // }
}