using Shopinka.Core.Repositories;
using Shopinka.Models;

namespace Shopinka.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ShopinkaContext context) : base(context) { }
    }
}
