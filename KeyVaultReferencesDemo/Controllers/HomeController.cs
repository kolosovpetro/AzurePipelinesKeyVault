using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using KeyVaultReferencesDemo.Models;

namespace KeyVaultReferencesDemo.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IConfiguration _configuration;

    public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }

    public IActionResult Index()
    {
        var pass1 = _configuration["Password1"];
        var pass2 = _configuration["Password2"];

        ViewBag.Password1 = pass1;
        ViewBag.Password2 = pass2;
        
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