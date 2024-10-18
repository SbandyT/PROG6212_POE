namespace ST10298613_PROG6212_POE.Models
{
    public class Claim
    {
        public int Id { get; set; }
        public int LecturerId { get; set; }
        public Lecturer Lecturer { get; set; }
        public decimal HoursWorked { get; set; }
        public decimal HourlyRate { get; set; }
        public string Notes { get; set; }
        public string Status { get; set; } = "Pending";

        // Calculated property for Total Amount
        public decimal TotalAmount
        {
            get
            {
                return HoursWorked * HourlyRate;
            }
        }
        // New property for the submission date
        public DateTime SubmissionDate { get; set; } = DateTime.Now;

        
    }
}
