namespace NanoBlogEngine.Domain.SeedWork;

/// <summary>
/// Base class for entities.
/// </summary>
public abstract class Entity<TIdType> : IEntity where TIdType : TypedIdValueBase
{
    public TIdType Id { get; private set; }

    protected Entity(TIdType id)
    {
        Id = id;
    }
    protected Entity() { }

    private List<IDomainEvent>? _domainEvents;

    public IReadOnlyCollection<IDomainEvent>? DomainEvents => _domainEvents?.AsReadOnly();

    public void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents ??= new List<IDomainEvent>();
        _domainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents?.Clear();
    }
}