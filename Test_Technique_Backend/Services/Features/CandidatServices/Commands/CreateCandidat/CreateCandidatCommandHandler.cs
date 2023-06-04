using AutoMapper;
using MediatR;
using Test_Technique_Backend.Models.Entities;
using Test_Technique_Backend.Persistences.Repositories;
using Test_Technique_Backend.Services.Features.CvServices.Commands.CreateCv;

namespace Test_Technique_Backend.Services.Features.CandidatServices.Commands.CreateCandidat
{
    public class CreateCandidatCommandHandler : IRequestHandler<CreateCandidatCommand, Guid>
    {
        private readonly IAsyncRepository<Candidat> _candidatRepository;
        private readonly IMapper _mapper;


        public CreateCandidatCommandHandler(IMapper mapper, IAsyncRepository<Candidat> candidatRepository)
        {
            _candidatRepository = candidatRepository;
            _mapper = mapper;

        }

        public async Task<Guid> Handle(CreateCandidatCommand request, CancellationToken cancellationToken)
        {
            // Création d'une instance du validateur CreateCandidatCommandValidator
            var validator = new CreateCandidatCommandValidator(_candidatRepository);
            // Validation de la commande CreateCandidatCommand
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count > 0)
                // Lancer une exception si la validation échoue
                throw new Exceptions.ValidationException(validationResult);
            // Mapper la commande CreateCandidatCommand vers l'entité Candidat à l'aide de l'objet IMapper
            var @candidat = _mapper.Map<Candidat>(request);
            // Ajouter l'entité Candidat au repository asynchrone
            @candidat = await _candidatRepository.AddAsync(@candidat);

            return @candidat.Id;
        }
    }
}
