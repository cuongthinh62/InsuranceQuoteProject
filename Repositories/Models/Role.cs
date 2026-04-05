using System.ComponentModel.DataAnnotations;

namespace InsuranceQuoteAPI.Models
{
    public class Role
    {
        [Key]
        public long RoleId { get; set; }

        [Required, MaxLength(50)]
        public string RoleName { get; set; } = null!;

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Navigation
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
