using NanoBlogEngine.Domain.SeedWork;
using NanoBlogEngine.Infrastructure.Database;
using NanoBlogEngine.Infrastructure.Outbox;

namespace NanoBlogEngine.Infrastructure.Domain;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext context;
    //private readonly IDomainEventsDispatcher domainEventsDispatcher;

    public UnitOfWork(
        ApplicationDbContext context
        )
    {
        this.context = context;
        //this.domainEventsDispatcher = domainEventsDispatcher;
    }

    public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
    {
        return await context.SaveChangesAsync(cancellationToken);
    }
}