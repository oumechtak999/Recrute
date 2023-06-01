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
            var validator = new CreateCandidatCommandValidator(_candidatRepository);
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);
            var @candidat = _mapper.Map<Candidat>(request);
            @candidat = await _candidatRepository.AddAsync(@candidat);

            return @candidat.Id;
        }
    }
}
