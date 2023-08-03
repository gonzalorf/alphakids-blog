using NanoBlogEngine.Application.Configuration.Commands;
using NanoBlogEngine.Domain.Posts;
using NanoBlogEngine.Domain.Users;

namespace NanoBlogEngine.Application.Posts.Commands.AddComment;

internal class AddCommentCommandHandler : ICommandHandler<AddCommentCommand>
{
    private readonly IUserRepository userRepository;
    private readonly IPostRepository postRepository;

    public AddCommentCommandHandler(IUserRepository userRepository, IPostRepository postRepository)
    {
        this.userRepository = userRepository;
        this.postRepository = postRepository;
    }

    public async Task Handle(AddCommentCommand request, CancellationToken cancellationToken)
    {
        var post = await postRepository.GetById(request.PostId);

        User? rater = null;
        if (request.AuthorId is not null)
        {
            rater = await userRepository.GetById(request.AuthorId);
        }

        post.AddComment(rater, request.Content);
    }
}
