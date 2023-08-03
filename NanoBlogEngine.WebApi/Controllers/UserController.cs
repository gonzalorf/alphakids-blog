using NanoBlogEngine.Application.Users.Commands.Login;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace NanoBlogEngine.WebApi.Controllers;

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
    [AllowAnonymous]
    public async Task<IResult> Login([FromBody] LoginCommand command)
    {
        var jwt = await mediator.Send(command);

        return Results.Ok(jwt);
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IResult> Signup([FromBody] LoginCommand command)
    {
        var jwt = await mediator.Send(command);

        return Results.Ok(jwt);
    }
}
