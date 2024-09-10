using Microsoft.AspNetCore.Mvc;
using ST10298613_PROG6212_POE.Models;
using System.Diagnostics;

namespace ST10298613_PROG6212_POE.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Home page
        public IActionResult Dashboard()
        {
            return View(); // This will return Views/Home/Dashboard.cshtml
        }

        public IActionResult About()
        {
            return View(); // This will return Views/Home/About.cshtml
        }

        public IActionResult PrivacyPolicy()
        {
            return View(); // This will return Views/Home/PrivacyPolicy.cshtml
        }


        // Error handler
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
