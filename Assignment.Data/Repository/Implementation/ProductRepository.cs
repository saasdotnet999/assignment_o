using Assignment.Data.Repository.Interface;
using Assignment.Domain.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Data.Repository.Implementation
{
    public class ProductRepository : IProductRepository
    {
        //this is static data for example
        private readonly List<Product> _products;

        public ProductRepository()
        {
            _products = new List<Product>
        {
            new Product { Id = 1, Name = "Product 1", Color = "Red" },
            new Product { Id = 2, Name = "Product 2", Color = "Blue" },
            new Product { Id = 3, Name = "Product 3", Color = "Yellow" },
            new Product { Id = 4, Name = "Product 4", Color = "Green" },
            new Product { Id = 5, Name = "Product 5", Color = "White" },
            new Product { Id = 6, Name = "Product 6", Color = "Red" },

        };
        }
        public List<Product> GetProducts()
        {
              return _products;
        }

        public List<Product> GetProductsByColor(string color)
        {
            return _products.Where(p => p.Color.Equals(color, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}
