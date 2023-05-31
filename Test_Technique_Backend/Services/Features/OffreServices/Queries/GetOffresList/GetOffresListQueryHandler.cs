using AutoMapper;

using Test_Technique_Backend.Models.Entities;
using Test_Technique_Backend.Persistences.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Test_Technique_Backend.Services.Features.OffreServices.Queries.GetOffresList
{
    public class GetOffresListQueryHandler : IRequestHandler<GetOffresListQuery, List<OffresListVm>>
    {
        private readonly IAsyncRepository<Offre> _offreRepository;
        private readonly IMapper _mapper;

        public GetOffresListQueryHandler(IMapper mapper, IAsyncRepository<Offre> offreRepository)
        {
            _offreRepository = offreRepository;
            _mapper = mapper;
        }

        public async Task<List<OffresListVm>> Handle(GetOffresListQuery request, CancellationToken cancellationToken)
        {
            var allServices = (await _offreRepository.ListAllAsync(null, cancellationToken)).OrderBy(x => x.Titre);
            return _mapper.Map<List<OffresListVm>>(allServices);
        }
    }
}
