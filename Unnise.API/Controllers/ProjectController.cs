using MediatR;
using Microsoft.AspNetCore.Mvc;
using Unnise.Application.Features.Projects.Queries.IsProjectNameAvailable;

namespace Unnise.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : Controller
    {
        readonly IMediator _mediator;
        public ProjectController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("check-name")]
        public async Task<IActionResult> IsProjectNameAvailable(IsProjectNameAvailableQuery query)
        {
            var isAvailable = await _mediator.Send(query);
            return Ok(isAvailable);
        }
    }
}
