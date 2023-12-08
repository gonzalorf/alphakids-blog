using NanoBlogEngine.Domain.Posts;

namespace NanoBlogEngine.Domain.Rates;

public interface IRateRepository
{
    Task Add(Rate rate);
    void Remove(Rate rate);
    Task<IEnumerable<Rate>> GetByPostId(PostId id);
}
