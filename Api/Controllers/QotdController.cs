using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Contracts;
using Shared.DataTransferObjects;

namespace Api.Controllers;

[Route("api/[controller]")]  // localhost:1234/api/qotd
[ApiController]
public class QotdController : ControllerBase
{
    private readonly IRepositoryManager _repositoryManager;

    public QotdController(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    
    [HttpGet]
    public async Task<IActionResult> GetQuoteOfTheDayAsync()  //localhost:1234/api/qotd
    {
        var randomQuote = await _repositoryManager.Quote.GetRandomQuoteAsync();

        var qotd = new QuoteOfTheDayDto
        {
            Id = randomQuote.Id,
            QuoteText = randomQuote.QuoteText,
            AuthorName = randomQuote.Author?.Name ?? "",
            AuthorDescription = randomQuote.Author?.Description ?? "",
            AuthorBirthDate = randomQuote.Author?.BirthDate,
            AuthorPhoto = randomQuote.Author?.Photo,
            AuthorPhotoMimeType = randomQuote.Author?.PhotoMimeType
        };

        return Ok(qotd);
    }
}