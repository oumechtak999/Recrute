using MediatR;
using Test_Technique_Backend.Services.Responses;

namespace Test_Technique_Backend.Services.Features.OffreCandidatServices.Commands.DeleteOffreCandidat
{
    public class DeleteOffreCandidatCommand : IRequest<RequestResponse>
    {
        public string Id { get; set; }
    }
}
