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

    private Post() { }

    public Post(PostId id, string title, string preview, string content, IReadOnlyCollection<Category> categories)
    {
        Id = id;
        Title = title;
        Preview = preview;
        Content = content;
        foreach (var c in categories) AddCategory(c);
    }

    public PostId Id { get; private init; }
    public string Title { get; private set; }
    public string Preview { get; private set; }
    public string Content { get; private set; }
    public IReadOnlyCollection<Comment> Comments => comments.AsReadOnly();
    public IReadOnlyCollection<Category> Categories => categories.AsReadOnly();
    public IReadOnlyCollection<Rate> Rates => rates.AsReadOnly();

    public void Update(string title, string preview, string content, Category[] categories)
    {
        Title = title;
        Preview = preview;
        Content = content;

        foreach (var category in categories)
        {
            if (!Categories.Contains(category)) AddCategory(category);
        }

        foreach (var category in Categories)
        {
            if (!categories.ToList().Contains(category)) RemoveCategory(category);
        }
    }

    public void AddRate(User? author, int value)
    {
        var rate = new Rate(
            new RateId(Guid.NewGuid())
            , Id
            , value
            , author is not null ? author.Id : null);

        rates.Add(rate);
    }

    public void AddComment(User? author, string content)
    {
        var comment = new Comment(
            new CommentId(Guid.NewGuid())
            , Id
            , content
            , author is not null ? author.Id : null);

        comments.Add(comment);
    }

    public void AddCategory(Category category)
    {
        categories.Add(category);
    }

    public void RemoveCategory(Category category)
    {
        categories.Remove(category);
    }
}
