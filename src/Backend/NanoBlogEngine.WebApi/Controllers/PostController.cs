using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NanoBlogEngine.Application.Posts.Commands.AddComment;
using NanoBlogEngine.Application.Posts.Commands.AddRate;
using NanoBlogEngine.Application.Posts.Commands.Create;
using NanoBlogEngine.Application.Posts.Commands.Remove;
using NanoBlogEngine.Application.Posts.Commands.Update;
using NanoBlogEngine.Application.Posts.Queries;
using NanoBlogEngine.Domain.Posts;

namespace NanoBlogEngine.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostController : ControllerBase
{
    private readonly IMediator mediator;

    public PostController(IMediator mediator)
    {
        this.mediator = mediator;
    }


    [HttpGet("{id}")]
    public async Task<IResult> Get(Guid id)
    {
        try
        {
            return Results.Ok(await mediator.Send(new GetPostQuery(new PostId(id))));
        }
        catch (PostNotFoundException ex)
        {
            return Results.NotFound(ex.Message);
        }
    }

    [HttpPost, Authorize(Roles = "Administrator")]
    public async Task<IResult> Post([FromBody] CreatePostCommand command)
    {
        var postId = await mediator.Send(command);

        return Results.Ok(postId);
    }

    [HttpPut("{id}"), Authorize(Roles = "Administrator")]
    public async Task<IResult> Put(Guid id, [FromBody] UpdatePostRequest request)
    {
        try
        {
            var command = new UpdatePostCommand(
                new PostId(id)
                , request.Title
                , request.Preview
                , request.Content
                , request.CategoryIds
                );

            await mediator.Send(command);

            return Results.Ok();
        }
        catch (PostNotFoundException ex)
        {
            return Results.NotFound(ex.Message);
        }
    }

    [HttpDelete("{id}"), Authorize(Roles = "Administrator")]
    public async Task<IResult> Delete(Guid id)
    {
        try
        {
            await mediator.Send(new RemovePostCommand(new PostId(id)));

            return Results.Ok();
        }
        catch (PostNotFoundException ex)
        {
            return Results.NotFound(ex.Message);
        }
    }

    [HttpPost, Route("RatePost"), Authorize(Roles = "Administrator,BlogReader")]
    public async Task<IResult> RatePost([FromBody] AddRateCommand command)
    {
        await mediator.Send(command);

        return Results.Ok();
    }

    [HttpPost, Route("CommentPost"), Authorize(Roles = "Administrator,BlogReader")]
    public async Task<IResult> CommentPost([FromBody] AddCommentCommand command)
    {
        await mediator.Send(command);

        return Results.Ok();
    }
}
