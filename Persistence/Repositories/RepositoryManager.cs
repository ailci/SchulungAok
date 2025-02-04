using Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories;

public class RepositoryManager : IRepositoryManager
{
    private readonly QotdContext _qotdContext;
    private readonly IQuoteRepository _quoteRepository;

    public RepositoryManager(QotdContext qotdContext, IQuoteRepository quoteRepository)
    {
        _qotdContext = qotdContext;
        _quoteRepository = quoteRepository;
    }

    public IQuoteRepository Quote => _quoteRepository;

    public async Task SaveAsync() => await _qotdContext.SaveChangesAsync();
}