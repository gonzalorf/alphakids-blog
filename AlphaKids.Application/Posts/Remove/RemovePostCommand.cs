using AlphaKids.Domain.Posts;
using MediatR;

namespace AlphaKids.Application.Posts.Remove;

public record RemovePostCommand(
    PostId PostId
    ) : IRequest;
