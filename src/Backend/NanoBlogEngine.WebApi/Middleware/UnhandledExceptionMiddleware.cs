using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace NanoBlogEngine.WebApi.Middleware;

public class UnhandledExceptionMiddleware : IMiddleware
{
    private readonly ILogger<UnhandledExceptionMiddleware> logger;

    public UnhandledExceptionMiddleware(ILogger<UnhandledExceptionMiddleware> logger)
    {
        this.logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);

            context.Response.StatusCode = ex is ApplicationException ? (int)HttpStatusCode.BadRequest : (int)HttpStatusCode.InternalServerError;

            ProblemDetails problem = ex is ApplicationException
                ? new()
                {
                    Status = (int)HttpStatusCode.BadRequest
                    ,
                    Type = "Application exception"
                    ,
                    Title = "Application exception"
                    ,
                    Detail = ex.Message
                }
                : new()
                {
                    Status = (int)HttpStatusCode.InternalServerError
                    ,
                    Type = "Server exception"
                    ,
                    Title = "Server exception"
                    ,
                    Detail = "Internal error"
                };
            var serializedProblem = JsonSerializer.Serialize(problem);

            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(serializedProblem);

        }
    }
}
