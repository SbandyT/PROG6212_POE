using ST10298613_PROG6212_POE.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ST10298613_PROG6212_POE.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<Claim> Claims { get; set; }
        public DbSet<SupportingDocument> SupportingDocuments { get; set; }
        public DbSet<Approval> Approvals { get; set; }
    }
}
