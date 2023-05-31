using FluentValidation;
using Test_Technique_Backend.Models.Entities;
using Test_Technique_Backend.Persistences.Repositories;
using Test_Technique_Backend.Persistences.Repositories.OffreCandidatRepository;

namespace Test_Technique_Backend.Services.Features.OffreCandidatServices.Commands.CreateOffreCandidat
{
    public class CreateOffreCandidatCommandValidator : AbstractValidator<CreateOffreCandidatCommand>
    {
        private readonly IAsyncRepository<OffreCandidat> _offreCandidatRepository;
        public CreateOffreCandidatCommandValidator(IAsyncRepository<OffreCandidat> offreCandidatRepository)
        {
            _offreCandidatRepository = offreCandidatRepository;

            RuleFor(p => p.OffreId)
                    .NotEmpty().WithMessage("{PropertyOffreId} is required.")
                    .NotNull()
                  ;
            RuleFor(p => p.CandidatId)
                    .NotEmpty().WithMessage("{PropertyCandidatId is required.")
                    .NotNull()
                  ;


        }
    }
}
