using AlphaKids.Domain.Categories;
using AlphaKids.Domain.SeedWork;
using MediatR;

namespace AlphaKids.Application.Categories.Commands.Create;

internal class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand>
{
    private readonly ICategoryRepository categoryRepository;

    public CreateCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        this.categoryRepository = categoryRepository;
    }

    public async Task Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var post = new Category(new CategoryId(Guid.NewGuid())
            , request.Name
            );

        categoryRepository.Add(post);
    }
}
