using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test_Technique_Backend.Services.Features.CvServices.Commands.CreateCv;
using Test_Technique_Backend.Services.Features.CvServices.Queries.GetCvDetail;
using Test_Technique_Backend.Services.Features.OffreCandidatServices.Commands.CreateOffreCandidat;
using Test_Technique_Backend.Services.Features.OffreServices.Queries.GetOffresList;

namespace Test_Technique_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // Cette classe est un contrôleur ASP.NET Core pour gérer les requêtes liées aux CV.
    public class CvController : ControllerBase
    {
        // Cette propriété privée contient une référence à l'interface IMediator, qui est utilisée pour envoyer des commandes et des requêtes au système de médiation.
        private readonly IMediator _mediator;
        public CvController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [Authorize]
        [HttpGet("{id}", Name = "GetCvByCandidatId")]
        // Cette méthode gère une requête pour récupérer les détails du CV d'un candidat.
        public async Task<ActionResult<List<CvDetailVm>>> GetCvById(Guid id)
        {
            var getCvDetailQuery = new GetCvDetailQuery() { CandidatId = id };
            return Ok(await _mediator.Send(getCvDetailQuery));
        }
        [HttpPost(Name = "AddCv")]
        // Cette méthode gère une requête pour créer un nouveau CV.
        public async Task<ActionResult<Guid>> Create([FromBody] CreateCvCommand createCvCommand)
        {
            var id = await _mediator.Send(createCvCommand);
            return Ok(id);
        }
    }
}
