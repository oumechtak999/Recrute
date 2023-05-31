using Test_Technique_Backend.Models.Common;

namespace Test_Technique_Backend.Models.Entities
{
    public class Cv : AuditableEntity
    {
        public Guid CandidatId { get; set; }
        public Candidat Candidat { get; set; }
        public string Titre { get; set; }
        public string Path { get; set; }
    }
}
