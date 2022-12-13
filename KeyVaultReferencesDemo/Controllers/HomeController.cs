using System.Diagnostics;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.AspNetCore.Mvc;
using KeyVaultReferencesDemo.Models;

namespace KeyVaultReferencesDemo.Controllers;

public class HomeController : Controller
{
    private const string KeyVaultUrl = "https://pkolosovkv-690.vault.azure.net";
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
        var secretValue = _configuration["secretValue"];

        ViewBag.Password1 = pass1;
        ViewBag.Password2 = pass2;
        ViewBag.secretValue = secretValue;

        // Get secret from keyvault

        try
        {
            var client = new SecretClient(new Uri(KeyVaultUrl), new DefaultAzureCredential());

            var secret = client
                .GetSecretAsync("secretColor", "b38bb60396b644ecae51766fd8af7df6").Result.Value.Value;

            ViewBag.secretColour = secret;
        }
        catch (Exception e)
        {
            ViewBag.secretColour = $"Error getting secret color: {e.Message}";
        }

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