using NanoBlogEngine.Domain.Posts;
using NanoBlogEngine.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using NanoBlogEngine.Application.Outbox;

namespace NanoBlogEngine.Infrastructure.Outbox;

public class OutboxMessageRepository : IOutboxMessageRepository
{
    private readonly IApplicationDbContext context;

    public OutboxMessageRepository(IApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task Add(OutboxMessage outboxMessage)
    {
        _ = await context.OutboxMessages.AddAsync(outboxMessage);
    }

}
