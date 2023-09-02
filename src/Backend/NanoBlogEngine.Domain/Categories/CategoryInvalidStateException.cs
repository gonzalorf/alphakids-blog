namespace NanoBlogEngine.Domain.Posts;

public class CategoryInvalidStateException : ApplicationException
{
    public CategoryInvalidStateException(string message) : base(message) { }
}
