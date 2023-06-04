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
            // Création d'une nouvelle liste d'entités Cv
            List<Cv> element = new List<Cv>();
            // Récupération des entités Cv par l'ID du candidat
            var cv = await _cvRepository.GetBy(x => x.CandidatId == request.CandidatId, null, cancellationToken);
            // Mapper les entités Cv vers une liste d'objets CvDetailVm à l'aide de l'objet IMapper et la retourner
            return _mapper.Map<List<CvDetailVm>>(cv);
        }
    }
}
