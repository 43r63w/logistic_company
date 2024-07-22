using System.Linq.Expressions;


namespace Infrastructure.GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IQueryable<T>> GetAllAsync(Expression<Func<T,bool>>? filter = null, string? includeOptions = null);
        Task<T> GetAsync(Expression<Func<T, bool>>? filter = null, string? includeOptions = null);

        Task CreateAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);

        Task<bool> AnyAsync(Expression<Func<T, bool>>? filter = null);

        Task DeleteRangeAsync(IEnumerable<T> entities);
    }
}
