using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ST10298613_PROG6212_POE.Data;
using ST10298613_PROG6212_POE.Models;
using ST10298613_PROG6212_POE.NewFolder;

namespace ST10298613_PROG6212_POE.Controllers
{
    public class LecturerController(ApplicationDbContext context, IHubContext<ClaimStatusHub> hubContext) : Controller
    {
        private readonly ApplicationDbContext _context = context;
        private readonly IHubContext<ClaimStatusHub> _hubContext = hubContext;

        // View the list of claims
        public IActionResult Dashboard()
        {
            return View(); // This will return Views/Lecturer/Dashboard.cshtml
        }

        public IActionResult ClaimForm()
        {
            var model = new ST10298613_PROG6212_POE.Models.Claim();
            return View(model);
        }

        public IActionResult ClaimHistory()
        {
            var claims = _context.Claims.Include(c => c.Lecturer).ToList();
            return View(claims);  // Pass claims to the view
        }

        [HttpPost]
        public IActionResult SubmitClaim(ST10298613_PROG6212_POE.Models.Claim claim, IFormFile supportingDocument)
        {
            if (ModelState.IsValid)
            {
                var lecturer = _context.Lecturers.Find(claim.LecturerId);
                if (lecturer == null)
                {
                    ModelState.AddModelError("", "Invalid Lecturer ID.");
                    return View("ClaimForm", claim);
                }

                _context.Claims.Add(claim);
                _context.SaveChanges();

                // Handle file upload if there's a supporting document
                if (supportingDocument != null)
                {
                    var allowedFileTypes = new[] { ".pdf", ".docx", ".xlsx" };
                    var fileExtension = Path.GetExtension(supportingDocument.FileName).ToLower();
                    var maxFileSize = 5 * 1024 * 1024; // 5 MB

                    if (!allowedFileTypes.Contains(fileExtension))
                    {
                        ModelState.AddModelError("", "Only .pdf, .docx, and .xlsx file types are allowed.");
                        return View("ClaimForm", claim);
                    }

                    if (supportingDocument.Length > maxFileSize)
                    {
                        ModelState.AddModelError("", "File size must be less than 5 MB.");
                        return View("ClaimForm", claim);
                    }

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
