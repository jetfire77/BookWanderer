using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Tanuj.BookStore.Service
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContext;

        public UserService(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }
        public string GetUserId()
        {
            return _httpContext.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public bool IsAuthenticated() {                   // to check if user is loggedin or not
            return _httpContext.HttpContext.User.Identity.IsAuthenticated;
        }
    }
}
