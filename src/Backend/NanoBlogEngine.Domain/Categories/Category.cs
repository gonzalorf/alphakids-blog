using NanoBlogEngine.Domain.SeedWork;

namespace NanoBlogEngine.Domain.Categories;

public class Category : Entity<CategoryId>, IAggregateRoot
{
    public string Name { get; private set; }

    private Category(CategoryId id, string name) : base(id)
    {
        Name = name;
    }

    public static Category CreateCategory(string name)
    {
        var category = new Category(new CategoryId(Guid.NewGuid()), name);
        CategoryValidator.ValidateCategory(category);
        return category;
    }
}
