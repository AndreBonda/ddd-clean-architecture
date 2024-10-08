using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BuberDinner.Api.Filter;

public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
{
    /// <summary>
    /// Catch unhandled exception
    /// </summary>
    /// <param name="context"></param>
    public override void OnException(ExceptionContext context)
    {
        var exception = context.Exception;
        // Log the exception
        Console.WriteLine(exception);
        ProblemDetails problemDetails = new()
        {
            Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
            Title = "An error occurred while processing your request.",
            Status = (int)HttpStatusCode.InternalServerError
        };
        context.Result = new ObjectResult(problemDetails);
        context.ExceptionHandled = true;
    }
}