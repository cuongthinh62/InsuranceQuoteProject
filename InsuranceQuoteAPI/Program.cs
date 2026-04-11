using InsuranceQuote.Repositories.Repositories.Implementations;
using InsuranceQuote.Services.Service.Contract;
using InsuranceQuote.Services.Service.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddScoped<IInsuranceQuoteService, InsuranceQuoteService>();
builder.Services.AddDbContext<InsuranceQuoteAPI.Repositories.Data.InsuranceQuoteContext>();
builder.Services.AddScoped<InsuranceProductRepository>(); // concrete
builder.Services.AddScoped<PremiumRuleRepository>();      // concrete
builder.Services.AddScoped<IInsuranceQuoteService, InsuranceQuoteService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
