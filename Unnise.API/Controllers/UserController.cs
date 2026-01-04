using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Unnise.Application.Features.Users.Commands.RegisterUser;

namespace Unnise.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IMediator mediator) : ControllerBase
    {
        readonly IMediator _mediator = mediator;

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserCommand param)
        {
            var userId = await _mediator.Send(param);
            return Ok(userId);
        }
    }
}
