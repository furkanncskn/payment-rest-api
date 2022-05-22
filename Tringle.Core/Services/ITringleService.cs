using System.Linq.Expressions;

namespace Tringle.Core.Services
{
    public interface ITringleService<T> where T : class, new()
    {
        Task<T?> GetByIdAsync(int id);
        Task<IList<T>?> GetAllAsync();
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task<IQueryable<T>> WhereAsync(Expression<Func<T, bool>> expression);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task UpdateRangeAsync(IEnumerable<T> entities);
        Task DeleteAsync(T entity);
        Task DeleteRangeAsync(IEnumerable<T> entities);
    }
}
