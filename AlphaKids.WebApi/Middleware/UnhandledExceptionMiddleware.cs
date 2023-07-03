using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace AlphaKids.WebApi.Middleware;

public class UnhandledExceptionMiddleware : IMiddleware
{
    readonly ILogger<UnhandledExceptionMiddleware> logger;

    public UnhandledExceptionMiddleware(ILogger<UnhandledExceptionMiddleware> logger) => this.logger = logger;

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            //logger.LogError(ex, ex.Message);
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            ProblemDetails problem;

            if (ex is ApplicationException)
            {
                problem = new()
                {
                    Status = (int)HttpStatusCode.BadRequest
                    ,
                    Type = "Application exception"
                    ,
                    Title = "Application exception"
                    ,
                    Detail = ex.Message
                };
            }
            else
            {
                problem = new()
                {
                    Status = (int)HttpStatusCode.InternalServerError
                    ,
                    Type = "Server exception"
                    ,
                    Title = "Server exception"
                    ,
                    Detail = "Internal error"
                };
            }

            var serializedProblem = JsonSerializer.Serialize(problem);

            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(serializedProblem);

        }
    }
}
