using NanoBlogEngine.Application.Configuration.Commands;
using NanoBlogEngine.Domain.Categories;
using NanoBlogEngine.Domain.Posts;

namespace NanoBlogEngine.Application.Posts.Commands.Update;

public record UpdatePostCommand(
    PostId PostId
    , string Title
    , string Preview
    , string Content
    , CategoryId[] CategoryIds
    ) : CommandBase;