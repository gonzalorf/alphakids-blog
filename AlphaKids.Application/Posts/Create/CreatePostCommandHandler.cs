using AlphaKids.Domain.Posts;
using AlphaKids.Domain.SeedWork;
using MediatR;

namespace AlphaKids.Application.Posts.Create;

internal class CreatePostCommandHandler : IRequestHandler<CreatePostCommand>
{
    private readonly IPostRepository postRepository;
    private readonly IUnitOfWork unitOfWork;

    public CreatePostCommandHandler(IPostRepository postRepository, IUnitOfWork unitOfWork)
    {
        this.postRepository = postRepository;
        this.unitOfWork = unitOfWork;
    }

    public async Task Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var post = new Post(new PostId(Guid.NewGuid())
            , request.Title
            , request.Preview
            , request.Content
            );

        postRepository.Add(post);

        await unitOfWork.CommitAsync(cancellationToken);
    }
}
