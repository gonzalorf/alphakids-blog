using AlphaKids.Domain.Posts;
using MediatR;

namespace AlphaKids.Application.Posts.Update;

public record UpdatePostCommand(
    PostId PostId
    , string Title
    , string Preview
    , string Content
    ) : IRequest;