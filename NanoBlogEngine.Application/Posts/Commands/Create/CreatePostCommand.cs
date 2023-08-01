using NanoBlogEngine.Application.Configuration.Commands;
using NanoBlogEngine.Domain.Categories;
using NanoBlogEngine.Domain.Posts;

namespace NanoBlogEngine.Application.Posts.Commands.Create;

public record CreatePostCommand(
    string Title
    , string Preview
    , string Content
    , CategoryId[] CategoryIds
    ) : CommandBase<PostId>;