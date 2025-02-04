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
    private readonly IAuthorRepository _authorRepository;

    public RepositoryManager(QotdContext qotdContext, IQuoteRepository quoteRepository, IAuthorRepository authorRepository)
    {
        _qotdContext = qotdContext;
        _quoteRepository = quoteRepository;
        _authorRepository = authorRepository;
    }

    public IQuoteRepository Quote => _quoteRepository;
    public IAuthorRepository Author => _authorRepository;

    public async Task SaveAsync() => await _qotdContext.SaveChangesAsync();
}