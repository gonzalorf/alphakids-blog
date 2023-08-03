using NanoBlogEngine.Application.Configuration.Queries;
using NanoBlogEngine.Domain.Posts;

namespace NanoBlogEngine.Application.Posts.Queries;

public record GetPostQuery(PostId PostId) : IQuery<PostDto>;
