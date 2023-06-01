using MediatR;
using Test_Technique_Backend.Services.Features.OffreServices.Queries.GetOffresList;

namespace Test_Technique_Backend.Services.Features.CandidatServices.Queries.GetCandidatsList
{
    public class GetCandidatsListQuery : IRequest<List<CandidatsListVm>>
    {
    }
}
