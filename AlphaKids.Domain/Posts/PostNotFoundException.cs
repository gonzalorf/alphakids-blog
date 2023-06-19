namespace AlphaKids.Domain.Posts;

public sealed class PostNotFoundException : Exception
{
    public PostNotFoundException(PostId id) : base($"Post with id {id.Value} not found.")
    {
    }
}
