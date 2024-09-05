using APINetBackMVC.Data;
using APINetBackMVC.Services;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

var cultureInfo = CultureInfo.InvariantCulture;
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions => sqlOptions.EnableRetryOnFailure(
            maxRetryCount: 5, // Max tries
            maxRetryDelay: TimeSpan.FromSeconds(10), // Max time between tries
            errorNumbersToAdd: null 
        )
    )
);

builder.Services.AddHttpClient();
builder.Services.AddControllers();
builder.Services.AddScoped<ApiService>();
builder.Services.AddScoped<FeesService>();
builder.Services.AddScoped<BankService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseRouting();



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
