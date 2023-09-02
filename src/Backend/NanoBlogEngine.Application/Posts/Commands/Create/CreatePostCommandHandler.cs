using NanoBlogEngine.Application.Configuration.Commands;
using NanoBlogEngine.Domain.Categories;
using NanoBlogEngine.Domain.Posts;
using NanoBlogEngine.Domain.Posts.Events;

namespace NanoBlogEngine.Application.Posts.Commands.Create;

internal class CreatePostCommandHandler : ICommandHandler<CreatePostCommand, PostId>
{
    private readonly IPostRepository postRepository;
    private readonly ICategoryRepository categoryRepository;

    public CreatePostCommandHandler(IPostRepository postRepository, ICategoryRepository categoryRepository)
    {
        this.postRepository = postRepository;
        this.categoryRepository = categoryRepository;
    }

    public async Task<PostId> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var categories = await categoryRepository.GetByIds(request.CategoryIds);

        var post = Post.CreatePost(request.Title
            , request.Preview
            , request.Content
            , categories.ToList()
            );

        await postRepository.Add(post);

        post.AddDomainEvent(new PostCreatedEvent(post.Id));

        return post.Id;
    }
}
