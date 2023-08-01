using NanoBlogEngine.Application.Configuration.Commands;
using NanoBlogEngine.Domain.Posts;

namespace NanoBlogEngine.Application.Posts.Commands.Remove;

public record RemovePostCommand(
    PostId PostId
    ) : CommandBase;
