namespace NanoBlogEngine.Domain.Categories;

public interface ICategoryRepository
{
    void Add(Category category);
    void Remove(Category category);
    Task<Category> GetById(CategoryId id);
    Task<Category[]> GetByIds(CategoryId[] ids);
    Task<Category[]> GetAll();
}
