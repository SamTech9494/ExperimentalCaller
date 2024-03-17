using Microsoft.AspNetCore.Mvc;

namespace ExperimentalCaller.Controllers;

[ApiController]
[Route("[controller]/[Action]")]
public class TestAsyncController
{
    [HttpGet("ConfigureAwaitTest")]
    public async Task GetIAsyncEnumerableResult()
    {
        Console.WriteLine(Thread.CurrentThread.IsThreadPoolThread);
        var configureAwaitTestService = new ConfigureAwaitTestService();
        Console.WriteLine("Before Call ConfigureAwaitFalse");
        Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        await configureAwaitTestService.ConfigureAwaitFalse();
        
        Console.WriteLine("Before Call ConfigureAwaitNone");
        Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        await configureAwaitTestService.ConfigureAwaitNone();
        
        Console.WriteLine("Before Call ConfigureAwaitTrue");
        Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        await configureAwaitTestService.ConfigureAwaitTrue();
    }
}

public class ConfigureAwaitTestService
{
    public async Task<HttpResponseMessage> ConfigureAwaitFalse()
    {
        Console.WriteLine("Before Call");
        Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        using HttpClient httpClient = new();
        using HttpResponseMessage response = await httpClient.GetAsync(
            "http://localhost:5264/TestAsync/Get",
            HttpCompletionOption.ResponseHeadersRead
        ).ConfigureAwait(false);
        response.EnsureSuccessStatusCode();
        Console.WriteLine("After Call");
        Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        return response;
    }

    public async Task<HttpResponseMessage> ConfigureAwaitNone()
    {
        Console.WriteLine("Before Call");
        Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        using HttpClient httpClient = new();
        using HttpResponseMessage response = await httpClient.GetAsync(
            "http://localhost:5264/TestAsync/Get",
            HttpCompletionOption.ResponseHeadersRead
        );
        response.EnsureSuccessStatusCode();
        Console.WriteLine("After Call");
        Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        return response;
    }

    public async Task<HttpResponseMessage> ConfigureAwaitTrue()
    {
        Console.WriteLine("Before Call");
        Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        using HttpClient httpClient = new();
        using HttpResponseMessage response = await httpClient.GetAsync(
            "http://localhost:5264/TestAsync/Get",
            HttpCompletionOption.ResponseHeadersRead
        ).ConfigureAwait(true);
        response.EnsureSuccessStatusCode();
        Console.WriteLine("After Call");
        Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        return response;
    }
}