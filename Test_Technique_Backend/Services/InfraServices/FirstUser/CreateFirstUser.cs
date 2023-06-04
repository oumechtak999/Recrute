using Microsoft.AspNetCore.Identity;
using Test_Technique_Backend.Models.Entities;

namespace Test_Technique_Backend.Services.InfraServices.FirstUser
{
    // Cette classe statique définit une méthode pour créer le premier utilisateur de l'application.
    public static class CreateFirstUser
    {
        public static async Task SeedAsync(UserManager<Admin> userManager)
        {
            // Un nouvel utilisateur est créé avec les informations suivantes :
            var User = new Admin
            {
                Prenom = "RIDA",
                Nom = "OUMECHTAK",
                UserName = "Rida",
                CIN="1234567",
        Email = "RIDA@gmail.com",
                EmailConfirmed = true,
                
            };

            // La méthode FindByEmailAsync() est utilisée pour chercher l'utilisateur par adresse email.

            var user = await userManager.FindByEmailAsync(User.Email);
            if (user == null)
            {
                // Si l'utilisateur n'est pas trouvé, il est créé avec le mot de passe "Rida1234?".
                await userManager.CreateAsync(User, "Rida1234?");
            }
            

        }
    }
}
