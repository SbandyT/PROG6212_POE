namespace ST10298613_PROG6212_POE.Models
{
    public class Claim
    {
        public int ClaimID { get; set; }
        public int LecturerID { get; set; }
        public Lecturer Lecturer { get; set; }
        public decimal HoursWorked { get; set; }
        public decimal TotalAmount => HoursWorked * Lecturer.HourlyRate;  // Auto-calculated
        public string Status { get; set; } = "Pending"; // Pending, Approved, Settled
        public SupportingDocument Document { get; set; }
    }
}
