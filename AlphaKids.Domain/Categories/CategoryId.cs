using AlphaKids.Domain.SeedWork;

namespace AlphaKids.Domain.Categories;

public record CategoryId(Guid Value) : TypedIdValueBase(Value);
