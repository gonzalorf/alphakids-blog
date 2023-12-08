using NanoBlogEngine.Application.Configuration.Commands;
using NanoBlogEngine.Domain.Posts;
using NanoBlogEngine.Domain.Users;

namespace NanoBlogEngine.Application.Comments.Commands.AddComment;

public record AddCommentCommand(
PostId PostId
, string Content
, UserId? AuthorId
) : CommandBase;
