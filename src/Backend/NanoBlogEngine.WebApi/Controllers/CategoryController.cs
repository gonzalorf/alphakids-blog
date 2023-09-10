using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NanoBlogEngine.Application.Categories.Commands.Create;
using NanoBlogEngine.Application.Categories.Queries;
using NanoBlogEngine.Domain.Posts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NanoBlogEngine.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly IMediator mediator;
    public CategoryController(IMediator mediator)
    {
        this.mediator = mediator;
    }


    [HttpGet]
    public async Task<IResult> Get()
    {
        try
        {
            return Results.Ok(await mediator.Send(new GetAllCategoriesQuery()));
        }
        catch (PostNotFoundException ex)
        {
            return Results.NotFound(ex.Message);
        }
    }

    [HttpPost, Authorize(Roles = "Administrator")]
    public async Task<IResult> Post([FromBody] CreateCategoryCommand command)
    {
        await mediator.Send(command);

        return Results.Ok();
    }
}
