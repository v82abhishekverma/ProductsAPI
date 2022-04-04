using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProductsAPI.Controllers;
using ProductsAPI.Data;
using ProductsAPI.Models;

namespace ProductAPI.Test
{
    [TestClass]
    public class ProductsControllerTest
    {
        [TestMethod]
        public void GetAllProductsTest()
        {
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Car", Category = "Vechicle", Description = "New", Colour = "Blue", price = 198.76M, Units = 2 },
                new Product { Id = 2, Name = "Bike", Category = "Vechicle", Description = "New", Colour = "Blue", price = 98.76M, Units = 1 },
                new Product { Id = 3, Name = "Truck", Category = "Vechicle", Description = "New", Colour = "Blue", price = 398.76M, Units = 25},
                new Product { Id = 4, Name = "Apple", Category = "Fruit", Description = "New", Colour = "Red", price = 1.76M, Units = 20 }
            };

            var mockRepo = new Mock<IProductRepo>();
            mockRepo.Setup(x => x.GetProducts()).Returns(products);
            var mockController = new ProductsController(mockRepo.Object);
            var actionResult = mockController.GetAllProducts().Result;
            var result = actionResult as OkObjectResult;
            var returnProducts = result.Value as IEnumerable<Product>;
            
            Assert.AreEqual(4, returnProducts.Count());
        }

        [TestMethod]
        public void GetProductsByColourTest()
        {
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Apple", Category = "Fruit", Description = "New", Colour = "Red", price = 1.76M, Units = 20 }
            };

            var mockRepo = new Mock<IProductRepo>();
            mockRepo.Setup(x => x.GetProductsByColour("RED")).Returns(products);
            var mockController = new ProductsController(mockRepo.Object);
            var actionResult = mockController.GetProductsByColour("RED").Result;
            var result = actionResult as OkObjectResult;
            var returnProducts = result.Value as IEnumerable<Product>;

            Assert.AreEqual(1, returnProducts.Count());
        }

        [TestMethod]
        public void GetProductsByColourTest_NoColourFound()
        {
            var products = new List<Product>();

            var mockRepo = new Mock<IProductRepo>();
            mockRepo.Setup(x => x.GetProductsByColour("RED")).Returns(products);
            var mockController = new ProductsController(mockRepo.Object);
            var actionResult = mockController.GetProductsByColour("RED").Result;
            var result = actionResult as OkObjectResult;
            var returnProducts = result.Value as IEnumerable<Product>;

            Assert.AreEqual(0, returnProducts.Count());
        }
    }
}
