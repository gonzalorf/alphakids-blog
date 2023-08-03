using NanoBlogEngine.Application.Configuration.Commands;
using NanoBlogEngine.Application.Configuration.Services;
using NanoBlogEngine.Domain.Users;

namespace NanoBlogEngine.Application.Users.Commands.Login;

internal sealed class LoginCommandHandler
    : ICommandHandler<LoginCommand, string>
{
    private readonly IJwtProvider jwtProvider;
    private readonly IUserRepository userRepository;

    public LoginCommandHandler(IJwtProvider jwtProvider, IUserRepository userRepository)
    {
        this.jwtProvider = jwtProvider;
        this.userRepository = userRepository;
    }

    public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByEmail(request.Email) ?? throw new UserNotFoundException(request.Email);

        var jwt = jwtProvider.GetJwt(user);

        return jwt;
    }
}
