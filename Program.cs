using System.Reflection;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;
using SievePackage;
using TripNetReactBackend.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.Configure<SieveOptions>(builder.Configuration.GetSection("Sieve"));
builder.Services.AddScoped<ISieveProcessor, MySieveProcessor>();
builder.Services.AddScoped<ISieveProcessor, StationDtoSieveProsessor>();

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString(@"DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var config = new MapperConfiguration(cfg => cfg.AddMaps(AppDomain.CurrentDomain.GetAssemblies()));
var mapper = config.CreateMapper();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Expose swagger because this is a portfolio project
app.UseSwagger();
app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = string.Empty; 
    });


app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
