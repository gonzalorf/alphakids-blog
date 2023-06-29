using AlphaKids.Application.Categories.Commands.Create;
using AlphaKids.Domain.Categories;
using AlphaKids.Domain.Posts;
using AlphaKids.Domain.SeedWork;
using MediatR;

namespace AlphaKids.Application.Posts.Commands.Create;

internal class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand>
{
    private readonly ICategoryRepository categoryRepository;
    private readonly IUnitOfWork unitOfWork;

    public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    {
        this.categoryRepository = categoryRepository;
        this.unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var post = new Category(new CategoryId(Guid.NewGuid())
            , request.Name
            );

        categoryRepository.Add(post);

        await unitOfWork.CommitAsync(cancellationToken);
    }
}
