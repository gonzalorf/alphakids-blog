using NanoBlogEngine.Domain.SeedWork;

namespace NanoBlogEngine.Domain.Posts.Events;

public record PostCommentedEvent(PostId PostId, CommentId CommentId) : DomainEventBase;
