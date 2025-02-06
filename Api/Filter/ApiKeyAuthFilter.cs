using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Filter;

// Variante via Filter. Registrieren in ServiceCollection 
public class ApiKeyAuthFilter(IConfiguration configuration) : IAuthorizationFilter
{
    private const string ApiKeyName = "x-api-key";

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        //kein Api-Key übermittelt
        if (!context.HttpContext.Request.Headers.TryGetValue(ApiKeyName, out var requestApiKey))
        {
            context.Result = new UnauthorizedObjectResult("Api-Key fehlt");
            return;
        }

        var apiKey = configuration.GetValue<string>(ApiKeyName);

        //Invalider Api Key
        if (!requestApiKey.Equals(apiKey))
        {
            context.Result = new UnauthorizedObjectResult("Invalid Api-Key");
        }
    }
}