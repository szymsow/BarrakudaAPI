using Domain.Interfaces;
using System.Security.Claims;

namespace WebApi.Services
{
    public class UserContextService : IUserContextService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserContextService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public ClaimsPrincipal User => _httpContextAccessor.HttpContext?.User;

        public int? GetUserId => 
            User is null ? null : (int?)int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);

        public string GetUserName =>
            User is null ? null : User.FindFirst(c => c.Type == ClaimTypes.Name).Value;

    }
}
