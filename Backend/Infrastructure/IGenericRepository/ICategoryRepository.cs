using Domain.DbSets;
using Infrastructure.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IGenericRepository
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<bool> IsExistsAsync(string name);
    }
}
