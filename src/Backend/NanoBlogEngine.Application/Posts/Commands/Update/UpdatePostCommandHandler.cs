using NanoBlogEngine.Application.Configuration.Commands;
using NanoBlogEngine.Domain.Categories;
using NanoBlogEngine.Domain.Posts;
using NanoBlogEngine.Domain.Posts.Exceptions;

namespace NanoBlogEngine.Application.Posts.Commands.Update;

internal class UpdatePostCommandHandler : ICommandHandler<UpdatePostCommand>
{
    private readonly IPostRepository postRepository;
    private readonly ICategoryRepository categoryRepository;

    public UpdatePostCommandHandler(IPostRepository postRepository, ICategoryRepository categoryRepository)
    {
        this.postRepository = postRepository;
        this.categoryRepository = categoryRepository;
    }

    public async Task Handle(UpdatePostCommand request, CancellationToken cancellationToken)
    {
        var post = await postRepository.GetById(request.PostId) ?? throw new PostNotFoundException(request.PostId);

        var categories = await categoryRepository.GetByIds(request.CategoryIds);

        post.UpdateProperties(request.Title, request.Preview, request.Content, categories);

        PostValidator.ValidatePost(post);

        postRepository.Update(post);
    }
}
