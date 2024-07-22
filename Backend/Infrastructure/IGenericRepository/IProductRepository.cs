using Domain.DbSets;
using Infrastructure.GenericRepository;
using System.Diagnostics.SymbolStore;

namespace Infrastructure.IGenericRepository
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<bool> NameExistsAsync(string name);
        Task<bool> FindByIdAsync(int id);
    }
}
