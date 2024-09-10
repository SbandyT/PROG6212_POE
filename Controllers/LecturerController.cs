using Microsoft.AspNetCore.Mvc;
using ST10298613_PROG6212_POE.Data;
using ST10298613_PROG6212_POE.Models;
using System.Linq;

namespace ST10298613_PROG6212_POE.Controllers
{
    public class LecturerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LecturerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // View the list of claims
        public IActionResult Dashboard()
        {
            return View(); // This will return Views/Lecturer/Dashboard.cshtml
        }

        public IActionResult ClaimForm()
        {
            return View(); // This will return Views/Lecturer/ClaimForm.cshtml
        }

        public IActionResult ClaimHistory()
        {
            return View(); // This will return Views/Lecturer/ClaimHistory.cshtml
        }
    }
}
