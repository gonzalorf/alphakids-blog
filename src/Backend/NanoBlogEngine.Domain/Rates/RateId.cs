using NanoBlogEngine.Domain.SeedWork;

namespace NanoBlogEngine.Domain.Rates;

public record RateId(Guid Value) : TypedIdValueBase(Value);
