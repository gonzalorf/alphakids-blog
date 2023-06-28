using AlphaKids.Domain.Posts;
using MediatR;

namespace AlphaKids.Application.Posts.Commands.Remove;

public record RemovePostCommand(
    PostId PostId
    ) : IRequest;
