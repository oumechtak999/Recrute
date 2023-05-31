using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Security.Principal;
using Test_Technique_Backend.Models.Entities;
using Test_Technique_Backend.Persistences;
using Test_Technique_Backend.Services;
using Test_Technique_Backend.Services.InfraServices;
using Test_Technique_Backend.Services.InfraServices.FirstUser;

var builder = WebApplication.CreateBuilder(args);
var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();


       
    
    
var Configuration = builder.Configuration;
// Add services to the container.
builder.Services.AddPersistenceServices(Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddIdentityServices(Configuration);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();

   
        var userManager = services.GetRequiredService<UserManager<Admin>>();

        await CreateFirstUser.SeedAsync(userManager);
       
    
}
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
