using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceQuoteAPI.Models
{
    public class PremiumRule
    {
        [Key]
        public long RuleId { get; set; }

        [Required, ForeignKey("InsuranceProduct")]
        public long ProductId { get; set; }

        public int? MinAge { get; set; }
        public int? MaxAge { get; set; }

        [MaxLength(20)]
        public string? RiskLevel { get; set; }

        [Required, Column(TypeName = "decimal(5,2)")]
        public decimal Multiplier { get; set; }


        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Navigation
        public InsuranceProduct InsuranceProduct { get; set; } = null!;
        public InsuranceProduct Product { get; set; }
    }
}
