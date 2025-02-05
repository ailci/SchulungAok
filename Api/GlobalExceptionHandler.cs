using System.Net;
using Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Api;

public class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;
    private readonly IProblemDetailsService _problemDetailsService;

    public GlobalExceptionHandler(IProblemDetailsService problemDetailsService, ILogger<GlobalExceptionHandler> logger)
    {
        _problemDetailsService = problemDetailsService;
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        httpContext.Response.ContentType = "application/json";

        httpContext.Response.StatusCode = exception switch
        {
            NotFoundException => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError
        };

        _logger.LogError($"Something went wrong: {exception.Message}");

        var result = await _problemDetailsService.TryWriteAsync(new ProblemDetailsContext
        {
            HttpContext = httpContext,
            ProblemDetails =
            {
                Title = "An error occurred",
                Status = httpContext.Response.StatusCode,
                Detail = exception.Message,
                Type = exception.GetType().Name
            },
            Exception = exception
        });

        if (!result)
        {
            await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
            {
                Title = "An error occurred",
                Status = httpContext.Response.StatusCode,
                Detail = exception.Message,
                Type = exception.GetType().Name
            });
        }

        return true;
    }
}