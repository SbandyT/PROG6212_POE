namespace ST10298613_PROG6212_POE.Models
{
    public class SupportingDocument
    {
        public int DocumentID { get; set; }
        public int ClaimID { get; set; }
        public Claim Claim { get; set; }
        public string FilePath { get; set; } // Path to the uploaded document
    }
}
