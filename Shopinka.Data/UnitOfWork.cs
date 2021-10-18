using Shopinka.Core;
using Shopinka.Core.Repositories;
using Shopinka.Data.Repositories;

namespace Shopinka.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShopinkaContext _context;
        private ProductRepository _productRepository;

        public UnitOfWork(ShopinkaContext context)
        {
            this._context = context;
        }

        public IProductRepository Products => _productRepository = _productRepository ?? new ProductRepository(_context);

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
