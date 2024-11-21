using Microsoft.AspNetCore.Mvc;
using Microsoft.Reporting.WebForms;
using ST10298613_PROG6212_POE.Data;
using ST10298613_PROG6212_POE.Models;
using System.Collections.Generic;


namespace ST10298613_PROG6212_POE.Controllers
{
    public class ReportsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReportsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult GenerateClaimReport()
        {
            LocalReport report = new LocalReport();
            report.ReportPath = "Reports/ClaimReport.rdlc"; // Path to RDLC file in your project
            report.DataSources.Add(new ReportDataSource("ClaimDataSet", GetClaimsData()));

            byte[] reportBytes = report.Render("PDF");

            return File(reportBytes, "application/pdf", "ClaimReport.pdf");
        }

        private IEnumerable<Claim> GetClaimsData()
        {
            
            return _context.Claims.ToList();
        }
    }
}
