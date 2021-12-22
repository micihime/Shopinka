using Shopinka.Models;
using System.Collections.Generic;

namespace Shopinka.Core.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
        IEnumerable<Product> GetAll(int pageNumber, int pageSize);
        Product GetById(int id);
        bool UpdateDesc(int id, string desc);
    }
}
