namespace Test_Technique_Backend.Services.Features.OffreCandidatServices.Queries.GetOffreCandidatsList
{
    public class OffreDto
    {
        public Guid Id { get; set; }
        public string Titre { get; set; }
        public string SousTitre { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int AnneesExperience { get; set; }
        public string Entreprise { get; set; }
        public string Ville { get; set; }
        public string TypeContrat { get; set; }
    }
}
