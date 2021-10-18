using Shopinka.Core;
using Shopinka.Core.Services;
using Shopinka.Models;
using System.Collections.Generic;

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

        public Product GetById(int id)
        {
            return _unitOfWork.Products.GetById(id);
        }

        public void UpdateDesc(int id, string desc)
        {
            var product = _unitOfWork.Products.GetById(id);
            product.Description = desc;
            _unitOfWork.Commit();
        }
    }
}
