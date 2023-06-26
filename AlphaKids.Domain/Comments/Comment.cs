using AlphaKids.Domain.Posts;
using AlphaKids.Domain.Users;

namespace AlphaKids.Domain.Comments;

public class Comment
{
    internal Comment(CommentId id, PostId postId, string content, UserId? authorId)
    {
        Id = id;
        Content = content;
        AuthorId = authorId;
        PostId = postId;
    }

    public CommentId Id { get; private set; }
    public PostId PostId { get; private set; }
    public string Content { get; private set; }
    public UserId? AuthorId { get; private set; }
}
