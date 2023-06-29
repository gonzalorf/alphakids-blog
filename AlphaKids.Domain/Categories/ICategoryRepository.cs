namespace AlphaKids.Domain.Categories;

public interface ICategoryRepository
{
    Task Add(Category category);
    Task Remove(Category category);
    Task<Category> GetById(CategoryId id);
    Task<Category[]> GetByIds(CategoryId[] ids);
    Task<Category[]> GetAll();
}
