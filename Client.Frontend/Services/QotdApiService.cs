using Shared.DataTransferObjects;
using System.Net.Http;

namespace Client.Frontend.Services;

public class QotdApiService(ILogger<QotdApiService> logger, IHttpClientFactory httpClientFactory) : IQotdApiService
{
    private const string QotdUri = "qotd";

    public async Task<QuoteOfTheDayDto> GetQuoteOfTheDayAsync()
    {
        logger.LogInformation($"{nameof(GetQuoteOfTheDayAsync)} aufgerufen...");

        var client = httpClientFactory.CreateClient("qotdapiservice");

        var response = await client.GetFromJsonAsync<QuoteOfTheDayDto>(QotdUri);
        if (response is null) throw new HttpRequestException("Konnte Qotd nicht holen");

        return response;
    }
}