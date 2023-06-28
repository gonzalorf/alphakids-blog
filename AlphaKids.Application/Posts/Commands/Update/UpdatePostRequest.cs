using AlphaKids.Domain.Categories;

namespace AlphaKids.Application.Posts.Commands.Update;

public record UpdatePostRequest(
    string Title
    , string Preview
    , string Content
    , CategoryId[] CategoryIds
    );
