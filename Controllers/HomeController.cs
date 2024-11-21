using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;  
using ST10298613_PROG6212_POE.Data;  
using ST10298613_PROG6212_POE.Models;
using System.Diagnostics;


namespace ST10298613_PROG6212_POE.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PrivacyPolicy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
