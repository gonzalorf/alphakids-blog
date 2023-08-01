using NanoBlogEngine.Domain.SeedWork;

namespace NanoBlogEngine.Domain.Posts;

public record RateId(Guid Value) : TypedIdValueBase(Value);
