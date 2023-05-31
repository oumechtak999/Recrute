using MediatR;
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
    public class OffreCandidatController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OffreCandidatController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet(Name = "GetAllOffreCandidats")]

        public async Task<ActionResult<List<OffreCandidatsListVm>>> GetAllOffreCandidats()
        {
            var getOffreCondidatsListQuery = new GetOffreCandidatsListQuery();
            return Ok(await _mediator.Send(getOffreCondidatsListQuery));

        }
        [HttpPost(Name = "AddOffreCandidat")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateOffreCandidatCommand createOffreCandidatCommand)
        {
            var id = await _mediator.Send(createOffreCandidatCommand);
            return Ok(id);
        }
        [HttpDelete("{id}", Name = "DeleteOffreCandidat")]
        public async Task<ActionResult<RequestResponse>> Delete(string id)
        {
            var res = await _mediator.Send(new DeleteOffreCandidatCommand { Id = id });

            return res.Succeed ? Ok(res) : (ActionResult<RequestResponse>)BadRequest(res);
        }

    }
}
