using AlphaKids.Application.Shared.Posts;
using MediatR;

namespace AlphaKids.Application.Posts.Queries
{
    public record GetPostsPaginatedQuery(int page, int pageSize) : IRequest<IList<PostDto>>;
}
