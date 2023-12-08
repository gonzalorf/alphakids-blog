using NanoBlogEngine.Domain.Posts;
using NanoBlogEngine.Domain.Posts.Events;
using NanoBlogEngine.Domain.SeedWork;
using NanoBlogEngine.Domain.Users;

namespace NanoBlogEngine.Domain.Rates;

public class Rate : Entity<RateId>, IAggregateRoot
{
    public int Value { get; private set; }
    public PostId PostId { get; private set; }
    public UserId RaterId { get; private set; }
    private Rate() : base() { }

    internal Rate(RateId id, int value, PostId postId, UserId raterId) : base(id)
    {
        Value = value;
        PostId = postId;
        RaterId = raterId;
    }

    public static Rate CreateRate(int value, PostId postId, UserId raterId)
    {
        var rate = new Rate(
            new RateId(Guid.NewGuid())
            , value
            , postId
            , raterId);

        RateValidator.ValidateRate(rate);

        rate.AddDomainEvent(new PostRatedEvent(postId));

        return rate;
    }
}
