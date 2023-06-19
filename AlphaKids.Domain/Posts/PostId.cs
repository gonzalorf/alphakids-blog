using AlphaKids.Domain.SeedWork;

namespace AlphaKids.Domain.Posts;

public record PostId(Guid Value) : TypedIdValueBase(Value);
