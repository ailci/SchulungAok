using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Shared.DataTransferObjects;

namespace Api.Controllers;

[Route("api/[controller]")]  // localhost:1234/api/qotd
[ApiController]
public class QotdController : ControllerBase
{
    private readonly QotdContext _context;

    public QotdController(QotdContext context)
    {
        _context = context;
    }

    
    [HttpGet]
    public async Task<IActionResult> GetQuoteOfTheDayAsync()  //localhost:1234/api/qotd
    {
        var quotes = await _context.Quotes.Include(c => c.Author).ToListAsync();
        var random = new Random();
        var randomQuote = quotes[random.Next(quotes.Count)];

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