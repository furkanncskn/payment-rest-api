using System.Linq.Expressions;
using Tringle.Core.Repositories;
using Tringle.Core.Services;

namespace Tringle.Services.Service
{
    public class TringleService<T> : ITringleService<T> where T : class, new()
    {
        private readonly ITringleRepository<T> _repository;

        public TringleService(ITringleRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _repository.AddAsync(entity);

            return entity;
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _repository.AnyAsync(expression);
        }

        public async Task DeleteAsync(T entity)
        {
            await _repository.DeleteAsync(entity);
        }

        public async Task DeleteRangeAsync(IEnumerable<T> entities)
        {
            await _repository.DeleteRangeAsync(entities);
        }

        public async Task<bool> ExistAsync(T entity)
        {
            return await _repository.ExistAsync(entity);
        }

        public async Task<IList<T>?> GetAllAsync()
        {
            return (await _repository.GetAllAsync()).ToList();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            await _repository.UpdateAsync(entity);
        }

        public async Task UpdateRangeAsync(IEnumerable<T> entities)
        {
            await _repository.UpdateRangeAsync(entities);
        }

        public async Task<IQueryable<T>> WhereAsync(Expression<Func<T, bool>> expression)
        {
            return await _repository.WhereAsync(expression);
        }
    }
}
