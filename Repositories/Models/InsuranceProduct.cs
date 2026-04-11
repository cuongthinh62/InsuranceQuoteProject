using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceQuoteAPI.Models
{
    public class InsuranceProduct
    {
        [Key]
        public long ProductId { get; set; }

        [Required, MaxLength(100)]
        public string ProductName { get; set; } = null!;

        [Required, MaxLength(50)]
        public string InsuranceType { get; set; } = null!;

        [Required, Column(TypeName = "decimal(12,2)")]
        public decimal BasePrice { get; set; } = 800;

        [Column(TypeName = "decimal(15,2)")]
        public decimal? MinCoverage { get; set; }

        [Column(TypeName = "decimal(15,2)")]
        public decimal? MaxCoverage { get; set; }

        public int? MinDurationMonths { get; set; }
        public int? MaxDurationMonths { get; set; }

        [MaxLength(20)]
        public string Status { get; set; } = "ACTIVE";

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Navigation
        public ICollection<PremiumRule> PremiumRules { get; set; } = new List<PremiumRule>();
        public ICollection<Quote> Quotes { get; set; } = new List<Quote>();
    }
}
