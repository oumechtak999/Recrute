using AutoMapper;
using MediatR;
using System.Xml.Linq;
using Test_Technique_Backend.Models.Entities;
using Test_Technique_Backend.Persistences.Repositories;

namespace Test_Technique_Backend.Services.Features.CvServices.Queries.GetCvDetail
{
    public class GetCvDetailQueryHandler : IRequestHandler<GetCvDetailQuery, List<CvDetailVm>>
    {
        private readonly IAsyncRepository<Cv> _cvRepository;

        private readonly IMapper _mapper;

        public GetCvDetailQueryHandler(IMapper mapper, IAsyncRepository<Cv> cvRepository)
        {
            _mapper = mapper;
            _cvRepository = cvRepository;

        }

        public async Task<List<CvDetailVm>> Handle(GetCvDetailQuery request, CancellationToken cancellationToken)
        {
            List<Cv> element = new List<Cv>();
            var cv = await _cvRepository.GetBy(x => x.CandidatId == request.CandidatId, null, cancellationToken);
            //var demand = await _demandRepository.GetByIdAsync(request.Id, null, cancellationToken);
            return _mapper.Map<List<CvDetailVm>>(cv);
        }
    }
}
