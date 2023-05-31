using Microsoft.Extensions.Configuration;
using Test_Technique_Backend.Persistences;
using Test_Technique_Backend.Services;

var builder = WebApplication.CreateBuilder(args);
var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
var Configuration = builder.Configuration;
// Add services to the container.
builder.Services.AddPersistenceServices(Configuration);
builder.Services.AddApplicationServices();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
