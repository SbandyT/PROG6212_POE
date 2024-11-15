using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;  
using ST10298613_PROG6212_POE.Data;  
using ST10298613_PROG6212_POE.Models;
using Microsoft.AspNetCore.SignalR;
using ST10298613_PROG6212_POE.NewFolder;


namespace ST10298613_PROG6212_POE.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHubContext<ClaimStatusHub> _hubContext;
        public AdminController(ApplicationDbContext context, IHubContext<ClaimStatusHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }

        // View all claims (for Programme Coordinators/Academic Managers)


        // Approve or reject claim
        [HttpPost]
        public async Task<IActionResult> ApproveClaim(int claimID)
        {
            var claim = _context.Claims.Find(claimID);
            if (claim != null)
            {
                claim.Status = "Approved";
                _context.SaveChanges();

                // Notify clients about the status update
                await _hubContext.Clients.All.SendAsync("ReceiveStatusUpdate", claim.Id, claim.Status);
            }
            return RedirectToAction("Dashboard");
        }

        [HttpPost]
        public async Task<IActionResult> RejectClaim(int claimID)
        {
            var claim = _context.Claims.Find(claimID);
            if (claim != null)
            {
                claim.Status = "Rejected";
                _context.SaveChanges();

                // Notify clients about the status update
                await _hubContext.Clients.All.SendAsync("ReceiveStatusUpdate", claim.Id, claim.Status);
            }
            return RedirectToAction("Dashboard");
        }
        public IActionResult Dashboard()
        {
            
            var claims = _context.Claims.Include(c => c.Lecturer).ToList();
            return View(claims); // Pass the list of claims to the view
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
