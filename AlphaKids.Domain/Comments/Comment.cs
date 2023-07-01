using AlphaKids.Domain.Posts;
using AlphaKids.Domain.Users;

namespace AlphaKids.Domain.Comments;

public class Comment
{
    private Comment() { }

    internal Comment(CommentId id, /*PostId postId, */string content, User? author)
    {
        Id = id;
        Content = content;
        Author = author;
        //PostId = postId;
    }

    public CommentId Id { get; private set; }
    //public PostId PostId { get; private set; }
    public string Content { get; private set; }
    public User? Author { get; private set; }
}
