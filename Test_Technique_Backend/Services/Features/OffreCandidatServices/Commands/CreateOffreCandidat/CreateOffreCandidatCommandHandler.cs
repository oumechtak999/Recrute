using AutoMapper;
using MediatR;
using Test_Technique_Backend.Models.Entities;
using Test_Technique_Backend.Persistences.Repositories;
using Test_Technique_Backend.Persistences.Repositories.OffreCandidatRepository;

namespace Test_Technique_Backend.Services.Features.OffreCandidatServices.Commands.CreateOffreCandidat
{
    public class CreateOffreCandidatCommandHandler : IRequestHandler<CreateOffreCandidatCommand, Guid>
    {
        private readonly IAsyncRepository<OffreCandidat> _offreCandidatRepository;
        private readonly IMapper _mapper;


        public CreateOffreCandidatCommandHandler(IMapper mapper, IAsyncRepository<OffreCandidat> offreCandidatRepository)
        {
            _offreCandidatRepository = offreCandidatRepository;
            _mapper = mapper;

        }

        public async Task<Guid> Handle(CreateOffreCandidatCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateOffreCandidatCommandValidator(_offreCandidatRepository);
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);
            var @offreCandidat = _mapper.Map<OffreCandidat>(request);
            @offreCandidat = await _offreCandidatRepository.AddAsync(@offreCandidat);

            return @offreCandidat.Id;
        }
    }
}
