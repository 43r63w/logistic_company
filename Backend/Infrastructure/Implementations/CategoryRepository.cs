



using Domain.DbSets;
using Infrastructure.Context;
using Infrastructure.IGenericRepository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implementations
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<bool> IsExistsAsync(string name) => await _context.Categories.AnyAsync(e => e.Name.ToLower() == name.ToLower());

    }
}
