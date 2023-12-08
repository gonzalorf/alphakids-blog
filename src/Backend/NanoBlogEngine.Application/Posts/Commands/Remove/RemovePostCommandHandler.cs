using NanoBlogEngine.Application.Configuration.Commands;
using NanoBlogEngine.Domain.Posts;
using NanoBlogEngine.Domain.Posts.Exceptions;

namespace NanoBlogEngine.Application.Posts.Commands.Remove;

internal class RemovePostCommandHandler : ICommandHandler<RemovePostCommand>
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
