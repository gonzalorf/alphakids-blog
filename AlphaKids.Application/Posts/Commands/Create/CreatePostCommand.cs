using AlphaKids.Domain.Categories;
using AlphaKids.Domain.Posts;
using MediatR;

namespace AlphaKids.Application.Posts.Commands.Create;

public record CreatePostCommand(
    string Title
    , string Preview
    , string Content
    , CategoryId[] CategoryIds
    ) : IRequest;