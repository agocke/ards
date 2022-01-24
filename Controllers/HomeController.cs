using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Ards.Models;
using Serde.Json;
using Serde;

namespace Ards.Controllers;

public class HomeController : Controller
{
    private static readonly HttpClient _http = new HttpClient();

    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        const string organization = "dnceng";
        const string project = "public";
        const string branchName = "refs/heads/main";
        const string buildId = "686";
        const int maxBuilds = 10;
        var str = $"https://dev.azure.com/{organization}/{project}/_apis/build/builds?definitions={buildId}&maxBuildsPerDefinition={maxBuilds}&branchName={branchName}&queryOrder=queueTimeDescending&api-version=6.0";
        var result = await _http.GetStringAsync(str);
        var pipelineResult = JsonSerializer.Deserialize<BuildListResponse>(result);
        //ViewData["Str"] = result;
        ViewData["Builds"] = pipelineResult.Value;
        return View();
    }

    public IActionResult Requeue(string buildId)
    {
        return View("hello");
    }

    private static List<T> JsonDeserializeList<T>(string src)
        where T : IDeserialize<T>
        => JsonSerializer.Deserialize<List<T>, ListWrap.DeserializeImpl<T, T>>(src);

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
