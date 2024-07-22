using Infrastructure.GenericRepository;

namespace Infrastructure.IGenericRepository
{
    public interface IUnitOfWork
    {
        public ICategoryRepository CategoryRepository { get; }
        public IProductRepository ProductRepository { get; }
        public ISubCategoryRepository SubCategoryRepository { get; }
        public IOrderRepository OrderRepository { get; }

        public IUserRepository UserRepository { get; }
        
        public IRestrictRepository RestrictRepository { get; }

        Task CommitAsync();
    }
}
