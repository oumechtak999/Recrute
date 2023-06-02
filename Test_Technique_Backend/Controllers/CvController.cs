using MediatR;
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
    public class CvController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CvController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{id}", Name = "GetCvByCandidatId")]
        public async Task<ActionResult<List<CvDetailVm>>> GetCvById(Guid id)
        {
            var getCvDetailQuery = new GetCvDetailQuery() { CandidatId = id };
            return Ok(await _mediator.Send(getCvDetailQuery));
        }
        [HttpPost(Name = "AddCv")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateCvCommand createCvCommand)
        {
            var id = await _mediator.Send(createCvCommand);
            return Ok(id);
        }
    }
}
