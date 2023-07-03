using AlphaKids.Application.Categories.Queries;
using AlphaKids.Application.Shared.Categories;
using AlphaKids.Domain.Categories;
using MediatR;

namespace AlphaKids.Application.Categorys.Queries;

internal class GetCategoryQueryHandler : IRequestHandler<GetAllCategoriesQuery, CategoryDto[]>
{
    private readonly ICategoryRepository categoryRepository;

    public GetCategoryQueryHandler(ICategoryRepository categoryRepository)
    {
        this.categoryRepository = categoryRepository;
    }

    public async Task<CategoryDto[]> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await categoryRepository.GetAll();
        var categoryDtos = new List<CategoryDto>();

        foreach (var category in categories)
        {
            categoryDtos.Add(new CategoryDto(category.Id.Value, category.Name));
        }

        return categoryDtos.ToArray();
    }
}
