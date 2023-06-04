using Test_Technique_Backend.Models.Common;

namespace Test_Technique_Backend.Models.Entities
{
    // Cette classe représente un cv dans l'application.
    // La classe étend la classe AuditableEntity pour inclure des propriétés de suivi de l'audit.
    public class Cv : AuditableEntity
    {
        public Guid CandidatId { get; set; }
        public Candidat Candidat { get; set; }
        public string Titre { get; set; }
        public string Path { get; set; }
    }
}
