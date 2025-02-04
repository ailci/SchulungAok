using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistence.Contracts;
using Shared.DataTransferObjects;

namespace Service;

public class AuthorService : IAuthorService
{
    private readonly IRepositoryManager _repositoryManager;

    public AuthorService(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    public async Task<IEnumerable<AuthorDto>> GetAuthorsAsync()
    {
        var authors = await _repositoryManager.Author.GetAuthorsAsync();

        return authors.Select(author => new AuthorDto
        {
            Id = author.Id,
            Name = author.Name,
            Description = author.Description,
            BirthDate = author.BirthDate,
            Photo = author.Photo,
            PhotoMimeType = author.PhotoMimeType
        });
    }
}