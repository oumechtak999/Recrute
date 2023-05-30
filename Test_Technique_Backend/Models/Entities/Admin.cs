using Microsoft.AspNetCore.Identity;

namespace Test_Technique_Backend.Models.Entities
{
    public class Admin : IdentityUser
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string CIN { get; set; }
        public ICollection<OffreCandidat> OffreCandidats { get; set; }


    }
}
