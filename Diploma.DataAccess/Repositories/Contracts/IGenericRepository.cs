using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Diploma.DataAccess.Repositories.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);

        Task UpdateAsync(T entity);

        void Remove(T entity);

        Task<int> SaveAsync();

        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null,
                                   Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                   Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                                   bool disableTracking = true,
                                   bool ignoreQueryFilters = false);

        Task<T?> GetFirstOrDefaultAsync(Expression<Func<T, bool>>? predicate = null,
                                       Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                       Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                                       bool disableTracking = true,
                                       bool ignoreQueryFilters = false);

        Task<T?> GetByIdAsync(Guid id);
    }
}
