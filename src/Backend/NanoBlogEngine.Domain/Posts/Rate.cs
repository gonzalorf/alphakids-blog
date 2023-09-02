using NanoBlogEngine.Domain.SeedWork;
using NanoBlogEngine.Domain.Users;

namespace NanoBlogEngine.Domain.Posts;

public class Rate : Entity<RateId>
{
    private Rate() : base() { }

    internal Rate(RateId id, int value, User? rater) : base(id)
    {
        Value = value;
        Rater = rater;
    }

    public int Value { get; private set; }
    public User? Rater { get; private set; }
}
