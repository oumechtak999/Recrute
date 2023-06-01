using FluentValidation;
using Test_Technique_Backend.Models.Entities;
using Test_Technique_Backend.Persistences.Repositories;
using Test_Technique_Backend.Services.Features.CvServices.Commands.CreateCv;

namespace Test_Technique_Backend.Services.Features.CandidatServices.Commands.CreateCandidat
{
    public class CreateCandidatCommandValidator : AbstractValidator<CreateCandidatCommand>
    {
        private readonly IAsyncRepository<Candidat> _candidatRepository;
        public CreateCandidatCommandValidator(IAsyncRepository<Candidat> candidatRepository)
        {
            _candidatRepository = candidatRepository;

            RuleFor(p => p.Nom)
                    .NotEmpty().WithMessage("{PropertyNom} is required.")
                    .NotNull()
                  ;
            RuleFor(p => p.Prenom)
                    .NotEmpty().WithMessage("{PropertyPrenom} is required.")
                    .NotNull()
                  ;
            RuleFor(p => p.CIN)
                    .NotEmpty().WithMessage("{PropertyCIN} is required.")
                    .NotNull()
                  ;


        }
    }
}
