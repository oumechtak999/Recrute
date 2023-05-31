using Microsoft.AspNetCore.Identity;
using Test_Technique_Backend.Models.Entities;

namespace Test_Technique_Backend.Services.InfraServices.FirstUser
{
    public static class CreateFirstUser
    {
        public static async Task SeedAsync(UserManager<Admin> userManager)
        {
            var User = new Admin
            {
                Prenom = "RIDA",
                Nom = "OUMECHTAK",
                UserName = "Reader",
                CIN="1234567",
        Email = "RIDA@gmail.com",
                EmailConfirmed = true,
                
            };
           


            var user = await userManager.FindByEmailAsync(User.Email);
            if (user == null)
            {
                await userManager.CreateAsync(User, "Rida1234?");
            }
            

        }
    }
}
