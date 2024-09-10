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
        public IActionResult Index()
        {
            var lecturers = _context.Lecturers.ToList();
            return View(lecturers);
        }

        // Submit a claim
        [HttpGet]
        public IActionResult SubmitClaim()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitClaim(Claim claim)
        {
            if (ModelState.IsValid)
            {
                _context.Claims.Add(claim);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(claim);
        }
    }
}
