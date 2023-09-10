using NanoBlogEngine.Application.Configuration.Queries;

namespace NanoBlogEngine.Application.Posts.Queries;

public record GetPostsPaginatedQuery(int page, int pageSize) : IQuery<IList<PostDto>>;
