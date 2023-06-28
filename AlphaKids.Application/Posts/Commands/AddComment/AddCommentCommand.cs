using AlphaKids.Domain.Posts;
using AlphaKids.Domain.Users;
using MediatR;

namespace AlphaKids.Application.Posts.Commands.AddComment;

public record AddCommentCommand(
PostId PostId
, string Content
, UserId? AuthorId
) : IRequest;
