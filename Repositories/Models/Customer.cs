using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceQuoteAPI.Models
{
    public class Customer
    {
        [Key]
        public long CustomerId { get; set; }

        [Required, ForeignKey("User")]
        public long UserId { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [MaxLength(20)]
        public string? Gender { get; set; }

        [MaxLength(100)]
        public string? Occupation { get; set; }

        [MaxLength(30)]
        public string? IdentityNumber { get; set; }

        public string? Address { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Navigation
        public User User { get; set; } = null!;
        public ICollection<Quote> Quotes { get; set; } = new List<Quote>();
    }
}
