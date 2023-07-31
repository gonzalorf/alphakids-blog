using AlphaKids.Domain.Posts;
using AlphaKids.Domain.SeedWork;
using AlphaKids.Domain.Users;
using MediatR;

namespace AlphaKids.Application.Posts.Commands.AddRate;

internal class AddRateCommandHandler : IRequestHandler<AddRateCommand>
{
    private readonly IUserRepository userRepository;
    private readonly IPostRepository postRepository;

    public AddRateCommandHandler(IUserRepository userRepository, IPostRepository postRepository)
    {
        this.userRepository = userRepository;
        this.postRepository = postRepository;
    }

    public async Task Handle(AddRateCommand request, CancellationToken cancellationToken)
    {
        var post = await postRepository.GetById(request.PostId) ?? throw new PostNotFoundException(request.PostId);

        User? rater = null;
        if (request.RaterId is not null)
        {
            rater = await userRepository.GetById(request.RaterId);
        }

        post.AddRate(rater, request.Value);
    }
}
