using AlphaKids.Domain.Categories;
using AlphaKids.Domain.SeedWork;
using AlphaKids.Domain.Users;

namespace AlphaKids.Domain.Posts;

public class Post : Entity, IAggregateRoot
{
    private readonly List<Comment> comments = new();
    private readonly List<Category> categories = new();
    private readonly List<Rate> rates = new();

    private Post() { }

    public Post(PostId id, string title, string preview, string content, IReadOnlyCollection<Category> categories)
    {
        Id = id;
        Title = title;
        Preview = preview;
        Content = content;
        foreach (var c in categories)
        {
            AddCategory(c);
        }
    }

    public PostId Id { get; private init; }
    public string Title { get; private set; }
    public string Preview { get; private set; }
    public string Content { get; private set; }
    public IReadOnlyCollection<Comment> Comments => comments.AsReadOnly();
    public IReadOnlyCollection<Category> Categories => categories.AsReadOnly();
    public IReadOnlyCollection<Rate> Rates => rates.AsReadOnly();

    public void UpdateProperties(string title, string preview, string content, Category[] categories)
    {
        Title = title;
        Preview = preview;
        Content = content;

        var categoriesToAdd = categories.Except(Categories).ToArray();
        foreach (var category in categoriesToAdd)
        {
            AddCategory(category);
        }

        var categoriesToRemove = Categories.Except(categories).ToArray();
        foreach (var category in categoriesToRemove)
        {
            RemoveCategory(category);
        }
    }

    public void AddRate(User? author, int value)
    {

        var rate = new Rate(
            new RateId(Guid.NewGuid())
            , value
            , author);

        RateValidator.ValidateRate(rate);

        rates.Add(rate);
    }

    public void AddComment(User? author, string content)
    {
        var comment = new Comment(
            new CommentId(Guid.NewGuid())
            , content
            , author);

        comments.Add(comment);
    }

    public void AddCategory(Category category)
    {
        categories.Add(category);
    }

    public void RemoveCategory(Category category)
    {
        _ = categories.Remove(category);
    }
}
