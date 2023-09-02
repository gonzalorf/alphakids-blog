using NanoBlogEngine.Domain.SeedWork;
using NanoBlogEngine.Domain.Users;

namespace NanoBlogEngine.Domain.Posts;

public class Comment : Entity<CommentId>
{
    private Comment() : base() { }

    internal Comment(CommentId id, string content, User? author) : base(id)
    {
        Content = content;
        Author = author;
    }

    public string Content { get; private set; } = string.Empty;
    public User? Author { get; private set; }
}
