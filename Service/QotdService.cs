using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistence.Contracts;
using Shared.DataTransferObjects;

namespace Service;

public class QotdService : IQotdService
{
    private readonly IRepositoryManager _repositoryManager;

    public QotdService(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    public async Task<QuoteOfTheDayDto> GetQuoteOfTheDayAsync()
    {
        var randomQuote = await _repositoryManager.Quote.GetRandomQuoteAsync();

        return new QuoteOfTheDayDto
        {
            Id = randomQuote.Id,
            QuoteText = randomQuote.QuoteText,
            AuthorName = randomQuote.Author?.Name ?? "",
            AuthorDescription = randomQuote.Author?.Description ?? "",
            AuthorBirthDate = randomQuote.Author?.BirthDate,
            AuthorPhoto = randomQuote.Author?.Photo,
            AuthorPhotoMimeType = randomQuote.Author?.PhotoMimeType
        };
    }
}