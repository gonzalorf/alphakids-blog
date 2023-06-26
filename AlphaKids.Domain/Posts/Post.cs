using AlphaKids.Domain.Categories;
using AlphaKids.Domain.Comments;
using AlphaKids.Domain.Rates;
using AlphaKids.Domain.SeedWork;
using AlphaKids.Domain.Users;

namespace AlphaKids.Domain.Posts;

public class Post : Entity, IAggregateRoot
{
    readonly List<Comment> comments = new();
    readonly List<Category> categories = new();
    readonly List<Rate> rates = new();

    public Post(PostId id, string title, string preview, string content)
    {
        Id = id;
        Title = title;
        Preview = preview;
        Content = content;
    }

    public PostId Id { get; private init; }
    public string Title { get; private set; }
    public string Preview { get; private set; }
    public string Content { get; private set; }
    public IReadOnlyList<Comment> Comments => comments;
    public IReadOnlyList<Category> Categories => categories;
    public IReadOnlyList<Rate> Rates => rates;

    public void Update(string title, string preview, string content)
    {
        Title = title;
        Preview = preview;
        Content = content;
    }

    public void AddComment(User author, string content)
    {

    }

    public void AddCategory(Category category)
    {
        categories.Add(category);
    }
}
