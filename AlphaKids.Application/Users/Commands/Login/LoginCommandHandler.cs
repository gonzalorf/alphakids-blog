using AlphaKids.Application.Common.Services;
using AlphaKids.Domain.SeedWork;
using AlphaKids.Domain.Users;
using MediatR;

namespace AlphaKids.Application.Users.Commands.Login;

internal sealed class LoginCommandHandler
    : IRequestHandler<LoginCommand, string>
{
    private readonly IJwtProvider jwtProvider;
    private readonly IUserRepository userRepository;
    private readonly IUnitOfWork unitOfWork;

    public LoginCommandHandler(IJwtProvider jwtProvider, IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        this.jwtProvider = jwtProvider;
        this.userRepository = userRepository;
        this.unitOfWork = unitOfWork;
    }

    public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByEmail(request.Email) ?? throw new UserNotFoundException(request.Email);

        var jwt = jwtProvider.GetJwt(user);

        return jwt;
    }
}
