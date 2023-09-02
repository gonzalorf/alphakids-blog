namespace NanoBlogEngine.Infrastructure.Outbox;

public interface IDomainEventsDispatcher
{
    Task DispatchEventsAsync();
}