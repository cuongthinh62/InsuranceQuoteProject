using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceQuoteAPI.Models
{
    public class PremiumRule
    {
        [Key]
        public long RuleId { get; set; }

        [Required]
        [ForeignKey(nameof(InsuranceProduct))]
        public long ProductId { get; set; }

        // giữ rule tuổi cũ
        public int? MinAge { get; set; }
        public int? MaxAge { get; set; }

        [MaxLength(20)]
        public string? RiskLevel { get; set; }

        // thêm để support dynamic factors
        [MaxLength(50)]
        public string? FactorType { get; set; }

        [MaxLength(20)]
        public string? ConditionOperator { get; set; }

        [MaxLength(100)]
        public string? ConditionValue { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? Multiplier { get; set; } = 0.2m; // mặc định 20% tăng

        [Column(TypeName = "decimal(12,2)")]
        public decimal? FlatAdjustment { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Navigation
        public InsuranceProduct InsuranceProduct { get; set; } = null!;
    }
}