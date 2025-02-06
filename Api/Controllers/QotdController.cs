using Api.Filter;
using Domain.Entities;
using Logging;
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
    private readonly ILoggerManager _logger;

    public QotdController(IServiceManager serviceManager, ILoggerManager logger)
    {
        _serviceManager = serviceManager;
        _logger = logger;
    }

    [HttpGet] //localhost:1234/api/qotd
    public async Task<IActionResult> GetQuoteOfTheDayAsync()  
    {
        _logger.LogInformation($"{nameof(GetQuoteOfTheDayAsync)} aufgerufen...");
        var qotd = await _serviceManager.QotdService.GetQuoteOfTheDayAsync();

        return Ok(qotd);
    } 
    
    [HttpGet("qotdsecured")] //localhost:1234/api/qotd/qotdsecured
    [ServiceFilter(typeof(ApiKeyAuthFilter))] // via Filter
    public async Task<IActionResult> GetQuoteOfTheDaySecuredAsync()  
    {
        _logger.LogInformation($"{nameof(GetQuoteOfTheDaySecuredAsync)} aufgerufen...");
        var qotd = await _serviceManager.QotdService.GetQuoteOfTheDayAsync();

        return Ok(qotd);
    }
}