using Test_Technique_Backend.Models.Common;

namespace Test_Technique_Backend.Models.Entities
{
    // Cette classe représente un candidat dans l'application.
    // La classe étend la classe AuditableEntity pour inclure des propriétés de suivi de l'audit.
    public class Candidat : AuditableEntity
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string CIN { get; set; }
        public string Telephone { get; set; }
        public string NiveauEtude { get; set; }

        public int AnneesExperience { get; set; }
        public string DernierEmployeur { get; set; }
        public ICollection<OffreCandidat> OffreCandidats { get; set; }
        public Cv Cv { get; set; }
    }
}
