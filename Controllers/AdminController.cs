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
        public async Task<IActionResult> ApproveClaim(int claimId)
        {
            var claim = _context.Claims.Find(claimId);
            if (claim != null)
            {
                claim.Status = "Approved";
                await _context.SaveChangesAsync();
                await _hubContext.Clients.All.SendAsync("ReceiveStatusUpdate", claimId, "Approved");
            }
            return RedirectToAction("Dashboard");
        }

        [HttpPost]
        public async Task<IActionResult> RejectClaim(int claimId)
        {
            var claim = _context.Claims.Find(claimId);
            if (claim != null)
            {
                claim.Status = "Rejected";
                await _context.SaveChangesAsync();
                await _hubContext.Clients.All.SendAsync("ReceiveStatusUpdate", claimId, "Rejected");
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
