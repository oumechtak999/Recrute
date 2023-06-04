using Microsoft.AspNetCore.Identity;

namespace Test_Technique_Backend.Models.Entities
{
    // Cette classe représente un administrateur dans l'application.
    // La classe hérite de la classe IdentityUser de la bibliothèque ASP.NET Core Identity.
    public class Admin : IdentityUser
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string CIN { get; set; }
        public ICollection<OffreCandidat> OffreCandidats { get; set; }


    }
}
