namespace NanoBlogEngine.Domain.Posts;

public interface IPostRepository
{
    Task Add(Post post);
    void Remove(Post post);
    void Update(Post post);
    Task<Post?> GetById(PostId id);
}
