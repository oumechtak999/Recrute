namespace Test_Technique_Backend.Services.Features.OffreServices.Queries.GetOffresList
{
    public class OffresListVm
    {
        public Guid Id { get; set; }
        public string Titre { get; set; }
        public string SousTitre { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int AnnéesExpérience { get; set; }
        public string Entreprise { get; set; }
        public string Ville { get; set; }
        public string TypeContrat { get; set; }
    }
}
