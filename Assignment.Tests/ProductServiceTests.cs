using Assignment.Business.Services.Implementation;
using Assignment.Business.Services.Interface;
using Assignment.Data.Repository.Implementation;
using Assignment.Data.Repository.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Assignment.Tests
{
    public class ProductServiceTests
    {

        private readonly IProductService _productService;
        public ProductServiceTests()
        {
            // create a service provider 
            ServiceProvider serviceProvider = new ServiceCollection()
             .AddScoped<IProductService, ProductService>()
             .AddScoped<IProductRepository, ProductRepository>()
             .BuildServiceProvider();

            _productService = serviceProvider.GetRequiredService<IProductService>();
        }

        [Fact]
        public void GetProducts_ReturnsCorrectCount()
        {
            var products = _productService.GetProducts();

            Assert.Equal(6, products.Count);
        }

        [Fact]
        public void GetProductsBycolor_ReturnsCorrectCount()
        {
            var products = _productService.GetProductsByColor("red");

            Assert.Equal(2, products.Count);
        }

    }
}