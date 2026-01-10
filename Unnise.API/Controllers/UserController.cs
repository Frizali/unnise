using MediatR;
using Microsoft.AspNetCore.Mvc;
using Unnise.Application.Features.Users.Commands.AuthenticateUser;
using Unnise.Application.Features.Users.Commands.GenerateRefreshToken;
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
            var result = await _mediator.Send(request);

            SetRefreshTokenCookie(result.RefreshToken);

            return Ok(result.AccessToken);
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken(GenerateRefreshTokenCommand request)
        {
            var result = await _mediator.Send(request);

            SetRefreshTokenCookie(result.RefreshToken);

            return Ok(result.AccessToken);
        }

        private void SetRefreshTokenCookie(string token)
        {
            Response.Cookies.Append("refreshToken", token, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.UtcNow.AddDays(7)
            });
        }
    }
}
