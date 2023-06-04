using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test_Technique_Backend.Services.Features.CandidatServices.Commands.CreateCandidat;
using Test_Technique_Backend.Services.Features.CandidatServices.Queries.GetCandidatsList;
using Test_Technique_Backend.Services.Features.CvServices.Commands.CreateCv;
using Test_Technique_Backend.Services.Features.OffreCandidatServices.Queries.GetOffreCandidatsList;

namespace Test_Technique_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // Cette classe est un contrôleur ASP.NET Core pour gérer les requêtes liées aux candidats.
    public class CandidatController : ControllerBase
    {
        // Cette propriété privée contient une référence à l'interface IMediator, qui est utilisée pour envoyer des commandes et des requêtes au système de médiation.
        private readonly IMediator _mediator;
        public CandidatController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost(Name = "AddCandidat")]
        // Cette méthode gère une requête pour créer un nouveau candidat.
        public async Task<ActionResult<Guid>> Create([FromBody] CreateCandidatCommand createCandidatCommand)
        {
            // Cette ligne de code envoie la commande CreateCandidatCommand au système de médiation en utilisant la méthode Send de IMediator.
            var id = await _mediator.Send(createCandidatCommand);
            return Ok(id);
        }
        [HttpGet(Name = "GetAllCandidats")]
        // Cette méthode gère une requête pour récupérer tous les candidats.
        public async Task<ActionResult<List<CandidatsListVm>>> GetAllCandidats()
        {
            var getCondidatsListQuery = new GetCandidatsListQuery();
            return Ok(await _mediator.Send(getCondidatsListQuery));

        }
    }
}
