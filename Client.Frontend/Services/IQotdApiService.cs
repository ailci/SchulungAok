using Shared.DataTransferObjects;

namespace Client.Frontend.Services;

public interface IQotdApiService
{
    Task<QuoteOfTheDayDto> GetQuoteOfTheDayAsync();
}