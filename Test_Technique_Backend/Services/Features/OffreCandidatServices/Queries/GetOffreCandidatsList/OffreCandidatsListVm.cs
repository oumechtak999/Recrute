using Test_Technique_Backend.Models.Entities;


namespace Test_Technique_Backend.Services.Features.OffreCandidatServices.Queries.GetOffreCandidatsList
{
    public class OffreCandidatsListVm
    {
        public Guid Id { get; set; }
        public Guid OffreId { get; set; }
        public OffreDto Offre { get; set; }
        public Guid CandidatId { get; set; }
        public CandidatDto Candidat { get; set; }
    }
}
