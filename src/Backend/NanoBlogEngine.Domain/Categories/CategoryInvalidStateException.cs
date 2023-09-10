namespace NanoBlogEngine.Domain.Categories;

public class CategoryInvalidStateException : ApplicationException
{
    public CategoryInvalidStateException(string message) : base(message) { }
}
