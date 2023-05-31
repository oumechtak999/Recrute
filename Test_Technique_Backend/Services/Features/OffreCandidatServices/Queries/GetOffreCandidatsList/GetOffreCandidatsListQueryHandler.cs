using AutoMapper;
using MediatR;
using Test_Technique_Backend.Models.Entities;
using Test_Technique_Backend.Persistences.Repositories;


namespace Test_Technique_Backend.Services.Features.OffreCandidatServices.Queries.GetOffreCandidatsList
{
    public class GetOffreCandidatsListQueryHandler : IRequestHandler<GetOffreCandidatsListQuery, List<OffreCandidatsListVm>>
    {
        private readonly IAsyncRepository<OffreCandidat> _offreCandidatRepository;
        private readonly IMapper _mapper;

        public GetOffreCandidatsListQueryHandler(IMapper mapper, IAsyncRepository<OffreCandidat> offreCandidatRepository)
        {
            _offreCandidatRepository = offreCandidatRepository;
            _mapper = mapper;
        }

        public async Task<List<OffreCandidatsListVm>> Handle(GetOffreCandidatsListQuery request, CancellationToken cancellationToken)
        {
            var allServices = (await _offreCandidatRepository.ListAllAsync(new[] { "Offre", "Candidat" }, cancellationToken)).OrderBy(x => x.Id);
            return _mapper.Map<List<OffreCandidatsListVm>>(allServices);
        }
    }
}
