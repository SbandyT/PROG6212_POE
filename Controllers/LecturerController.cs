using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;  
using ST10298613_PROG6212_POE.Data;  
using ST10298613_PROG6212_POE.Models;  


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
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", supportingDocument.FileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        supportingDocument.CopyTo(stream);
                    }

                    // Link the document to the claim
                    var document = new SupportingDocument
                    {
                        ClaimId = claim.Id,
                        FileName = supportingDocument.FileName,
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
