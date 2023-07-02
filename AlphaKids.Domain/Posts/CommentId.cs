using AlphaKids.Domain.SeedWork;

namespace AlphaKids.Domain.Posts;

public record CommentId(Guid Value) : TypedIdValueBase(Value);

