using NanoBlogEngine.Application.Configuration.Commands;
using NanoBlogEngine.Domain.Comments;
using NanoBlogEngine.Domain.Posts;
using NanoBlogEngine.Domain.Posts.Exceptions;
using NanoBlogEngine.Domain.Users;

namespace NanoBlogEngine.Application.Comments.Commands.AddComment;

internal class AddCommentCommandHandler : ICommandHandler<AddCommentCommand>
{
    private readonly IUserRepository userRepository;
    private readonly IPostRepository postRepository;
    private readonly ICommentRepository commentRepository;

    public AddCommentCommandHandler(IUserRepository userRepository, IPostRepository postRepository, ICommentRepository commentRepository)
    {
        this.userRepository = userRepository;
        this.postRepository = postRepository;
        this.commentRepository = commentRepository;
    }

    public async Task Handle(AddCommentCommand request, CancellationToken cancellationToken)
    {
        var post = await postRepository.GetById(request.PostId) ?? throw new PostNotFoundException(request.PostId);

        User? author = null;
        if (request.AuthorId is not null)
        {
            author = await userRepository.GetById(request.AuthorId);
        }

        var comment = Comment.CreateComment(
            request.Content
            , post.Id
            , author is null ? new UserId(Guid.Empty) : author.Id
        );

        await commentRepository.Add(comment);
    }
}
