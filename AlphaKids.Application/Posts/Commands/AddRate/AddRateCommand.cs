using AlphaKids.Domain.Posts;
using AlphaKids.Domain.Users;
using MediatR;

namespace AlphaKids.Application.Posts.Commands.AddRate;

public record AddRateCommand(
PostId PostId
, int Value
, UserId? RaterId
) : IRequest;
