using MediatR;

namespace Test_Technique_Backend.Services.Features.CandidatServices.Commands.CreateCandidat
{
    public class CreateCandidatCommand : IRequest<Guid>
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string CIN { get; set; }
        public string Telephone { get; set; }
        public string NiveauEtude { get; set; }

        public int AnneesExperience { get; set; }
        public string DernierEmployeur { get; set; }
    }
}
