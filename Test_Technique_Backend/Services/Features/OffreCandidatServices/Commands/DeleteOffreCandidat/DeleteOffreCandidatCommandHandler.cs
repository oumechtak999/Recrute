using MediatR;
using Test_Technique_Backend.Models.Entities;
using Test_Technique_Backend.Persistences.Repositories;
using Test_Technique_Backend.Services.Responses;

namespace Test_Technique_Backend.Services.Features.OffreCandidatServices.Commands.DeleteOffreCandidat
{
    public class DeleteOffreCandidatCommandHandler : IRequestHandler<DeleteOffreCandidatCommand, RequestResponse>
    {
        private readonly IAsyncRepository<OffreCandidat> _asyncRepository;
        public DeleteOffreCandidatCommandHandler(
            IAsyncRepository<OffreCandidat> asyncOemRepository)
        { _asyncRepository = asyncOemRepository; }


        public async Task<RequestResponse> Handle(DeleteOffreCandidatCommand request, CancellationToken cancellationToken)
        {
            // Création d'une instance de la classe RequestResponse
            var req = new RequestResponse();
            // Suppression de l'OffreCandidat à l'aide du repository

            var succeed = await _asyncRepository.DeleteAsync(new Guid(request.Id), cancellationToken);

            if (succeed)
            {
                // Si la suppression réussit, définir le message de réussite
                req.Message = "OffreCandidat has been deleted successfully";
                // Définir le statut de réussite à true
                req.Succeed = true;
                return req;
            }
            // Si la suppression échoue, définir le message d'échec
            req.Message = "enable to delete OffreCandidat";
            // Définir le statut de réussite à false
            req.Succeed = false;

            return req;
        }

    }
}
