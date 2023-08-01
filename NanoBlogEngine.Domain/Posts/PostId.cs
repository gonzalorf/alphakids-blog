using NanoBlogEngine.Domain.SeedWork;

namespace NanoBlogEngine.Domain.Posts;

public record PostId(Guid Value) : TypedIdValueBase(Value);
