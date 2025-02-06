using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Api.Middleware;

// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
public class ApiKeyAuthMiddleware(RequestDelegate next, IConfiguration configuration)
{
    private const string ApiKeyName = "x-api-key";

    public async Task Invoke(HttpContext httpContext)
    {
        //kein Api-Key übermittelt
        if (!httpContext.Request.Headers.TryGetValue(ApiKeyName, out var requestApiKey))
        {
            httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await httpContext.Response.WriteAsync("ApiKey fehlt! (Middleware)");
            return;
        }

        var apiKey = configuration.GetValue<string>(ApiKeyName);

        //Invalider Api Key
        if (!requestApiKey.Equals(apiKey))
        {
            httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await httpContext.Response.WriteAsync("Invalid ApiKey fehlt! (Middleware)");
            return;
        }

        await next(httpContext);
    }
}

// Extension method used to add the middleware to the HTTP request pipeline.
public static class ApiKeyAuthMiddlewareExtensions
{
    public static IApplicationBuilder UseApiKeyAuthMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ApiKeyAuthMiddleware>();
    }
}