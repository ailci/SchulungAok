using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
using Shared.DataTransferObjects;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorsController : ControllerBase
{
    #region Members/Constructor

    private readonly IServiceManager _service;

    public AuthorsController(IServiceManager service)
    {
        _service = service;
    }

    #endregion

    #region GET

    [HttpGet(Name = "GetAuthors")]
    public async Task<IActionResult> Get()
    {
        var authors = await _service.AuthorService.GetAuthorsAsync();

        return Ok(authors);
    }
    
    [HttpGet("{id:guid}", Name = "GetAuthor")]  //localhost:1234/api/authors/{id}
    public async Task<IActionResult> GetAuthor(Guid id)
    {
        var author = await _service.AuthorService.GetAuthorAsync(id);
        
        return Ok(author);
    }

    #endregion

    #region POST

    [HttpPost(Name = "CreateAuthor")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> CreateAuthor(AuthorForCreateDto authorForCreateDto)
    {
        var authorDto = await _service.AuthorService.CreateAuthorAsync(authorForCreateDto);

        //TODO: Validierung & Rückgabe

        return Ok(authorDto);
    }

    #endregion
}