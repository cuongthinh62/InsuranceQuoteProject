using InsuranceQuote.Repositories.Repositories.Contract;
using InsuranceQuoteAPI.Models;
using InsuranceQuoteAPI.Repositories.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceQuote.Repositories.Repositories.Implementations
{
    public class PremiumRuleRepository : IPremiumRuleRepository
    {
        private readonly InsuranceQuoteContext _context;
        public PremiumRuleRepository(InsuranceQuoteContext context)
        {
            _context = context;
        }
        public async Task<List<PremiumRule>> GetActivePremiumRulesByProductIdAsync(long productId)
        {
            return await _context.PremiumRules.Where(r => r.ProductId == productId && r.IsActive).ToListAsync();
        }
    }
}
