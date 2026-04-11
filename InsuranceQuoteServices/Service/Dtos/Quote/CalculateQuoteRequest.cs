namespace InsuranceQuote.Services.Service.Dtos.Quote;

public class CalculateQuoteRequest
{
    public string ProductCode { get; set; }
    public DriverDto Driver { get; set; } = new();
    public VehicleDto Vehicle { get; set; } = new();
    public QuoteOptionDto Options { get; set; } = new();

}

public class DriverDto
{
    public int Age { get; set; }
    public int DrivingExperience { get; set; }

    public bool HasRecentAccidents { get; set; }
}

public class VehicleDto
{
    public string Make { get; set; } = "";
    public string Model { get; set; } = "";
    public int Year { get; set; }

    public string UsageType { get; set; } = "";

}

public class QuoteOptionDto
{
    public decimal DeductibleMount { get; set; }

    public bool IncludeRoadsideAssistance { get; set; }
}
