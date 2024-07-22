using Domain.DbSets;
using Infrastructure.Context;
using Infrastructure.IGenericRepository;

namespace Infrastructure.Implementations
{
    public class UserRepository :GenericRepository<User>,IUserRepository
    {

        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
