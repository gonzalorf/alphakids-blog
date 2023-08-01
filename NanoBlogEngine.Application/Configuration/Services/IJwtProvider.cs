using NanoBlogEngine.Domain.Users;

namespace NanoBlogEngine.Application.Configuration.Services;

public interface IJwtProvider
{
    string GetJwt(User user);
}
