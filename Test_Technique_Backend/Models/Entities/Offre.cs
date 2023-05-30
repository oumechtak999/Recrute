using System.Data;
using System.Xml.Linq;
using Test_Technique_Backend.Models.Common;

namespace Test_Technique_Backend.Models.Entities
{
    public class Offre : AuditableEntity
    {
        public string Titre { get; set; }
        public string SousTitre { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int AnnéesExpérience { get; set; }
        public string Entreprise { get; set; }
        public string Ville { get; set; }
        public string TypeContrat { get; set; }
        public ICollection<OffreCandidat> OffreCandidats { get; set; }

    }
}
