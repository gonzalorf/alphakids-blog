using NanoBlogEngine.Infrastructure.Database;

namespace NanoBlogEngine.Infrastructure.Outbox;

public class OutboxMessageRepository : IOutboxMessageRepository
{
    private readonly ApplicationDbContext context;

    public OutboxMessageRepository(ApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task Add(OutboxMessage outboxMessage)
    {
        _ = await context.Set<OutboxMessage>().AddAsync(outboxMessage);
    }

}
