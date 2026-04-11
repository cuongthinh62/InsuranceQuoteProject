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
    public class InsuranceProductRepository : IInsuranceProductRepository
    {
        private readonly InsuranceQuoteContext _context;
        public InsuranceProductRepository(InsuranceQuoteContext context)
        {
            _context = context;
        }

        public async Task<List<InsuranceProduct>> GetAllInsuranceProductsAsync()
        {
            return await _context.InsuranceProducts.ToListAsync();
        }

        public async Task<InsuranceProduct?> GetByProductCodeAsync(string productCode)
        {
            return await _context.InsuranceProducts.FirstOrDefaultAsync(p => p.ProductName == productCode);
        }
    }
}
