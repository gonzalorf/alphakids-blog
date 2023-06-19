using AlphaKids.Domain.SeedWork;

namespace AlphaKids.Domain.Comments;

public record CommentId(Guid Value) : TypedIdValueBase(Value);

