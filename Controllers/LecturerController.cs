using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using ST10298613_PROG6212_POE.Data;
using ST10298613_PROG6212_POE.Models;


namespace ST10298613_PROG6212_POE.Controllers
{
    [Authorize(Roles = "Lecturer")]
    public class LecturerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LecturerController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Dashboard()
        {
            var claims = _context.Claims.Where(c => c.LecturerName == User.Identity.Name).ToList(); // Fetch claims for the logged-in lecturer
            return View(claims);
        }

        [HttpPost]
        public IActionResult SubmitClaim(Claim claim)
        {
            if (ModelState.IsValid)
            {
                claim.LecturerName = User.Identity.Name; // Assign the logged-in lecturer
                _context.Claims.Add(claim);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");
            }

            return View("ClaimForm", claim);
        }

        public IActionResult ClaimHistory()
        {
            var claims = _context.Claims.Where(c => c.LecturerName == User.Identity.Name).ToList(); // Fetch claim history for the logged-in lecturer
            return View(claims);
        }
    }
}