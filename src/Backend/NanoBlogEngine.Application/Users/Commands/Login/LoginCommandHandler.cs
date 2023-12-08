using NanoBlogEngine.Application.Configuration.Commands;
using NanoBlogEngine.Application.Configuration.Services;
using NanoBlogEngine.Domain.Users;
using NanoBlogEngine.Domain.Users.Exceptions;

namespace NanoBlogEngine.Application.Users.Commands.Login;

internal sealed class LoginCommandHandler
    : ICommandHandler<LoginCommand, UserSessionDto>
{
    private readonly IJwtProvider jwtProvider;
    private readonly IUserRepository userRepository;

    public LoginCommandHandler(IJwtProvider jwtProvider, IUserRepository userRepository)
    {
        this.jwtProvider = jwtProvider;
        this.userRepository = userRepository;
    }

    public async Task<UserSessionDto> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByEmail(request.Email) ?? throw new UserNotFoundException(request.Email);

        var jwt = jwtProvider.GetJwt(user);

        var userSession = new UserSessionDto(user.Name, "", user.Email, user.Role.Name, jwt);

        return userSession;
    }
}
