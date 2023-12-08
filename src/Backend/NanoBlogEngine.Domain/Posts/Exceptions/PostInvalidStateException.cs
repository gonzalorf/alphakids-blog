namespace NanoBlogEngine.Domain.Posts.Exceptions;

public class PostInvalidStateException : ApplicationException
{
    public PostInvalidStateException(string message) : base(message) { }
}
