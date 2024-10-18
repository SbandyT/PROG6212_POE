namespace ST10298613_PROG6212_POE.Models
{
    public class SupportingDocument
    {
        public int Id { get; set; }
        public int ClaimId { get; set; }
        public Claim Claim { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
    }

}
