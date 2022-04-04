using System.Collections.Generic;
using ProductsAPI.Models;

namespace ProductsAPI.Data
{
    public interface IProductRepo
    {
        IEnumerable<Product> GetProducts();
        Product GetProductById(int id);
        IEnumerable<Product> GetProductsByColour(string colour);
    }
}
