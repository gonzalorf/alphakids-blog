using NanoBlogEngine.Domain.Posts;
using NanoBlogEngine.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace NanoBlogEngine.Infrastructure.Domain.Posts;

public class PostRepository : IPostRepository
{
    private readonly IApplicationDbContext context;

    public PostRepository(IApplicationDbContext context)
    {
        this.context = context;
    }

    public void Add(Post post)
    {
        _ = context.Posts.Add(post);
    }

    public async Task<Post?> GetById(PostId id)
    {
        return await context.Posts.FirstOrDefaultAsync(p => p.Id == id);
    }

    public void Remove(Post post)
    {
        throw new NotImplementedException();
    }

    public void Update(Post post)
    {
        throw new NotImplementedException();
    }
}
