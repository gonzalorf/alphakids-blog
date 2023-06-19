using AlphaKids.Domain.Categories;
using AlphaKids.Domain.Comments;

namespace AlphaKids.Domain.Posts;

public class Post
{
    public Post(PostId id, string title, string preview, string content)
    {
        Id = id;
        Title = title;
        Preview = preview;
        Content = content;
    }

    public PostId Id { get; private set; }
    public string Title { get; private set; }
    public string Preview { get; private set; }
    public string Content { get; private set; }
    public IList<Comment> Comments { get; private set; } = new List<Comment>();
    public IList<Category> Categories { get; private set; } = new List<Category>();

    public void Update(string title, string preview, string content)
    {
        Title = title;
        Preview = preview;
        Content = content;
    }
}
