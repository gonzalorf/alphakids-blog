namespace AlphaKids.Domain.Posts;

public class PostInvalidStateException : Exception
{
    public PostInvalidStateException(string message) : base(message) { }
}
