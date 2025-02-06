using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shared.DataTransferObjects;
using System.Text.Json;
using Client.Frontend.Services;

namespace Client.Frontend.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IQotdApiService _apiService;
    public QuoteOfTheDayDto? QotdDto { get; set; }

    public IndexModel(ILogger<IndexModel> logger, IHttpClientFactory httpClientFactory, IQotdApiService apiService)
    {
        _logger = logger;
        _httpClientFactory = httpClientFactory;
        _apiService = apiService;
    }

    public async Task OnGet()
    {
        try
        {
            // 1. Version
            //var client = _httpClientFactory.CreateClient("qotdapiservice");
            //var response = await client.GetAsync("qotd"); // BaseUri + Individuelle => localhost:1234/api/qotd
            //response.EnsureSuccessStatusCode();
            //var content = await response.Content.ReadAsStringAsync();
            //QotdDto = JsonSerializer.Deserialize<QuoteOfTheDayDto>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true});

            // 2. Version Abkürzung
            //var client = _httpClientFactory.CreateClient("qotdapiservice");
            //QotdDto = await client.GetFromJsonAsync<QuoteOfTheDayDto>("qotd");

            // 3. Version via Service
            //QotdDto = await _apiService.GetQuoteOfTheDayAsync();
            
            // 4. Version via Service und ApiKey
            QotdDto = await _apiService.GetQuoteOfTheDaySecuredAsync();
        }
        catch (HttpRequestException e)
        {
           _logger.LogError($"{e.StatusCode} ### {e.Message}");
        }
    }
}