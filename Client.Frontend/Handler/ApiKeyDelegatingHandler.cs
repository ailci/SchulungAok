using Microsoft.Extensions.Options;

namespace Client.Frontend.Handler;

public class ApiKeyDelegatingHandler(IOptions<QotdAppSettings> appSettings) : DelegatingHandler
{
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        //Bevor Request gesendet wird
        request.Headers.Add("x-api-key", appSettings.Value.XApiKey);

        return base.SendAsync(request, cancellationToken);
    }
}