using Domain.DbSets;
using Infrastructure.Context;
using Infrastructure.IGenericRepository;

namespace Infrastructure.Implementations
{
    public class SubCategoryRepository :GenericRepository<SubCategory>,ISubCategoryRepository
    {

        public SubCategoryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
