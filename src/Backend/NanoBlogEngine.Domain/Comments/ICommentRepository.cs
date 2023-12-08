using NanoBlogEngine.Domain.Posts;

namespace NanoBlogEngine.Domain.Comments;

public interface ICommentRepository
{
    Task Add(Comment comment);
    void Remove(Comment comment);
    void Update(Comment comment);
    Task<IEnumerable<Comment>> GetByPostId(PostId id);
}
