using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shared.DataTransferObjects;
using System.Text.Json;

namespace Client.Frontend.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IHttpClientFactory _httpClientFactory;
    public QuoteOfTheDayDto? QotdDto { get; set; }

    public IndexModel(ILogger<IndexModel> logger, IHttpClientFactory httpClientFactory)
    {
        _logger = logger;
        _httpClientFactory = httpClientFactory;
    }

    public async Task OnGet()
    {
        // 1. Version
        //var client = _httpClientFactory.CreateClient("qotdapiservice");
        //var response = await client.GetAsync("qotd"); // BaseUri + Individuelle => localhost:1234/api/qotd
        //response.EnsureSuccessStatusCode();
        //var content = await response.Content.ReadAsStringAsync();
        //QotdDto = JsonSerializer.Deserialize<QuoteOfTheDayDto>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true});

        // 2. Version Abkürzung
        var client = _httpClientFactory.CreateClient("qotdapiservice");
        QotdDto = await client.GetFromJsonAsync<QuoteOfTheDayDto>("qotd");

    }
}