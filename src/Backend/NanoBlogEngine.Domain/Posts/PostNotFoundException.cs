namespace NanoBlogEngine.Domain.Posts;

public sealed class PostNotFoundException : ApplicationException
{
    public PostNotFoundException(PostId id) : base($"Post with id {id.Value} not found.")
    {
    }
}
