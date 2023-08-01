using NanoBlogEngine.Application.Configuration.Commands;
using NanoBlogEngine.Domain.Posts;
using NanoBlogEngine.Domain.Users;

namespace NanoBlogEngine.Application.Posts.Commands.AddRate;

public record AddRateCommand(
PostId PostId
, int Value
, UserId? RaterId
) : CommandBase;
