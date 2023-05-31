using FluentValidation;

namespace Test_Technique_Backend.Services.Features.OffreCandidatServices.Commands.DeleteOffreCandidat
{
    public class DeleteOffreCandidatCommandValidator : AbstractValidator<DeleteOffreCandidatCommand>
    {

        public DeleteOffreCandidatCommandValidator()
        {
            RuleFor(e => e.Id).MustAsync(async (id, cancellation) =>
            {
                if (!ValidateGuid(id))
                {
                    return false;
                }


                return true;
            })
                .WithMessage("The specified Id is not exists.");
        }

        private bool ValidateGuid(string id)
        {
            return Guid.TryParse(id, out var result);
        }
    }
}
