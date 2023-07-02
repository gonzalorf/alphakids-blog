using AlphaKids.Application.Users.Commands.Login;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AlphaKids.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IMediator mediator;

    public UserController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost]
    public async Task<IResult> Login([FromBody] LoginCommand command)
    {
        var jwt = await mediator.Send(command);

        return Results.Ok(jwt);
    }
}
