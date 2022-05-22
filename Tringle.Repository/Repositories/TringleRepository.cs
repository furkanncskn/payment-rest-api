using System.Linq.Expressions;
using Tringle.Core.Repositories;
using Tringle.Repository.Helper;

namespace Tringle.Repository.Repositories
{
    public class TringleRepository<T> : ITringleRepository<T> where T : class, new()
    {
        private readonly DataContext<T> _context;

        public TringleRepository(DataContext<T> context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            await JsonHelper.AddToJsonFileAsync(_context._path, entity);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await JsonHelper.AnyJsonFileAsync(_context._path, expression);
        }

        public async Task DeleteAsync(T entity)
        {
            await JsonHelper.DeleteFromJsonFileAsync(_context._path, entity);
        }

        public async Task DeleteRangeAsync(IEnumerable<T> entities)
        {
            await JsonHelper.DeleteRangeFromJsonFile(_context._path, entities);
        }

        public async Task<IQueryable<T>> GetAllAsync()
        {
            return await JsonHelper.GetAllFromJsonFileAsync<T>(_context._path);
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await JsonHelper.GetByIdFromJsonFileAsync<T>(_context._path, id);
        }

        public async Task UpdateAsync(T entity)
        {
            await JsonHelper.UpdateFromJsonFileAsync(_context._path, entity);
        }

        public async Task UpdateRangeAsync(IEnumerable<T> entities)
        {
            await JsonHelper.UpdateRangeFromJsonFileAsync(_context._path, entities);
        }

        public async Task<IQueryable<T>> WhereAsync(Expression<Func<T, bool>> expression)
        {
            return await JsonHelper.WhereJsonFile(_context._path, expression);
        }
    }
}
