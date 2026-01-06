using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Unnise.Application.Features.Projects.Commands.CreateProject;
using Unnise.Application.Features.Projects.Queries.IsProjectNameAvailable;

namespace Unnise.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProjectController(IMediator mediator) : Controller
    {
        readonly IMediator _mediator = mediator;

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateProjectCommand request)
        {
            await _mediator.Send(request);
            return Ok();
        }

        [HttpPost("check-name")]
        public async Task<IActionResult> IsProjectNameAvailable(IsProjectNameAvailableQuery request)
        {
            var isAvailable = await _mediator.Send(request);
            return Ok(isAvailable);
        }
    }
}
