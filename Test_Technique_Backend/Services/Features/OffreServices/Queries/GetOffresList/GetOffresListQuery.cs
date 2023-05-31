using MediatR;
using System.Collections.Generic;
namespace Test_Technique_Backend.Services.Features.OffreServices.Queries.GetOffresList
{
    public class GetOffresListQuery : IRequest<List<OffresListVm>>
    {
    }
}
