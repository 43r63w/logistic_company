using Domain.DbSets;
using Infrastructure.Context;
using Infrastructure.IGenericRepository;

namespace Infrastructure.Implementations
{
    public class RestrictionRepository:GenericRepository<Restriction>,IRestrictRepository
    {

        public RestrictionRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
