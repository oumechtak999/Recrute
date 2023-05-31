using FluentValidation;
using Test_Technique_Backend.Models.Entities;
using Test_Technique_Backend.Persistences.Repositories;
using Test_Technique_Backend.Services.Features.OffreCandidatServices.Commands.CreateOffreCandidat;

namespace Test_Technique_Backend.Services.Features.CvServices.Commands.CreateCv
{
    public class CreateCvCommandValidator : AbstractValidator<CreateCvCommand>
    {
        private readonly IAsyncRepository<Cv> _cvRepository;
        public CreateCvCommandValidator(IAsyncRepository<Cv> cvRepository)
        {
            _cvRepository = cvRepository;

            RuleFor(p => p.Titre)
                    .NotEmpty().WithMessage("{PropertyTitre} is required.")
                    .NotNull()
                  ;
            RuleFor(p => p.Path)
                    .NotEmpty().WithMessage("{PropertyPath} is required.")
                    .NotNull()
                  ;
            RuleFor(p => p.CandidatId)
                    .NotEmpty().WithMessage("{PropertyCandidatId is required.")
                    .NotNull()
                  ;


        }
    }
}
