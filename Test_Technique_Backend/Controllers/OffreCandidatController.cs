using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test_Technique_Backend.Services.Features.OffreCandidatServices.Commands.CreateOffreCandidat;
using Test_Technique_Backend.Services.Features.OffreCandidatServices.Commands.DeleteOffreCandidat;
using Test_Technique_Backend.Services.Features.OffreCandidatServices.Queries.GetOffreCandidatsList;
using Test_Technique_Backend.Services.Responses;

namespace Test_Technique_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // Cette classe est un contrôleur ASP.NET Core pour gérer les requêtes liées à la relation entre les offres et les candidats.
    public class OffreCandidatController : ControllerBase
    {
        // Cette propriété privée contient une référence à l'interface IMediator, qui est utilisée pour envoyer des commandes et des requêtes au système de médiation.

        private readonly IMediator _mediator;

        public OffreCandidatController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet(Name = "GetAllOffreCandidats")]
        // Cette méthode gère une requête pour récupérer la liste des relations entre les offres et les candidats.
        public async Task<ActionResult<List<OffreCandidatsListVm>>> GetAllOffreCandidats()
        {
            var getOffreCondidatsListQuery = new GetOffreCandidatsListQuery();
            return Ok(await _mediator.Send(getOffreCondidatsListQuery));

        }
        [HttpPost(Name = "AddOffreCandidat")]
        // Cette méthode gère une requête pour créer une nouvelle relation entre une offre et un candidat.
        public async Task<ActionResult<Guid>> Create([FromBody] CreateOffreCandidatCommand createOffreCandidatCommand)
        {
            var id = await _mediator.Send(createOffreCandidatCommand);
            return Ok(id);
        }
        [Authorize]
        [HttpDelete("{id}", Name = "DeleteOffreCandidat")]
        // Cette méthode gère une requête pour supprimer une relation entre une offre et un candidat.

        public async Task<ActionResult<RequestResponse>> Delete(string id)
        {
            var res = await _mediator.Send(new DeleteOffreCandidatCommand { Id = id });

            return res.Succeed ? Ok(res) : (ActionResult<RequestResponse>)BadRequest(res);
        }

    }
}
