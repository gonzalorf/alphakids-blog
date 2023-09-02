using NanoBlogEngine.Application.Users.Services;
using NanoBlogEngine.Domain.Users;
using System.Security.Claims;

namespace NanoBlogEngine.WebApi.Services;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    UserId? ICurrentUserService.UserId => new UserId(Guid.Parse(_httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier)));
}
