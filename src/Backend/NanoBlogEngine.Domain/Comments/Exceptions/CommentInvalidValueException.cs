namespace NanoBlogEngine.Domain.Posts.Exceptions;

public class CommentInvalidValueException : ApplicationException
{
    public CommentInvalidValueException(string message) : base(message) { }
}
