using Domain.DbSets;
using Infrastructure.Context;
using Infrastructure.IGenericRepository;

namespace Infrastructure.Implementations
{
    public class OrderRepository:GenericRepository<Order>,IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context)
        {}
       
    }
}
