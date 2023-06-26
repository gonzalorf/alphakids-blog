using AlphaKids.Domain.Posts;
using AlphaKids.Domain.Users;

namespace AlphaKids.Domain.Comments;

public class Comment
{
    internal Comment(CommentId id, UserId authorId, string content)
    {
        Id = id;
        AuthorId = authorId;
        Content = content;
    }

    public CommentId Id { get; private set; }
    public PostId PostId { get; private set; }
    public UserId AuthorId { get; private set; }
    public string Content { get; private set; }
}
