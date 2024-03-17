using Microsoft.AspNetCore.Mvc;

namespace ExperimentalCaller.Controllers;
[ApiController]
[Route("[controller]/[Action]")]
public class TestEnumerableController
{
    [HttpGet("GetIAsyncEnumerableResult")]
    public async Task GetIAsyncEnumerableResult()
    {
        Console.WriteLine("===========GetIAsyncEnumerableResult=============");
        MyGcService.Reset();
        MyTimer.Start();
        using HttpClient httpClient = new();
        using HttpResponseMessage response = await httpClient.GetAsync(
            "http://localhost:5264/TestEnumerable/GetIAsyncEnumerableResult",
            HttpCompletionOption.ResponseHeadersRead
        ).ConfigureAwait(false);
        response.EnsureSuccessStatusCode();
        IAsyncEnumerable<Guid> guidPool = await response.Content
            .ReadFromJsonAsync<IAsyncEnumerable<Guid>>().ConfigureAwait(false);
        
        MyGcService.PrintMemorySize("Generate");
        MyTimer.Continue("Generate");
        var take = await guidPool.Take(3).ToListAsync();
        MyGcService.PrintMemorySize("take");
        MyTimer.Continue("Generate");
        var count = await guidPool.CountAsync();
        MyGcService.PrintMemorySize("count");
        MyTimer.Continue("count");
        var where = await guidPool.Where(x=> x == Guid.Empty).ToListAsync();
        MyGcService.PrintMemorySize("where");
        MyTimer.Continue("where");

    }
    
    [HttpGet("GetIEnumerableResult")]
    public async Task GetEnumerableResult()
    {
        Console.WriteLine("===========GetIEnumerableResult=============");
        MyGcService.Reset();
        MyTimer.Start();
        using HttpClient httpClient = new();
        using HttpResponseMessage response = await httpClient.GetAsync(
            "http://localhost:5264/TestEnumerable/GetIEnumerableResult",
            HttpCompletionOption.ResponseHeadersRead
        ).ConfigureAwait(false);
        response.EnsureSuccessStatusCode();
        IEnumerable<Guid> guidPool = await response.Content
            .ReadFromJsonAsync<IEnumerable<Guid>>().ConfigureAwait(false);
        
        MyGcService.PrintMemorySize("Generate");
        MyTimer.Continue("Generate");
        var take = guidPool.Take(3).ToList();
        MyGcService.PrintMemorySize("take");
        MyTimer.Continue("Generate");
        var count =  guidPool.Count();
        MyGcService.PrintMemorySize("count");
        MyTimer.Continue("count");
        var where =  guidPool.Where(x=> x == Guid.Empty).ToList();
        MyGcService.PrintMemorySize("where");
        MyTimer.Continue("where");
    }

    [HttpGet("GetListResult")]
    public async Task GetListResult()
    {
        Console.WriteLine("===========GetListResult=============");
        MyGcService.Reset();
        MyTimer.Start();
        using HttpClient httpClient = new();
        using HttpResponseMessage response = await httpClient.GetAsync(
            "http://localhost:5264/TestEnumerable/GetIEnumerableResult",
            HttpCompletionOption.ResponseHeadersRead
        ).ConfigureAwait(false);
        response.EnsureSuccessStatusCode();
        List<Guid> guidPool = await response.Content
            .ReadFromJsonAsync<List<Guid>>().ConfigureAwait(false);
        
        MyGcService.PrintMemorySize("Generate");
        MyTimer.Continue("Generate");
        var take = guidPool.Take(3).ToList();
        MyGcService.PrintMemorySize("take");
        MyTimer.Continue("Generate");
        var count =  guidPool.Count();
        MyGcService.PrintMemorySize("count");
        MyTimer.Continue("count");
        var where =  guidPool.Where(x=> x == Guid.Empty).ToList();
        MyGcService.PrintMemorySize("where");
        MyTimer.Continue("where");
    }
}