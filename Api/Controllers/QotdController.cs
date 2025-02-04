using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Contracts;
using Service;
using Shared.DataTransferObjects;

namespace Api.Controllers;

[Route("api/[controller]")]  // localhost:1234/api/qotd
[ApiController]
public class QotdController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public QotdController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    
    [HttpGet]
    public async Task<IActionResult> GetQuoteOfTheDayAsync()  //localhost:1234/api/qotd
    {
        var qotd = await _serviceManager.QotdService.GetQuoteOfTheDayAsync();

        return Ok(qotd);
    }
}