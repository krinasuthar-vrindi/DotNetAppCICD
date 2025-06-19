using System.Diagnostics;
using DotNetApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Index View loading at {Time}", DateTime.UtcNow);
            return View();
        }

        public IActionResult Privacy()
        {
            _logger.LogDebug("Privacy View accessed at {Time}", DateTime.UtcNow);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var requestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            _logger.LogError("Error View loaded. RequestId: {RequestId}", requestId);
            return View(new ErrorViewModel { RequestId = requestId });
        }
    }
}
