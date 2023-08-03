using NanoBlogEngine.Domain.SeedWork;

namespace NanoBlogEngine.Domain.Categories;

public record CategoryId(Guid Value) : TypedIdValueBase(Value);
