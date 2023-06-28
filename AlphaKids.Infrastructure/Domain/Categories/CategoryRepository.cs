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

    public void Add(Post post)
    {
        context.Posts.Add(post);
    }

    public void Add(Category category)
    {
        context.Categories.Add(category);
    }

    public async Task<Post?> GetById(PostId id)
    {
        return await context.Posts.FirstOrDefaultAsync(p => p.Id == id);
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
        await context.Categories.Remove(category);
    }
}
