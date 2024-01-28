using Assignment.Business.Services.Interface;
using Assignment.Data.Repository.Implementation;
using Assignment.Data.Repository.Interface;
using Assignment.Domain.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Business.Services.Implementation
{
    public class ProductService : IProductService
    {

        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public List<Product> GetProducts()
        {
            return _productRepository.GetProducts();
        }

        public List<Product> GetProductsByColor(string color)
        {
            return _productRepository.GetProductsByColor(color);
        }
    }
}
