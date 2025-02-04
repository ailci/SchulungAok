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
        

        return Ok(qotd);
    }
}