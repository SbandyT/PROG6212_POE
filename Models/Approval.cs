namespace ST10298613_PROG6212_POE.Models
{
    public class Approval
    {
        public int ApprovalID { get; set; }
        public int ClaimID { get; set; }
        public Claim Claim { get; set; }
        public DateTime DateApproved { get; set; }
        public string ApprovedBy { get; set; } // Could be Program Coordinator or Academic Manager
    }
}
