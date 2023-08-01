using NanoBlogEngine.Domain.Categories;

namespace NanoBlogEngine.Application.Posts.Commands.Update;

public record UpdatePostRequest(
    string Title
    , string Preview
    , string Content
    , CategoryId[] CategoryIds
    );
