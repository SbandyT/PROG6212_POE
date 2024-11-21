using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Xunit.Sdk;

namespace ST10298613_PROG6212_POE.Models
{


    public class Claim
    {
        public int Id { get; set; }
        public string LecturerName { get; set; }
        public int HoursWorked { get; set; }
        public decimal HourlyRate { get; set; }
        public decimal TotalPayment => HoursWorked * HourlyRate;

        // Add this property
        public string Status { get; set; } = "Pending";
    }
}