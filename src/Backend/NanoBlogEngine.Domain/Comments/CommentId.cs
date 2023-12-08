using NanoBlogEngine.Domain.SeedWork;

namespace NanoBlogEngine.Domain.Comments;

public record CommentId(Guid Value) : TypedIdValueBase(Value);

