using Domain.DbSets;
using Infrastructure.Context;
using Infrastructure.IGenericRepository;

namespace Infrastructure.Implementations
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private bool _disposed = false;
        private readonly ApplicationDbContext _context;
        public ICategoryRepository CategoryRepository { get; private set; }
        public IProductRepository ProductRepository { get; private set; }
        public ISubCategoryRepository SubCategoryRepository { get; }
        public IOrderRepository OrderRepository { get; }
        public IUserRepository UserRepository { get; }
        public IRestrictRepository RestrictRepository { get; }

        public UnitOfWork(ApplicationDbContext context)
        {

            _context = context;
            CategoryRepository = new CategoryRepository(context);
            ProductRepository = new ProductRepository(context);
            SubCategoryRepository = new SubCategoryRepository(context);
            OrderRepository = new OrderRepository(context);
            UserRepository = new UserRepository(context);
            RestrictRepository = new RestrictionRepository(context);
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }

    }
}
