namespace InsuranceQuoteAPI.Models
{
    public class UnderwritingReview
    {
        public long ReviewId { get; set; }
        public long QuoteId { get; set; }
        public long? ReviewerId { get; set; }
        public decimal? RiskScore { get; set; }
        public string ReviewStatus { get; set; } = "PENDING";
        public string Notes { get; set; }
        public DateTime? ReviewedAt { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public Quote Quote { get; set; }
        public User Reviewer { get; set; }
    }
}
