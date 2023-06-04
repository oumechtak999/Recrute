using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Security.Principal;
using Test_Technique_Backend.Models.Common.Mail;
using Test_Technique_Backend.Models.Common.Upload;
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
// Ajout des services au conteneur de d�pendances.
builder.Services.AddPersistenceServices(Configuration); // Ajout des services de persistance
builder.Services.AddApplicationServices(); // Ajout des services de l'application
builder.Services.AddIdentityServices(Configuration); // Ajout des services d'identit�
builder.Services.Configure<MailSettings>(Configuration.GetSection("MailSettings")); // Configuration des param�tres de messagerie
builder.Services.Configure<UploadSettings>(Configuration.GetSection("UploadSettings")); // Configuration des param�tres de t�l�chargement
builder.Services.AddControllers(); // Ajout des services de contr�leurs
builder.Services.AddCors(); // Ajout des services de gestion des CORS
builder.Services.AddEndpointsApiExplorer(); // Ajout des services pour API Explorer
builder.Services.AddSwaggerGen(); // Ajout des services pour Swagger

var app = builder.Build();

using (var scope = app.Services.CreateScope()) // Cr�ation d'une port�e de services
{
    var services = scope.ServiceProvider;
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();

    var userManager = services.GetRequiredService<UserManager<Admin>>();
    await CreateFirstUser.SeedAsync(userManager); // Cr�ation du premier utilisateur (admin) si n�cessaire
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors(x => x
               .AllowAnyMethod()
               .AllowAnyHeader()
               .SetIsOriginAllowed(origin => true) // allow any origin
               .AllowCredentials());
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();
app.MapControllers();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();
