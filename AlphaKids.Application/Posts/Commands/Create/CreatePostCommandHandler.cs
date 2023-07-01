using AlphaKids.Domain.Categories;
using AlphaKids.Domain.Posts;
using AlphaKids.Domain.SeedWork;
using MediatR;

namespace AlphaKids.Application.Posts.Commands.Create;

internal class CreatePostCommandHandler : IRequestHandler<CreatePostCommand>
{
    private readonly IPostRepository postRepository;
    private readonly ICategoryRepository categoryRepository;
    private readonly IUnitOfWork unitOfWork;

    public CreatePostCommandHandler(IPostRepository postRepository, ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    {
        this.postRepository = postRepository;
        this.categoryRepository = categoryRepository;
        this.unitOfWork = unitOfWork;
    }

    public async Task Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var categories = await categoryRepository.GetByIds(request.CategoryIds);

        var post = new Post(new PostId(Guid.NewGuid())
            , request.Title
            , request.Preview
            , request.Content
            , categories.ToList()
            );
        
        PostValidator.ValidatePost(post);

        postRepository.Add(post);

        await unitOfWork.CommitAsync(cancellationToken);
    }
}
