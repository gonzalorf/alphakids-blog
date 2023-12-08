using NanoBlogEngine.Domain.Comments;
using NanoBlogEngine.Domain.Posts;
using NanoBlogEngine.Domain.SeedWork;

namespace NanoBlogEngine.Domain.Comments.Events;

public record PostCommentedEvent(PostId PostId, CommentId CommentId) : DomainEventBase;
