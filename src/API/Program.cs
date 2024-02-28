using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Core.Services;
using Infrastructure.Logging;

var builder = WebApplication.CreateBuilder(args);

// using secrets for local development
builder.Configuration.AddEnvironmentVariables()
                     .AddUserSecrets(Assembly.GetExecutingAssembly(), true);

// Add services to the container.
builder.Services.AddDbContext<TableImportRecordsContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("TableImportRecordsConnection") ?? ""));

// Core Services and infrastructure
builder.Services.AddScoped<ITableImportService, TableImportService>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// change this setting in Azure CORS for the app policy
if (app.Environment.IsDevelopment())
{
    app.UseCors(builder =>
    builder.WithOrigins("*")
    .AllowAnyHeader()
    .AllowAnyMethod());
}

app.UseAuthorization();

app.MapControllers();

app.Run();
