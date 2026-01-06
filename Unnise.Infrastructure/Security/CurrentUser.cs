using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Unnise.Application.Abstractions.Security;

namespace Unnise.Infrastructure.Security
{
    public sealed class CurrentUser(IHttpContextAccessor httpContextAccessor) : ICurrentUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        public Guid Id =>
            Guid.Parse(_httpContextAccessor.HttpContext!.User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        public string Email => 
            _httpContextAccessor.HttpContext!.User.FindFirst(ClaimTypes.Email)!.Value;

        public string GlobalName =>
            _httpContextAccessor.HttpContext!.User.FindFirst("globalName")!.Value;
    }
}
