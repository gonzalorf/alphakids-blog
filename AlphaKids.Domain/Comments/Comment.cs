using AlphaKids.Domain.Users;

namespace AlphaKids.Domain.Comments;

public class Comment
{
    public Comment(CommentId id, User author, string content)
    {
        Id = id;
        Author = author;
        Content = content;
    }

    public CommentId Id { get; private set; }
    public User Author { get; private set; }
    public string Content { get; private set; }
}
