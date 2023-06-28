using AlphaKids.Domain.Posts;
using AlphaKids.Domain.SeedWork;
using AlphaKids.Domain.Users;
using MediatR;

namespace AlphaKids.Application.Posts.Commands.AddComment;

internal class AddCommentCommandHandler : IRequestHandler<AddCommentCommand>
{
    private readonly IUserRepository userRepository;
    private readonly IPostRepository postRepository;
    private readonly IUnitOfWork unitOfWork;

    public AddCommentCommandHandler(IUserRepository userRepository, IPostRepository postRepository, IUnitOfWork unitOfWork)
    {
        this.userRepository = userRepository;
        this.postRepository = postRepository;
        this.unitOfWork = unitOfWork;
    }

    public async Task Handle(AddCommentCommand request, CancellationToken cancellationToken)
    {
        var post = await postRepository.GetById(request.PostId);

        User rater = null;
        if (request.AuthorId is not null)
        {
            rater = await userRepository.GetById(request.AuthorId);
        }

        post.AddComment(rater, request.Content);

        await unitOfWork.CommitAsync(cancellationToken);
    }
}
