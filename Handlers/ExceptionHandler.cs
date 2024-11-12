using System.Net;
using dotnet_ResultPattern.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_ResultPattern.Handlers;

public class ExceptionHandler : IExceptionHandler
{
    private readonly ILogger<ExceptionHandler> _logger;

    public ExceptionHandler(ILogger<ExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, 
                                          Exception exception,
                                          CancellationToken cancellationToken)
    {
        var problemDetails  = exception switch
        {
            NotFoundException nf => new ProblemDetails
            {
                Title = "Not Found",
                Detail = nf.Message,
                Status = StatusCodes.Status404NotFound,
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4",
            },
            BadRequestException br => new ProblemDetails
            {
                Title = "Bad Request",
                Detail = br.Message,
                Status = StatusCodes.Status400BadRequest,
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                Extensions = new Dictionary<string, object?>
                {
                    { "errors", br.Errors }
                }
            },
            ArgumentException ex => new ProblemDetails
            {
                Title = "Bad Request",
                Detail = ex.Message,
                Status = (int)HttpStatusCode.BadRequest
            },
            _ => new ProblemDetails
            {
                Title = "Internal Server Error",
                Detail = exception.Message,
                Status = StatusCodes.Status500InternalServerError,
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
            }
        };

        httpContext.Response.StatusCode = problemDetails.Status!.Value;

        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
        return true;
    }
}