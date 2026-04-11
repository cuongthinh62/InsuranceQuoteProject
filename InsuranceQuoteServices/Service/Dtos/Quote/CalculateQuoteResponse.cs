using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceQuote.Services.Service.Dtos.Quote
{
    public class CalculateQuoteResponse
    {
        public decimal FinalPremium { get; set; }
        public String ProductName { get; set; } = string.Empty;
    }
}
