using AlphaKids.Domain.Posts;
using MediatR;

namespace AlphaKids.Application.Posts.Get;

public record GetPostQuery(PostId PostId) : IRequest<PostDto>;
