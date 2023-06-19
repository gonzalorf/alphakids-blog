using AlphaKids.Domain.Posts;
using MediatR;

namespace AlphaKids.Application.Posts.Create;

public record CreatePostCommand(
    PostId PostId
    , string Title
    , string Preview
    , string Content
    ) : IRequest;