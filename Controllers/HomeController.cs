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
        public IActionResult Index()
        {
            return View();
        }

        // Privacy policy page (optional)
        public IActionResult Privacy()
        {
            return View();
        }

        // Navigation to Lecturer Dashboard
        public IActionResult Lecturer()
        {
            return RedirectToAction("Index", "Lecturer");
        }

        // Navigation to Admin Dashboard
        public IActionResult Admin()
        {
            return RedirectToAction("Index", "Admin");
        }

        // Error handler
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
