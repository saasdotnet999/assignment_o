using Assignment.Domain.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Business.Services.Interface
{
    public interface IProductService
    {
        List<Product> GetProducts();
        List<Product> GetProductsByColor(string color);
    }
}
