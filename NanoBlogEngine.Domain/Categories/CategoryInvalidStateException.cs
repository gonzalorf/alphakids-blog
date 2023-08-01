namespace NanoBlogEngine.Domain.Posts;

public class CategoryInvalidStateException : Exception
{
    public CategoryInvalidStateException(string message) : base(message) { }
}
