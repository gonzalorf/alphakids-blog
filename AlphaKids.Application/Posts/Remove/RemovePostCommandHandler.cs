using AlphaKids.Application.Posts.Create;
using AlphaKids.Domain.Posts;
using AlphaKids.Domain.SeedWork;
using MediatR;

namespace AlphaKids.Application.Posts.Remove;

internal class RemovePostCommandHandler : IRequestHandler<RemovePostCommand>
{
    private readonly IPostRepository postRepository;
    private readonly IUnitOfWork unitOfWork;

    public RemovePostCommandHandler(IPostRepository postRepository, IUnitOfWork unitOfWork)
    {
        this.postRepository = postRepository;
        this.unitOfWork = unitOfWork;
    }

    public async Task Handle(RemovePostCommand request, CancellationToken cancellationToken)
    {
        var post = await postRepository.GetById(request.PostId);

        if(post == null)
        {
            throw new PostNotFoundException(request.PostId);
        }

        postRepository.Remove(post);

        await unitOfWork.CommitAsync(cancellationToken);
    }
}
