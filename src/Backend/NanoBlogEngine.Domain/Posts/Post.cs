using NanoBlogEngine.Domain.Categories;
using NanoBlogEngine.Domain.Comments;
using NanoBlogEngine.Domain.Posts.Events;
using NanoBlogEngine.Domain.Rates;
using NanoBlogEngine.Domain.SeedWork;
using NanoBlogEngine.Domain.Users;

namespace NanoBlogEngine.Domain.Posts;

public class Post : AuditableEntity<PostId>, IAggregateRoot
{
    private readonly List<Category> categories = new();

    public string Title { get; private set; } = string.Empty;
    public string Preview { get; private set; } = string.Empty;
    public string Content { get; private set; } = string.Empty;
    public IReadOnlyCollection<Category> Categories => categories.AsReadOnly();

    private Post() : base() { }

    private Post(PostId id
        , string title
        , string preview
        , string content
        , IReadOnlyCollection<Category> categories) : base(id)
    {
        Title = title;
        Preview = preview;
        Content = content;
        foreach (var c in categories)
        {
            AddCategory(c);
        }
    }

    public static Post CreatePost(string title, string preview, string content, IReadOnlyCollection<Category> categories)
    {
        var post = new Post(new PostId(Guid.NewGuid()), title, preview, content, categories);
        PostValidator.ValidatePost(post);
        return post;
    }

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

    public void AddCategory(Category category)
    {
        categories.Add(category);
    }

    public void RemoveCategory(Category category)
    {
        _ = categories.Remove(category);
    }
}