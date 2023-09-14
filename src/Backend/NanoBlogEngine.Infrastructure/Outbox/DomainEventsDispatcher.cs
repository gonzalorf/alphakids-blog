using NanoBlogEngine.Domain.SeedWork;
using NanoBlogEngine.Infrastructure.Database;
using System.Text.Json;

namespace NanoBlogEngine.Infrastructure.Outbox;

public class DomainEventsDispatcher : IDomainEventsDispatcher
{
    private readonly ApplicationDbContext context;
    private readonly IOutboxMessageRepository outboxRepository;

    public DomainEventsDispatcher(ApplicationDbContext context, IOutboxMessageRepository outboxRepository)
    {
        this.context = context;
        this.outboxRepository = outboxRepository;
    }

    public async Task DispatchEventsAsync()
    {
        var domainEntities = context.ChangeTracker.Entries<IEntity>()
            .Where(x => x.Entity.DomainEvents is not null && x.Entity.DomainEvents.Any()).ToList();

        var domainEvents = domainEntities
            .SelectMany(x => x.Entity.DomainEvents!)
            .ToList();

        foreach (var domainEvent in domainEvents)
        {
            var type = domainEvent.GetType().FullName;
            var data = JsonSerializer.Serialize(domainEvent, domainEvent.GetType());

            var outboxMessage = new OutboxMessage(
                domainEvent.OccurredOn,
                type!,
                data);
            await outboxRepository.Add(outboxMessage);
        }

    }
}