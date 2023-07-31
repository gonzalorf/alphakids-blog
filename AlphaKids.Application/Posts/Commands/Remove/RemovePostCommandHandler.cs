using AlphaKids.Domain.Posts;
using AlphaKids.Domain.SeedWork;
using MediatR;

namespace AlphaKids.Application.Posts.Commands.Remove;

internal class RemovePostCommandHandler : IRequestHandler<RemovePostCommand>
{
    private readonly IPostRepository postRepository;

    public RemovePostCommandHandler(IPostRepository postRepository)
    {
        this.postRepository = postRepository;
    }

    public async Task Handle(RemovePostCommand request, CancellationToken cancellationToken)
    {
        var post = await postRepository.GetById(request.PostId);

        if (post == null)
        {
            throw new PostNotFoundException(request.PostId);
        }

        postRepository.Remove(post);
    }
}
