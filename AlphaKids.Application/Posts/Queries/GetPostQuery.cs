using AlphaKids.Domain.Posts;
using MediatR;

namespace AlphaKids.Application.Posts.Queries;

public record GetPostQuery(PostId PostId) : IRequest<PostDto>;
