using NanoBlogEngine.Domain.Categories;
using NanoBlogEngine.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace NanoBlogEngine.Infrastructure.Domain.Categories;

public class CategoryRepository : ICategoryRepository
{
    private readonly IApplicationDbContext context;

    public CategoryRepository(IApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task Add(Category category)
    {
        _ = await context.Categories.AddAsync(category);
    }

    public void Remove(Category category)
    {
        _ = context.Categories.Remove(category);
    }

    public async Task<Category[]> GetAll()
    {
        return await context.Categories.ToArrayAsync();
    }

    public async Task<Category?> GetById(CategoryId id)
    {
        return await context.Categories.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Category[]> GetByIds(CategoryId[] ids)
    {
        return await context.Categories.Where(p => ids.Contains(p.Id)).ToArrayAsync();
    }
}
