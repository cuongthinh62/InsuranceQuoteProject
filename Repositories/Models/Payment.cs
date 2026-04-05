using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceQuoteAPI.Models
{
    public class Payment
    {
        [Key]
        public long PaymentId { get; set; }

        [Required, ForeignKey("Policy")]
        public long PolicyId { get; set; }

        [Required, Column(TypeName = "decimal(15,2)")]
        public decimal Amount { get; set; }

        [MaxLength(50)]
        public string? PaymentMethod { get; set; }

        [MaxLength(100)]
        public string? TransactionCode { get; set; }

        [MaxLength(20)]
        public string PaymentStatus { get; set; } = "SUCCESS";

        public DateTime? PaidAt { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Navigation
        public Policy Policy { get; set; } = null!;
    }
}
