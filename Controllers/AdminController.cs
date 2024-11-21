using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;  
using ST10298613_PROG6212_POE.Data;  
using ST10298613_PROG6212_POE.Models;
using Microsoft.AspNetCore.SignalR;
using ST10298613_PROG6212_POE.NewFolder;
using Microsoft.AspNetCore.Authorization;
using System.Data.Entity;


namespace ST10298613_PROG6212_POE.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult ManageLecturers()
        {
            var lecturers = _context.Lecturers.ToList(); // Retrieve all lecturers from the database
            return View(lecturers);
        }

        public IActionResult ReviewClaim()
        {
            var claims = _context.Claims.ToList(); // Retrieve all claims from the database
            return View(claims);
        }
        [HttpPost]
        public IActionResult ApproveClaim(int id)
        {
            var claim = _context.Claims.FirstOrDefault(c => c.Id == id);
            if (claim != null)
            {
                claim.Status = "Approved";
                _context.SaveChanges();
            }
            return RedirectToAction("ReviewClaim");
        }
    }
    

}
