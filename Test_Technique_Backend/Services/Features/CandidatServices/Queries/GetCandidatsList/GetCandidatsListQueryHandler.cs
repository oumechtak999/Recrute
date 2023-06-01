using AutoMapper;
using MediatR;
using Test_Technique_Backend.Models.Entities;
using Test_Technique_Backend.Persistences.Repositories;
using Test_Technique_Backend.Persistences.Repositories.CandidatRepository;
using Test_Technique_Backend.Services.Features.OffreServices.Queries.GetOffresList;

namespace Test_Technique_Backend.Services.Features.CandidatServices.Queries.GetCandidatsList
{
    public class GetCandidatsListQueryHandler : IRequestHandler<GetCandidatsListQuery, List<CandidatsListVm>>
    {
        private readonly IAsyncRepository<Candidat> _candidatRepository;
        private readonly IMapper _mapper;

        public GetCandidatsListQueryHandler(IMapper mapper, IAsyncRepository<Candidat> candidatRepository)
        {
            _candidatRepository = candidatRepository;
            _mapper = mapper;
        }

        public async Task<List<CandidatsListVm>> Handle(GetCandidatsListQuery request, CancellationToken cancellationToken)
        {
            var allServices = (await _candidatRepository.ListAllAsync(null, cancellationToken)).OrderBy(x => x.Nom);
            return _mapper.Map<List<CandidatsListVm>>(allServices);
        }
    }
}
