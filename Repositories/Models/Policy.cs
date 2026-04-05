using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceQuoteAPI.Models
{
    public class Policy
    {
        [Key]
        public long PolicyId { get; set; }

        [Required, ForeignKey("Quote")]
        public long QuoteId { get; set; }

        [Required, MaxLength(50)]
        public string PolicyNumber { get; set; } = null!;

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required, Column(TypeName = "decimal(15,2)")]
        public decimal TotalPremium { get; set; }

        [MaxLength(20)]
        public string PolicyStatus { get; set; } = "ACTIVE";

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Navigation
        public Quote Quote { get; set; } = null!;
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}
