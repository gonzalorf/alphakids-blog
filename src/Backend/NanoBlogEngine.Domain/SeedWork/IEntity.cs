namespace NanoBlogEngine.Domain.SeedWork;
public interface IEntity
{
    IReadOnlyCollection<IDomainEvent>? DomainEvents { get; }
}
