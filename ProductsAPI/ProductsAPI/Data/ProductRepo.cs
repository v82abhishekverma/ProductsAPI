using System.Collections.Generic;
using System.Linq;
using ProductsAPI.Models;

namespace ProductsAPI.Data
{
    public class ProductRepo : IProductRepo
    {
        public IEnumerable<Product> GetProductsByColour(string colour)
        {
            return colour.ToLower() != "all" ? AllProducts().Where(x => x.Colour.ToLower() == colour.ToLower()) : AllProducts();
            
        }

        public Product GetProductById(int id)
        {
           return AllProducts().SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return AllProducts();
        }

        private IEnumerable<Product> AllProducts()
        {
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Car", Category = "Vechicle", Description = "New", Colour = "Blue", price = 198.76M, Units = 2 },
                new Product { Id = 2, Name = "Bike", Category = "Vechicle", Description = "New", Colour = "Blue", price = 98.76M, Units = 1 },
                new Product { Id = 3, Name = "Truck", Category = "Vechicle", Description = "New", Colour = "Blue", price = 398.76M, Units = 25},
                new Product { Id = 4, Name = "Apple", Category = "Fruit", Description = "New", Colour = "Red", price = 1.76M, Units = 20 }
            };

            return products;
        }
    }
}
