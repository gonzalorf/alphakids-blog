using NanoBlogEngine.Domain.Rates;
using NanoBlogEngine.Domain.Posts;
using NanoBlogEngine.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace NanoBlogEngine.Infrastructure.Domain.Rates;

public class RateRepository : IRateRepository
{
    private readonly IApplicationDbContext context;

    public RateRepository(IApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task Add(Rate rate)
    {
        _ = await context.Rates.AddAsync(rate);
    }

    public async Task<IEnumerable<Rate>> GetByPostId(PostId id)
    {
        return await context.Rates.Where(p => p.Id == id).ToListAsync();
    }

    public void Remove(Rate rate)
    {
        _ = context.Rates.Remove(rate);
    }
}
