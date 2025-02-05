using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using Persistence.Contracts;
using Shared.DataTransferObjects;
using Shared.Utilities;

namespace Service;

public class AuthorService : IAuthorService
{
    private readonly ILogger<AuthorService> _logger;
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;

    public AuthorService(IRepositoryManager repositoryManager, IMapper mapper, ILogger<AuthorService> logger)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<IEnumerable<AuthorDto>> GetAuthorsAsync()
    {
        var authors = await _repositoryManager.Author.GetAuthorsAsync();

        //return authors.Select(author => new AuthorDto
        //{
        //    Id = author.Id,
        //    Name = author.Name,
        //    Description = author.Description,
        //    BirthDate = author.BirthDate,
        //    Photo = author.Photo,
        //    PhotoMimeType = author.PhotoMimeType
        //});

        return _mapper.Map<IEnumerable<AuthorDto>>(authors);
    }

    public async Task<AuthorDto> GetAuthorAsync(Guid authorId)
    {
        var author = await _repositoryManager.Author.GetAuthorAsync(authorId);

        if (author is null) throw new Exception();

        return _mapper.Map<AuthorDto>(author);
    }

    public async Task<AuthorDto> CreateAuthorAsync(AuthorForCreateDto authorForCreateDto)
    {
        _logger.LogInformation($"CreateAuthorAsync mit {authorForCreateDto.LogAsJson()} aufgerufen...");

        var authorEntity = _mapper.Map<Author>(authorForCreateDto);
        _repositoryManager.Author.CreateAuthor(authorEntity);
        await _repositoryManager.SaveAsync();

        return _mapper.Map<AuthorDto>(authorEntity);
    }

    public async Task DeleteAuthorAsync(Guid authorId)
    {
        var authorEntity = await GetAuthorAndCheckIfItExists(authorId);
        _repositoryManager.Author.DeleteAuthor(authorEntity);
        await _repositoryManager.SaveAsync();
    }

    private async Task<Author> GetAuthorAndCheckIfItExists(Guid authorId)
    {
        var author = await _repositoryManager.Author.GetAuthorAsync(authorId);

        //TODO: Fehlerbehandlung
        //if (author is null) throw new AuthorNotFoundException(authorId);

        return author;
    }
}