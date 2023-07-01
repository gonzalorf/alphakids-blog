using AlphaKids.Application.Shared.Posts;
using AlphaKids.Domain.Posts;
using MediatR;

namespace AlphaKids.Application.Posts.Queries;

internal class GetPostQueryHandler : IRequestHandler<GetPostQuery, PostDto>
{
    private readonly IPostRepository postRepository;

    public GetPostQueryHandler(IPostRepository postRepository)
    {
        this.postRepository = postRepository;
    }

    public async Task<PostDto> Handle(GetPostQuery request, CancellationToken cancellationToken)
    {
        var post = await postRepository.GetById(request.PostId) ?? throw new PostNotFoundException(request.PostId);
        
        return new PostDto(
            post.Id.Value
            , post.Title
            , post.Preview
            , post.Content
            , 0
            , new List<CommentDto>()
            );
    }
}
