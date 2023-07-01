using AlphaKids.Application.Categories.Commands.Create;
using AlphaKids.Application.Categories.Queries;
using AlphaKids.Domain.Posts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlphaKids.WebApi.Controllers
{
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

        [HttpPost]
        public async Task<IResult> Post([FromBody] CreateCategoryCommand command)
        {
            await mediator.Send(command);

            return Results.Ok();
        }
    }
}
