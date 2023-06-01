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
    public class CandidatController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CandidatController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost(Name = "AddCandidat")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateCandidatCommand createCandidatCommand)
        {
            var id = await _mediator.Send(createCandidatCommand);
            return Ok(id);
        }
        [HttpGet(Name = "GetAllCandidats")]

        public async Task<ActionResult<List<CandidatsListVm>>> GetAllCandidats()
        {
            var getCondidatsListQuery = new GetCandidatsListQuery();
            return Ok(await _mediator.Send(getCondidatsListQuery));

        }
    }
}
