using NanoBlogEngine.Domain.Users;

namespace NanoBlogEngine.Application.Users.Services;

public interface ICurrentUserService
{
    UserId? UserId { get; }
}
