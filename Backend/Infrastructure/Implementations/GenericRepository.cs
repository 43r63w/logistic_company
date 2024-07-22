using Infrastructure.Context;
using Infrastructure.GenericRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace Infrastructure.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected ApplicationDbContext _context;
        protected DbSet<T> _set;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _set = context.Set<T>();
        }

        public virtual async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await Task.CompletedTask;
        }

        public virtual async Task DeleteAsync(T entity)
        {
            _context.Remove(entity);
            await Task.CompletedTask;
        }
        public async Task<bool> AnyAsync(Expression<Func<T, bool>>? filter = null)
        {
            return await _context.Set<T>().AnyAsync(filter);
        }

        public virtual async Task DeleteRangeAsync(IEnumerable<T> entities)
        {
            _context.RemoveRange(entities);


            await Task.CompletedTask;
        }

        public virtual async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? includeOptions = null)
        {
            IQueryable<T> query = _context.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeOptions != null)
            {
                foreach (var entity in includeOptions.Split(new[]
                         {
                             ','
                         }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(entity);
                }
            }

            return query;
        }

        public virtual async Task<T> GetAsync(Expression<Func<T, bool>>? filter = null, string? includeOptions = null)
        {
            IQueryable<T> query = _context.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeOptions != null)
            {
                foreach (var entity in includeOptions.Split(new[]
                         {
                             ','
                         }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(entity);
                }
            }

            return await query.FirstOrDefaultAsync();
        }

        public virtual async Task UpdateAsync(T entity)
        {
            _context.Update(entity);


            await Task.CompletedTask;
        }
    }
}
