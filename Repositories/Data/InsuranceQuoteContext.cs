using InsuranceQuoteAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace InsuranceQuoteAPI.Data
{
    public class InsuranceQuoteContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<InsuranceProduct> InsuranceProducts { get; set; }
        public DbSet<PremiumRule> PremiumRules { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<UnderwritingReview> UnderwritingReviews { get; set; }
        public DbSet<Policy> Policies { get; set; }
        public DbSet<Payment> Payments { get; set; }






        public InsuranceQuoteContext()
        {
        }

        public InsuranceQuoteContext(DbContextOptions<InsuranceQuoteContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseNpgsql(connectionString: "postgresql://postgres:vocuongthinh2@db.lxhpravfcppuivymmrpa.supabase.co:5432/postgres");
            optionsBuilder.UseNpgsql("Host=aws-1-ap-northeast-1.pooler.supabase.com;Port=5432;Database=postgres;Username=postgres.lxhpravfcppuivymmrpa;Password=vocuongthinh2;");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Primary Keys
            modelBuilder.Entity<Role>().HasKey(r => r.RoleId);
            modelBuilder.Entity<User>().HasKey(u => u.UserId);
            modelBuilder.Entity<Customer>().HasKey(c => c.CustomerId);
            modelBuilder.Entity<InsuranceProduct>().HasKey(p => p.ProductId);
            modelBuilder.Entity<PremiumRule>().HasKey(r => r.RuleId);
            modelBuilder.Entity<Quote>().HasKey(q => q.QuoteId);
            modelBuilder.Entity<UnderwritingReview>().HasKey(r => r.ReviewId);
            modelBuilder.Entity<Policy>().HasKey(p => p.PolicyId);
            modelBuilder.Entity<Payment>().HasKey(p => p.PaymentId);

            // 1-1 Customer <-> User
            modelBuilder.Entity<Customer>()
                .HasOne(c => c.User)
                .WithOne(u => u.Customer)
                .HasForeignKey<Customer>(c => c.UserId);

            // 1-many User <-> UnderwritingReview (Reviewer)
            modelBuilder.Entity<UnderwritingReview>()
                .HasOne(r => r.Reviewer)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.ReviewerId)
                .OnDelete(DeleteBehavior.Restrict);

            // 1-1 Quote <-> UnderwritingReview
            modelBuilder.Entity<Quote>()
                .HasOne(q => q.UnderwritingReview)
                .WithOne(r => r.Quote)
                .HasForeignKey<UnderwritingReview>(r => r.QuoteId);

            // 1-1 Quote <-> Policy
            modelBuilder.Entity<Quote>()
                .HasOne(q => q.Policy)
                .WithOne(p => p.Quote)
                .HasForeignKey<Policy>(p => p.QuoteId);

            // 1-many Customer <-> Quotes
            modelBuilder.Entity<Quote>()
                .HasOne(q => q.Customer)
                .WithMany(c => c.Quotes)
                .HasForeignKey(q => q.CustomerId);

            // 1-many InsuranceProduct <-> Quotes
            modelBuilder.Entity<Quote>()
                .HasOne(q => q.Product)
                .WithMany(p => p.Quotes)
                .HasForeignKey(q => q.ProductId);

            // 1-many InsuranceProduct <-> PremiumRules
            modelBuilder.Entity<PremiumRule>()
                .HasOne(r => r.Product)
                .WithMany(p => p.PremiumRules)
                .HasForeignKey(r => r.ProductId);

            // 1-many Policy <-> Payments
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Policy)
                .WithMany(po => po.Payments)
                .HasForeignKey(p => p.PolicyId);

            // 1-many Role <-> Users
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId);

            // Unique indexes
            modelBuilder.Entity<Customer>().HasIndex(c => c.UserId).IsUnique();
            modelBuilder.Entity<UnderwritingReview>().HasIndex(r => r.QuoteId).IsUnique();
            modelBuilder.Entity<Policy>().HasIndex(p => p.QuoteId).IsUnique();
            modelBuilder.Entity<User>().HasIndex(u => u.Username).IsUnique();
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<Customer>().HasIndex(c => c.IdentityNumber).IsUnique();
            modelBuilder.Entity<Policy>().HasIndex(p => p.PolicyNumber).IsUnique();
            modelBuilder.Entity<Payment>().HasIndex(p => p.TransactionCode).IsUnique();
            modelBuilder.Entity<Role>().HasIndex(r => r.RoleName).IsUnique();
        }

    }
}
