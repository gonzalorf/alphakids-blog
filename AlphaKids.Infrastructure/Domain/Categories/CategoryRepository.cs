using AlphaKids.Domain.Categories;
using AlphaKids.Domain.Posts;
using AlphaKids.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace AlphaKids.Infrastructure.Domain.Posts;

public class CategoryRepository : ICategoryRepository
{
    private readonly IApplicationDbContext context;

    public CategoryRepository(IApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task Add(Category category)
    {
        context.Categories.Add(category);
    }

    public async Task<Category> GetById(CategoryId id)
    {
        return await context.Categories.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Category[]> GetByIds(CategoryId[] ids)
    {
        return await context.Categories.Where(p => ids.Contains(p.Id)).ToArrayAsync();
    }

    public async Task Remove(Category category)
    {
        context.Categories.Remove(category);
    }
}
