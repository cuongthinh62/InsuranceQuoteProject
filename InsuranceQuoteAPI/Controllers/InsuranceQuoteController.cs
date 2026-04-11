using Microsoft.AspNetCore.Mvc;
using InsuranceQuote.Services.Service.Contract;
using InsuranceQuote.Services.Service.Dtos.Quote;

[ApiController]
[Route("api/v1/[controller]")]
public class InsuranceQuoteController : ControllerBase
{
    private readonly IInsuranceQuoteService _insuranceQuoteService;

    public InsuranceQuoteController(IInsuranceQuoteService insuranceQuoteService)
    {
        _insuranceQuoteService = insuranceQuoteService;
    }

    [HttpPost("calculate")]
    public async Task<IActionResult> CalculateQuote([FromBody] CalculateQuoteRequest request)
    {
        // Tạm thời tính toán trực tiếp, không cần DB
        decimal basePremium = 800m; // cơ bản
        decimal finalPremium = basePremium;

        // Rule cứng
        if (request.Driver.Age < 25)
            finalPremium *= 1.3m; // surcharge
        if (request.Vehicle.Year >= 2023)
            finalPremium *= 0.9m; // new car discount

        // Options
        finalPremium += request.Options.IncludeRoadsideAssistance ? 20m : 0;
        finalPremium -= request.Options.DeductibleMount == 500 ? 50m : 0;

        return Ok(new
        {
            FinalPremium = finalPremium,
            Request = request
        });
    }
}