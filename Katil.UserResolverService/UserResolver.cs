using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Katil.UserResolverService
{
    public class UserResolver : IUserResolver
    {
        private readonly IHttpContextAccessor _accessor;

        public UserResolver(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public int GetUserId()
        {
            var userId = _accessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return int.Parse(userId ?? "0");
        }
    }
}
