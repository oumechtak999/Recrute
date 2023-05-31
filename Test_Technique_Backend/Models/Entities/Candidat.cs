using Test_Technique_Backend.Models.Common;

namespace Test_Technique_Backend.Models.Entities
{
    public class Candidat : AuditableEntity
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string NiveauEtude { get; set; }

        public int AnnéesExpérience { get; set; }
        public string DernierEmployeur { get; set; }
        public ICollection<OffreCandidat> OffreCandidats { get; set; }
        public Cv Cv { get; set; }
    }
}
