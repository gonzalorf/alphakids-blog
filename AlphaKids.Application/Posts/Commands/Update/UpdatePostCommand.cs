using AlphaKids.Domain.Categories;
using AlphaKids.Domain.Posts;
using MediatR;

namespace AlphaKids.Application.Posts.Commands.Update;

public record UpdatePostCommand(
    PostId PostId
    , string Title
    , string Preview
    , string Content
    , CategoryId[] CategoryIds
    ) : IRequest;