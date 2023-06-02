using MediatR;

namespace Test_Technique_Backend.Services.Features.CvServices.Queries.GetCvDetail
{
    public class GetCvDetailQuery : IRequest<List<CvDetailVm>>
    {
        public Guid CandidatId { get; set; }
    }
}
