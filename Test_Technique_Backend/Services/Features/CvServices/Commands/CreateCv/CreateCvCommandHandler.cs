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
            var validator = new CreateCvCommandValidator(_cvRepository);
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);
            var @cv = _mapper.Map<Cv>(request);
            @cv = await _cvRepository.AddAsync(@cv);

            return @cv.Id;
        }
    }
}
