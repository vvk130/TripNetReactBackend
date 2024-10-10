using System.Reflection;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;
using SievePackage;
using TripNetReactBackend.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.Configure<SieveOptions>(builder.Configuration.GetSection("Sieve"));
builder.Services.AddScoped<ISieveProcessor, MySieveProcessor>();
builder.Services.AddScoped<ISieveProcessor, StationDtoSieveProsessor>();

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString(@"DefaultConnection")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var config = new MapperConfiguration(cfg => cfg.AddMaps(AppDomain.CurrentDomain.GetAssemblies()));
var mapper = config.CreateMapper();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
