using Microsoft.EntityFrameworkCore;
using NanoBlogEngine.Domain.Comments;
using NanoBlogEngine.Domain.Posts;
using NanoBlogEngine.Infrastructure.Database;

namespace NanoBlogEngine.Infrastructure.Domain.Comments;

public class CommentRepository : ICommentRepository
{
    private readonly IApplicationDbContext context;

    public CommentRepository(IApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task Add(Comment comment)
    {
        _ = await context.Comments.AddAsync(comment);
    }

    public async Task<IEnumerable<Comment>> GetByPostId(PostId id)
    {
        return await context.Comments.Where(p => p.Id == id).ToListAsync();
    }

    public void Remove(Comment comment)
    {
        _ = context.Comments.Remove(comment);
    }

    public void Update(Comment comment)
    {
        _ = context.Comments.Update(comment);
    }
}
