namespace NanoBlogEngine.Domain.Posts;

public class PostInvalidStateException : ApplicationException
{
    public PostInvalidStateException(string message) : base(message) { }
}
