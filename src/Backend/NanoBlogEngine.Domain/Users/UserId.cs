using NanoBlogEngine.Domain.SeedWork;

namespace NanoBlogEngine.Domain.Users;

public record UserId(Guid Value) : TypedIdValueBase(Value);
