using AlphaKids.Domain.SeedWork;
using AlphaKids.Infrastructure.Database;

namespace AlphaKids.Infrastructure.Domain;

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