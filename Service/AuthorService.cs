using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Persistence.Contracts;
using Shared.DataTransferObjects;

namespace Service;

public class AuthorService : IAuthorService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;

    public AuthorService(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
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
}