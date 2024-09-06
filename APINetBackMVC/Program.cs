using APINetBackMVC.Data;
using APINetBackMVC.Services;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using AutoMapper;
using APINetBackMVC.Mapping;
using Microsoft.Extensions.DependencyInjection;

CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture; ;
CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture; ;

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

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddControllersWithViews();

var app = builder.Build();
app.UseRouting();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
