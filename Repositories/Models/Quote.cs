using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceQuoteAPI.Models
{
    public class Quote
    {
        [Key]
        public long QuoteId { get; set; }

        [Required, ForeignKey("Customer")]
        public long CustomerId { get; set; }

        [Required, ForeignKey("InsuranceProduct")]
        public long ProductId { get; set; }

        [Required, Column(TypeName = "decimal(15,2)")]
        public decimal CoverageAmount { get; set; }

        [Required]
        public int DurationMonths { get; set; }

        public int? CustomerAge { get; set; }

        [MaxLength(20)]
        public string? RiskLevel { get; set; }

        [Required, Column(TypeName = "decimal(15,2)")]
        public decimal EstimatedPremium { get; set; }

        [MaxLength(20)]
        public string QuoteStatus { get; set; } = "PENDING";

        public DateTime? ExpiresAt { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Navigation
        public Customer Customer { get; set; } = null!;
        public InsuranceProduct InsuranceProduct { get; set; } = null!;
        public UnderwritingReview? UnderwritingReview { get; set; }
        public InsuranceProduct Product { get; set; }
        public Policy? Policy { get; set; }
    }
}
