using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test_Technique_Backend.Services.Features.OffreServices.Queries.GetOffresList;

namespace Test_Technique_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OffreController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OffreController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllOffres")]

        public async Task<ActionResult<List<OffresListVm>>> GetAllOffres()
        {
            var getOffresListQuery = new GetOffresListQuery();
            return Ok(await _mediator.Send(getOffresListQuery));

        }
    }
}
