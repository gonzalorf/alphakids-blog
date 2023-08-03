using NanoBlogEngine.Application.Configuration.Commands;
using NanoBlogEngine.Domain.Categories;

namespace NanoBlogEngine.Application.Categories.Commands.Create;

internal class CreateCategoryCommandHandler : ICommandHandler<CreateCategoryCommand>
{
    private readonly ICategoryRepository categoryRepository;

    public CreateCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        this.categoryRepository = categoryRepository;
    }

    public Task Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = Category.CreateCategory(request.Name);

        categoryRepository.Add(category);

        return Task.CompletedTask;
    }
}
