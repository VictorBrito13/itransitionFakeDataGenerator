using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using itransitionFakeDataGenerator.Models;
using Services.GenerateFakeData;

namespace itransitionFakeDataGenerator.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index([FromQuery] int seed, [FromQuery] string region, [FromQuery] int errors = 0, [FromQuery] int limit =  20)
    {
        Dictionary<string, string> supportedRegions = new Dictionary<string, string>();
        supportedRegions.Add("es_MX", "Mexican");
        supportedRegions.Add("nl", "Dutch");
        supportedRegions.Add("de", "German");
        TempData["supportedRegions"] = supportedRegions;

        region ??= "es_MX";

        //var users = new FakeData().Generate(seed, region, limit, errors);
        
        //ViewData["users"] = users;
        TempData["seed"] = seed;
        TempData["region"] = region;
        TempData["errors"] = errors;
        TempData["limit"] = limit;
        return View();
    }

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
