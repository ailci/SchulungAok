using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Persistence.Contracts;
using Shared.DataTransferObjects;

namespace Service;

public class QotdService : IQotdService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;

    public QotdService(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }

    public async Task<QuoteOfTheDayDto> GetQuoteOfTheDayAsync()
    {
        var randomQuote = await _repositoryManager.Quote.GetRandomQuoteAsync();

        // 1. Version Klassik
        //return new QuoteOfTheDayDto
        //{
        //    Id = randomQuote.Id,
        //    QuoteText = randomQuote.QuoteText,
        //    AuthorName = randomQuote.Author?.Name ?? "",
        //    AuthorDescription = randomQuote.Author?.Description ?? "",
        //    AuthorBirthDate = randomQuote.Author?.BirthDate,
        //    AuthorPhoto = randomQuote.Author?.Photo,
        //    AuthorPhotoMimeType = randomQuote.Author?.PhotoMimeType
        //};

        // 2.Version Automapper
        return _mapper.Map<QuoteOfTheDayDto>(randomQuote);
    }
}