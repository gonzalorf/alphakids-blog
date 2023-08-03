using NanoBlogEngine.Domain.SeedWork;

namespace NanoBlogEngine.Domain.Posts;

public record CommentId(Guid Value) : TypedIdValueBase(Value);

