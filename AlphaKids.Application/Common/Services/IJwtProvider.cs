using AlphaKids.Domain.Users;

namespace AlphaKids.Application.Common.Services;

public interface IJwtProvider
{
    string GetJwt(User user);
}
