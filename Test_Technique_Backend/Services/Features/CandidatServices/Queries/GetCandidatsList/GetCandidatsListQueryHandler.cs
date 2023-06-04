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
            // Récupération de tous les candidats à partir du repository, triés par nom
            var allServices = (await _candidatRepository.ListAllAsync(null, cancellationToken)).OrderBy(x => x.Nom);
            // Mapper les candidats vers une liste d'objets CandidatsListVm à l'aide de l'objet IMapper et la retourner
            return _mapper.Map<List<CandidatsListVm>>(allServices);
        }
    }
}
