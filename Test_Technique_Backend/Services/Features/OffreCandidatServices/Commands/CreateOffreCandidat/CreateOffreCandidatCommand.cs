using MediatR;

namespace Test_Technique_Backend.Services.Features.OffreCandidatServices.Commands.CreateOffreCandidat
{
    public class CreateOffreCandidatCommand : IRequest<Guid>
    {
        public string OffreId { get; set; }
        public Guid CandidatId { get; set; }
    }
}
