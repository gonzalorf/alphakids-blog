namespace NanoBlogEngine.BlazorSite.Services.Contracts.BlogService.Responses;


public record PostPreview
    (
    Guid Id
    , string Title
    , string Preview
    , string Content
    , IReadOnlyCollection<Category> Categories
    );
