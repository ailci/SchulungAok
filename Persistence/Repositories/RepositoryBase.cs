using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Persistence.Contracts;

namespace Persistence.Repositories;

public class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    private readonly QotdContext _qotdContext;

    public RepositoryBase(QotdContext qotdContext)
    {
        _qotdContext = qotdContext;
    }

    public void Create(T entity)
    {
        _qotdContext.Set<T>().Add(entity);
    }

    public void Delete(T entity)
    {
        _qotdContext.Set<T>().Remove(entity);
    }

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
    {
        return _qotdContext.Set<T>().Where(expression);
    }

    public IQueryable<T> GetAll()
    {
        return _qotdContext.Set<T>();
    }

    public void Update(T entity)
    {
        _qotdContext.Set<T>().Update(entity);
    }
}