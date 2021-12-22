using Shopinka.Models;
using System.Collections.Generic;

namespace Shopinka.Core.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        bool UpdateDesc(int id, string desc);
    }
}
