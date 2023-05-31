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

            var req = new RequestResponse();


            var succeed = await _asyncRepository.DeleteAsync(new Guid(request.Id), cancellationToken);

            if (succeed)
            {
                req.Message = "OffreCandidat has been deleted successfully";
                req.Succeed = true;
                return req;
            }

            req.Message = "enable to delete OffreCandidat";
            req.Succeed = false;

            return req;
        }

    }
}
