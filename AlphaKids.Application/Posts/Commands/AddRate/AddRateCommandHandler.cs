using AlphaKids.Application.Posts.Commands.AddRate;
using AlphaKids.Domain.Posts;
using AlphaKids.Domain.SeedWork;
using AlphaKids.Domain.Users;
using MediatR;

namespace AlphaKids.Application.Posts.Commands.Create;

internal class AddRateCommandHandler : IRequestHandler<AddRateCommand>
{
    private readonly IUserRepository userRepository;
    private readonly IPostRepository postRepository;
    private readonly IUnitOfWork unitOfWork;

    public AddRateCommandHandler(IUserRepository userRepository, IPostRepository postRepository, IUnitOfWork unitOfWork)
    {
        this.userRepository = userRepository;
        this.postRepository = postRepository;
        this.unitOfWork = unitOfWork;
    }

    public async Task Handle(AddRateCommand request, CancellationToken cancellationToken)
    {
        var post = await postRepository.GetById(request.PostId) ?? throw new PostNotFoundException(request.PostId);

        User rater = null;
        if (request.RaterId is not null)
        {
            rater = await userRepository.GetById(request.RaterId);
        }

        post.AddRate(rater, request.Value);

        await unitOfWork.CommitAsync(cancellationToken);
    }
}
