using NanoBlogEngine.Domain.SeedWork;
using NanoBlogEngine.Infrastructure.Database;

namespace NanoBlogEngine.Infrastructure.Domain;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext context;

    public UnitOfWork(
        ApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
    {
        return await context.SaveChangesAsync(cancellationToken);
    }
}