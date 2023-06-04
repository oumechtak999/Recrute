using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test_Technique_Backend.Services.Features.OffreServices.Queries.GetOffresList;

namespace Test_Technique_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // Cette classe est un contrôleur ASP.NET Core pour gérer les requêtes liées aux offres.
    public class OffreController : ControllerBase
    {
        // Cette propriété privée contient une référence à l'interface IMediator, qui est utilisée pour envoyer des commandes et des requêtes au système de médiation.

        private readonly IMediator _mediator;

        public OffreController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllOffres")]
        // Cette méthode gère une requête pour récupérer la liste des offres.
        public async Task<ActionResult<List<OffresListVm>>> GetAllOffres()
        {
            var getOffresListQuery = new GetOffresListQuery();
            return Ok(await _mediator.Send(getOffresListQuery));

        }
    }
}
