using NanoBlogEngine.Application.Configuration.Queries;

namespace NanoBlogEngine.Application.Categories.Queries;

public record GetAllCategoriesQuery() : IQuery<CategoryDto[]>;
