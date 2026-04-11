using InsuranceQuote.Repositories.Repositories.Implementations;
using InsuranceQuote.Services.Service.Contract;
using InsuranceQuote.Services.Service.Dtos.Quote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceQuote.Services.Service.Implementations
{
    public class InsuranceQuoteService : IInsuranceQuoteService
    {
        private readonly InsuranceProductRepository _insuranceProductRepository;
        private readonly PremiumRuleRepository _premiumRuleRepository;
        public InsuranceQuoteService(InsuranceProductRepository repoInsuranceProductRepository, PremiumRuleRepository repoPremiumRuleRepository)
        {
            _insuranceProductRepository = repoInsuranceProductRepository;
            _premiumRuleRepository = repoPremiumRuleRepository;
        }
        async Task<CalculateQuoteResponse> IInsuranceQuoteService.CalculateDynamicQuoteAsync(CalculateQuoteRequest request)
        {
            // 1 lay product theo request.ProductCode
            var product = await _insuranceProductRepository.GetByProductCodeAsync(request.ProductCode);

            // 2 lay rule ap dung cho product
            var rules = await _premiumRuleRepository.GetActivePremiumRulesByProductIdAsync(product.ProductId);

            // 3 Ap dung rule + tinh toan premium 
            decimal premium = product.BasePrice;
            foreach (var rule in rules)
            {
                if(request.Driver.Age >= rule.MinAge && request.Driver.Age <= rule.MaxAge)
                {
                    premium *= (decimal)rule.Multiplier;
                }
            }

            // 4. Áp options
            premium -= request.Options.DeductibleMount * 0.1m; // ví dụ
            if (request.Options.IncludeRoadsideAssistance) premium += 20;

                    // 5. Trả về response
                    return new CalculateQuoteResponse
                    {
                        FinalPremium = premium,
                        ProductName = product.ProductName
                    };
                }
    }
}
