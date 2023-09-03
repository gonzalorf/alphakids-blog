namespace NanoBlogEngine.Infrastructure.Outbox;
public interface IOutboxMessageRepository
{
    Task Add(OutboxMessage outboxMessage);
}
