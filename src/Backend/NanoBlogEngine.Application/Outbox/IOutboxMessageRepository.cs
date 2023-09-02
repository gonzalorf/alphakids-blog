namespace NanoBlogEngine.Application.Outbox;
public interface IOutboxMessageRepository
{
    Task Add(OutboxMessage outboxMessage);
}
