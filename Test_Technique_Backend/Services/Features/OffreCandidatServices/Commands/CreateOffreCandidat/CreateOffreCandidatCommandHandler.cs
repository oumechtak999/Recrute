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
            // Création d'une instance du validateur de la commande
            var validator = new CreateOffreCandidatCommandValidator(_offreCandidatRepository);
            // Validation de la commande à l'aide du validateur
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count > 0)
                // Si la validation échoue, une exception de validation est levée
                throw new Exceptions.ValidationException(validationResult);
            // Mapper la commande vers l'objet OffreCandidat à l'aide de l'objet IMapper
            var @offreCandidat = _mapper.Map<OffreCandidat>(request);
            // Ajouter l'offre de candidature à la base de données à l'aide du repository
            @offreCandidat = await _offreCandidatRepository.AddAsync(@offreCandidat);

            return @offreCandidat.Id;
        }
    }
}
