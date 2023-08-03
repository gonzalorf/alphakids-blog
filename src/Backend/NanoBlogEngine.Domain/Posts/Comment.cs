using NanoBlogEngine.Domain.Users;

namespace NanoBlogEngine.Domain.Posts;

public class Comment
{
    private Comment() { }

    internal Comment(CommentId id, string content, User? author)
    {
        Id = id;
        Content = content;
        Author = author;
    }

    public CommentId Id { get; private set; }
    public string Content { get; private set; }
    public User? Author { get; private set; }
}
