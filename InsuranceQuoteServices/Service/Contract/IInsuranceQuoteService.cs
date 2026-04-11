using InsuranceQuote.Services.Service.Dtos.Quote;
using InsuranceQuoteAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceQuote.Services.Service.Contract;

public interface IInsuranceQuoteService
{
    Task<CalculateQuoteResponse> CalculateDynamicQuoteAsync(CalculateQuoteRequest request);
};

//code chuc nang chinh của IInsuranceQuoteService sẽ được triển khai ở đây
