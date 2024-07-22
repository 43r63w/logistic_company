using Domain.DbSets;
using Infrastructure.Context;
using Infrastructure.GenericRepository;
using Infrastructure.IGenericRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Implementations
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<bool> NameExistsAsync(string name)
        {
            return await _context.Products.AnyAsync(n => n.Name.ToLower() == name.ToLower());
        }
        public async Task<bool> FindByIdAsync(int id)
        {
            var result = await _context.Products.FirstOrDefaultAsync(i => i.Id == id);

            if (result == null)
            {
                return false;
            }

            return true;
        }


    }

}
