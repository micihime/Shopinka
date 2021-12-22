using Shopinka.Core;
using Shopinka.Core.Services;
using Shopinka.Models;
using System.Collections.Generic;
using System.Linq;

namespace Shopinka.Service
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<Product> GetAll()
        {
            return _unitOfWork.Products.GetAll();
        }

        public IEnumerable<Product> GetAll(int pageNumber, int pageSize)
        {
            return _unitOfWork.Products.GetAll()
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public Product GetById(int id)
        {
            return _unitOfWork.Products.GetById(id);
        }

        public bool UpdateDesc(int id, string desc)
        {
            var product = _unitOfWork.Products.GetById(id);

            if (product == null)
                return false;

            product.Description = desc;
            _unitOfWork.Commit();
            return true;
        }
    }
}
