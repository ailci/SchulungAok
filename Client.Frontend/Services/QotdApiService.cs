using Shared.DataTransferObjects;
using System.Net.Http;
using Microsoft.Extensions.Options;

namespace Client.Frontend.Services;

public class QotdApiService(ILogger<QotdApiService> logger, HttpClient client, IOptions<QotdAppSettings> appSettings) : IQotdApiService
{
    private readonly QotdAppSettings _appSettings = appSettings.Value;
    private const string QotdUri = "qotd";

    public async Task<QuoteOfTheDayDto> GetQuoteOfTheDayAsync()
    {
        logger.LogInformation($"{nameof(GetQuoteOfTheDayAsync)} aufgerufen...");
        
        var response = await client.GetFromJsonAsync<QuoteOfTheDayDto>(QotdUri);
        if (response is null) throw new HttpRequestException("Konnte Qotd nicht holen");

        return response;
    }
}