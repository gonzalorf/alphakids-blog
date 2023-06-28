using AlphaKids.Domain.Categories;
using AlphaKids.Domain.Posts;
using AlphaKids.Domain.SeedWork;
using MediatR;

namespace AlphaKids.Application.Posts.Commands.Update;

internal class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand>
{
    private readonly IPostRepository postRepository;
    private readonly ICategoryRepository categoryRepository;
    private readonly IUnitOfWork unitOfWork;

    public UpdatePostCommandHandler(IPostRepository postRepository, ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    {
        this.postRepository = postRepository;
        this.categoryRepository = categoryRepository;
        this.unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdatePostCommand request, CancellationToken cancellationToken)
    {
        var post = await postRepository.GetById(request.PostId);

        if (post == null)
        {
            throw new PostNotFoundException(request.PostId);
        }

        var categories = await categoryRepository.GetByIds(request.CategoryIds);

        post.Update(request.Title, request.Preview, request.Content, categories);        

        postRepository.Update(post);

        await unitOfWork.CommitAsync(cancellationToken);
    }
}
