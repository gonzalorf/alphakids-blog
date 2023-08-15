using NanoBlogEngine.Application.Configuration.Commands;

namespace NanoBlogEngine.Application.Users.Commands.Login;

public record LoginCommand(string Email, string Password) : CommandBase<string>;
