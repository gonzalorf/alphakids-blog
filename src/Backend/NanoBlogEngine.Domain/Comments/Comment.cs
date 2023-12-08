using NanoBlogEngine.Domain.Comments.Events;
using NanoBlogEngine.Domain.Posts;
using NanoBlogEngine.Domain.Posts.Events;
using NanoBlogEngine.Domain.SeedWork;
using NanoBlogEngine.Domain.Users;

namespace NanoBlogEngine.Domain.Comments;

public class Comment : Entity<CommentId>
{
    public string Content { get; private set; } = string.Empty;
    public PostId PostId { get; private set; }
    public UserId AuthorId { get; private set; }
 
    private Comment() : base() { }

    private Comment(CommentId id, string content, PostId postId, UserId authorId) : base(id)
    {
        Content = content;
        PostId = postId;
        AuthorId = authorId;
    }

    public static Comment CreateComment(string content, PostId postId, UserId authorId)
    {
        var comment = new Comment(new CommentId(Guid.NewGuid()), content, postId, authorId);
        CommentValidator.ValidateComment(comment);

        comment.AddDomainEvent(new PostCommentedEvent(postId, comment.Id));

        return comment;
    }
}
