using MediatR;
using Microsoft.AspNetCore.Mvc;
using Unnise.Application.Features.Projects.Queries.IsProjectNameAvailable;

namespace Unnise.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController(IMediator mediator) : Controller
    {
        readonly IMediator _mediator = mediator;

        [HttpPost("check-name")]
        public async Task<IActionResult> IsProjectNameAvailable(IsProjectNameAvailableQuery request)
        {
            var isAvailable = await _mediator.Send(request);
            return Ok(isAvailable);
        }
    }
}
