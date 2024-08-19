using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BuberDinner.Api.Middleware;

public sealed class ErrorHandling(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(context, exception);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var result = JsonSerializer.Serialize(new { error = "An error occurred while processing your request" });
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        await context.Response.WriteAsync(result);
    }
}