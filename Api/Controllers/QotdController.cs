using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.DataTransferObjects;

namespace Api.Controllers;

[Route("api/[controller]")]  // localhost:1234/api/qotd
[ApiController]
public class QotdController : ControllerBase
{
    [HttpGet]
    public IActionResult GetQuoteOfTheDay()  //localhost:1234/api/qotd
    {
        var qotd = new QuoteOfTheDayDto
        {
            Id = Guid.NewGuid(),
            QuoteText = "Larum lierum Löffelstiel, wer nicht fragt, der weiß nicht viel!",
            AuthorName = "Ich",
            AuthorDescription = "Dozent",
            AuthorBirthDate = DateOnly.FromDateTime(DateTime.Today)
        };

        return Ok(qotd);
    }
}