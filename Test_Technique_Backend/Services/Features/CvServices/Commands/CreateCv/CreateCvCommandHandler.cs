using AutoMapper;
using MediatR;
using Test_Technique_Backend.Models.Entities;
using Test_Technique_Backend.Persistences.Repositories;
using Test_Technique_Backend.Services.Features.OffreCandidatServices.Commands.CreateOffreCandidat;

namespace Test_Technique_Backend.Services.Features.CvServices.Commands.CreateCv
{
    public class CreateCvCommandHandler : IRequestHandler<CreateCvCommand, Guid>
    {
        private readonly IAsyncRepository<Cv> _cvRepository;
        private readonly IMapper _mapper;


        public CreateCvCommandHandler(IMapper mapper, IAsyncRepository<Cv> cvRepository)
        {
            _cvRepository = cvRepository;
            _mapper = mapper;

        }

        public async Task<Guid> Handle(CreateCvCommand request, CancellationToken cancellationToken)
        {
            // Création d'une instance du validateur CreateCvCommandValidator
            var validator = new CreateCvCommandValidator(_cvRepository);
            // Validation de la commande CreateCvCommand
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count > 0)
                // Lancer une exception si la validation échoue
                throw new Exceptions.ValidationException(validationResult);
            // Mapper la commande CreateCvCommand vers l'entité Cv à l'aide de l'objet IMapper
            var @cv = _mapper.Map<Cv>(request);
            // Ajouter l'entité Cv au repository asynchrone
            @cv = await _cvRepository.AddAsync(@cv);

            return @cv.Id;
        }
    }
}
