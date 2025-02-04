using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public IActionResult GetQuoteOfTheDay()  //localhost:1234/api/qotd
    {
        var quotes = _context.Quotes.ToList();
        return Ok(quotes);
    }
}