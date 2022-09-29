using API_34208887.Models;
using Microsoft.EntityFrameworkCore;
using NuGet.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(options => { options.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "ConnectedOffice-34208887-API", Version = "v2", Description = "API Test", }); });
builder.Services.AddDbContext<ConnectedOfficeContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
var dbConnectionString = builder.Configuration.GetSection("ConnectionStrings:DefaultConnection").Value;
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v2/swagger.json", "ConnectedOffice-34208887-API v2"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
