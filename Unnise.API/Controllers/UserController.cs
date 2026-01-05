using MediatR;
using Microsoft.AspNetCore.Mvc;
using Unnise.Application.Features.Users.Commands.AuthenticateUser;
using Unnise.Application.Features.Users.Commands.RegisterUser;

namespace Unnise.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IMediator mediator) : ControllerBase
    {
        readonly IMediator _mediator = mediator;

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserCommand request)
        {
            var userId = await _mediator.Send(request);
            return Ok(userId);
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(AuthenticateUserCommand request) 
        {
            var token = await _mediator.Send(request);
            return Ok(token);
        }
    }
}
