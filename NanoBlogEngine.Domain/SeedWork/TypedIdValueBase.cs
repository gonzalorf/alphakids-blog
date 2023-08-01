namespace NanoBlogEngine.Domain.SeedWork;

public record TypedIdValueBase : IEquatable<TypedIdValueBase>
{
    public Guid Value { get; }

    protected TypedIdValueBase(Guid value)
    {
        Value = value;
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }
}