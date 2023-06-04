using System.Data;
using Test_Technique_Backend.Models.Common;

namespace Test_Technique_Backend.Models.Entities
{
    // Cette classe représente l'association entre la classe offre et candidat dans l'application.
    // La classe étend la classe AuditableEntity pour inclure des propriétés de suivi de l'audit.
    public class OffreCandidat : AuditableEntity
    {
        public Guid OffreId { get; set; }
        public Offre Offre { get; set; }
        public Guid CandidatId { get; set; }
        public Candidat Candidat { get; set; }
        public string? AdminId { get; set; }
        public Admin Admin { get; set; }
    }
}
