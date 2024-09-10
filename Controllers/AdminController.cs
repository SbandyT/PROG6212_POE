using Microsoft.AspNetCore.Mvc;
using ST10298613_PROG6212_POE.Data;

namespace ST10298613_PROG6212_POE.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // View all claims (for Programme Coordinators/Academic Managers)
        public IActionResult Index()
        {
            var claims = _context.Claims.ToList();
            return View(claims);
        }

        // Approve or reject claim
        [HttpPost]
        public IActionResult ApproveClaim(int claimID)
        {
            var claim = _context.Claims.Find(claimID);
            if (claim != null)
            {
                claim.Status = "Approved";
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RejectClaim(int claimID)
        {
            var claim = _context.Claims.Find(claimID);
            if (claim != null)
            {
                claim.Status = "Rejected";
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Dashboard()
        {
            return View(); // This will return Views/Admin/Dashboard.cshtml
        }

        public IActionResult ReviewClaim(int id)
        {
            var claim = _context.Claims.Find(id);
            return View(claim); // This will return Views/Admin/ReviewClaim.cshtml
        }

        public IActionResult ManageLecturers()
        {
            var lecturers = _context.Lecturers.ToList();
            return View(lecturers); // This will return Views/Admin/ManageLecturers.cshtml
        }

    }
}
