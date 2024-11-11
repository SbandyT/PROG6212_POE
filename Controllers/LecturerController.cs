using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ST10298613_PROG6212_POE.Data;
using ST10298613_PROG6212_POE.Models;
using System.IO;

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
            var claims = _context.Claims.Include(c => c.Lecturer).ToList();
            return View(claims);  // Pass claims to the view
        }

        [HttpPost]
        public IActionResult SubmitClaim(Claim claim, IFormFile supportingDocument)
        {
            if (ModelState.IsValid)
            {
                // Save the claim details to the database
                _context.Claims.Add(claim);
                _context.SaveChanges();

                // Handle file upload if there's a supporting document
                if (supportingDocument != null)
                {
                    var uniqueFileName = $"{Guid.NewGuid()}_{supportingDocument.FileName}";
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", uniqueFileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        supportingDocument.CopyTo(stream);
                    }

                    // Link the document to the claim
                    var document = new SupportingDocument
                    {
                        ClaimId = claim.Id,
                        FileName = uniqueFileName,
                        FilePath = filePath
                    };

                    _context.SupportingDocuments.Add(document);
                    _context.SaveChanges();
                }

                return RedirectToAction("ClaimHistory");
            }

            return View("ClaimForm", claim);
        }
    }
}
