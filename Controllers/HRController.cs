using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ST10298613_PROG6212_POE.Data;

[Authorize(Roles = "HR")]
public class HRController : Controller
{
    private readonly ApplicationDbContext _context;

    public HRController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Dashboard()
    {
        var claims = _context.Claims.Where(c => c.Status == "Pending").ToList(); // Fetch pending claims for review
        return View(claims);
    }

    public IActionResult ProcessClaims()
    {
        var claims = _context.Claims.Where(c => c.Status == "Pending").ToList(); // Fetch pending claims for processing
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
        return RedirectToAction("Dashboard");
    }

    [HttpPost]
    public IActionResult RejectClaim(int id)
    {
        var claim = _context.Claims.FirstOrDefault(c => c.Id == id);
        if (claim != null)
        {
            claim.Status = "Rejected";
            _context.SaveChanges();
        }
        return RedirectToAction("Dashboard");
    }
}

