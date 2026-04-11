using InsuranceQuoteAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceQuote.Repositories.Repositories.Contract
{
    internal interface IPremiumRuleRepository
    {
        Task<List<PremiumRule>> GetActivePremiumRulesByProductIdAsync(long productId);
    }
}
