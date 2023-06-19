namespace AlphaKids.Domain.Posts;

public interface IPostRepository
{
    void Add(Post post);
    void Remove(Post post);
    void Update(Post post);
    Task<Post> GetById(PostId id);
}
