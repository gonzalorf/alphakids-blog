using AlphaKids.Application.Posts.Create;
using AlphaKids.Domain.Posts;
using AlphaKids.Domain.SeedWork;
using MediatR;

namespace AlphaKids.Application.Posts.Update;

internal class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand>
{
    private readonly IPostRepository postRepository;
    private readonly IUnitOfWork unitOfWork;

    public UpdatePostCommandHandler(IPostRepository postRepository, IUnitOfWork unitOfWork)
    {
        this.postRepository = postRepository;
        this.unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdatePostCommand request, CancellationToken cancellationToken)
    {
        var post = await postRepository.GetById(request.PostId);

        if (post == null)
        {
            throw new PostNotFoundException(request.PostId);
        }

        post.Update(request.Title, request.Preview, request.Content);
        postRepository.Update(post);

        await unitOfWork.CommitAsync(cancellationToken);
    }
}
