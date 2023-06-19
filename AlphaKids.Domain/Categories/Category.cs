namespace AlphaKids.Domain.Categories;

public class Category
{
    public Category(CategoryId id, string name)
    {
        Id = id;
        Name = name;
    }

    public CategoryId Id { get; private set; }
    public string Name { get; private set; }
}
