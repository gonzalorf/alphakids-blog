using AlphaKids.Domain.Posts;
using AlphaKids.Domain.Users;

namespace AlphaKids.Domain.Rates;

public class Rate
{
    public Rate() { }

    public Rate(RateId id, PostId postId, int value, UserId? raterId)
    {
        Id = id;
        PostId = postId;
        Value = value;
        RaterId = raterId;
    }

    public RateId Id { get; private set; }
    public PostId PostId { get; private set; }
    public int Value { get; private set; }
    public UserId? RaterId { get; private set; }
}
