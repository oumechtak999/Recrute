namespace Test_Technique_Backend.Services.Features.OffreCandidatServices.Queries.GetOffreCandidatsList
{
    public class CandidatDto
    {
        public Guid Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string NiveauEtude { get; set; }

        public int AnnéesExpérience { get; set; }
        public string DernierEmployeur { get; set; }
    }
}
