using NanoBlogEngine.Domain.Posts;

namespace NanoBlogEngine.Domain.Categories;

public class Category
{
    public CategoryId Id { get; private set; }
    public string Name { get; private set; }

    private Category(CategoryId id, string name)
    {
        Id = id;
        Name = name;
    }

    public static Category CreateCategory(string name)
    {
        var category = new Category(new CategoryId(Guid.NewGuid()), name);
        CategoryValidator.ValidateCategory(category);
        return category;
    }
}
