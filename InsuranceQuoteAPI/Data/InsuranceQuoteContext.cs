using InsuranceQuoteAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace InsuranceQuoteAPI.Data
{
    public class InsuranceQuoteContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }

        public InsuranceQuoteContext()
        {
        }

        public InsuranceQuoteContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(connectionString: "postgresql://postgres:vocuongthinh2@db.lxhpravfcppuivymmrpa.supabase.co:5432/postgres");
        }

    }
}
