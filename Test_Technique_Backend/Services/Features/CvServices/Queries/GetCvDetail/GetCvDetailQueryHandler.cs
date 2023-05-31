using AutoMapper;
using MediatR;
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
            List<Cv> cv = new List<Cv>();
            // Expression<Func<GetDemandDetailQuery, bool>> predicate = new Expression<Func<GetDemandDetailQuery, true>();
            // var demand = await _demandRepository.GetByIdAsync(request.Id, new[] { "Validator", "Backup", "Creator", "Companion" }, cancellationToken);
            // var demand = await _demandRepository.GetFirstOrDefault(x => x.Id == request.Id, new[] { "Groups.Visitor.Badge", "Groups.Visitor.EPI", "Groups.Visitor.Work", "Groups.Visitor.Equipements", "Groups.Visitor.BlackList", "Validator", "Backup", "Creator", "Companion"}, cancellationToken);
            cv.Add(await _cvRepository.GetByIdAsync(request.Id, null, cancellationToken)
            );//var demand = await _demandRepository.GetByIdAsync(request.Id, null, cancellationToken);
            return _mapper.Map<List<CvDetailVm>>(cv);
        }
    }
}
