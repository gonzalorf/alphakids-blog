using NanoBlogEngine.Application.Configuration.Commands;
using NanoBlogEngine.Domain.Comments;
using NanoBlogEngine.Domain.Posts;
using NanoBlogEngine.Domain.Posts.Exceptions;
using NanoBlogEngine.Domain.Rates;
using NanoBlogEngine.Domain.Users;

namespace NanoBlogEngine.Application.Rates.Commands.AddRate;

internal class AddRateCommandHandler : ICommandHandler<AddRateCommand>
{
    private readonly IUserRepository userRepository;
    private readonly IPostRepository postRepository;
    private readonly IRateRepository rateRepository;

    public AddRateCommandHandler(IUserRepository userRepository, IPostRepository postRepository, IRateRepository rateRepository)
    {
        this.userRepository = userRepository;
        this.postRepository = postRepository;
        this.rateRepository = rateRepository;
    }

    public async Task Handle(AddRateCommand request, CancellationToken cancellationToken)
    {
        var post = await postRepository.GetById(request.PostId) ?? throw new PostNotFoundException(request.PostId);

        User? rater = null;
        if (request.RaterId is not null)
        {
            rater = await userRepository.GetById(request.RaterId);
        }

        var rate = Rate.CreateRate(
            request.Value
            , post.Id
            , rater is null ? new UserId(Guid.Empty) : rater.Id
        );

        await rateRepository.Add(rate);
    }
}
