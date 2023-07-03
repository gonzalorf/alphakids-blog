using MediatR;

namespace AlphaKids.Application.Users.Commands.Login;

public record LoginCommand(string Email) : IRequest<string>;
