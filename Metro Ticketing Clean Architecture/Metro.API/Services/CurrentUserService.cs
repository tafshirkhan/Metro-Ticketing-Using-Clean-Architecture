using System.Security.Claims;
using Metro.Application.Contracts;

namespace Metro.API.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
        }

        public Guid? UserId => new Guid(_httpContextAccessor.HttpContext?.User?.FindFirstValue("sub") ?? Guid.Empty.ToString());
       
    }
}
