using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductsAPI.Data;

namespace ProductAPI.Test
{
    [TestClass]
    public class ProductRepoTest
    {
        [TestMethod]
        public void GetProductsByColourTest_Red()
        {
            var mockRepo = new ProductRepo();
            var output = mockRepo.GetProductsByColour("Red");
            Assert.IsNotNull(output);
            Assert.AreEqual(4, output.ElementAt(0).Id);
        }

        [TestMethod]
        public void GetProductsByColourTest_All()
        {
            var mockRepo = new ProductRepo();
            var output = mockRepo.GetProductsByColour("All");
            Assert.IsNotNull(output);
            Assert.AreEqual(4, output.Count());
        }

        [TestMethod]
        public void GetProductsByColourTest_Blue()
        {
            var mockRepo = new ProductRepo();
            var output = mockRepo.GetProductsByColour("BLUE");
            Assert.IsNotNull(output);
            Assert.AreEqual(3, output.Count());
        }

        [TestMethod]
        public void GetProductsByColourTest_ColourNotPresent()
        {
            var mockRepo = new ProductRepo();
            var output = mockRepo.GetProductsByColour("PINK");
            Assert.IsNotNull(output);
            Assert.AreEqual(0, output.Count());
        }

        [TestMethod]
        public void GetProductByIdTest_exist()
        {
            var mockRepo = new ProductRepo();
            var output = mockRepo.GetProductById(2);
            Assert.IsNotNull(output);
            Assert.AreEqual(2, output.Id);
        }

        [TestMethod]
        public void GetProductByIdTest_NotExist()
        {
            var mockRepo = new ProductRepo();
            var output = mockRepo.GetProductById(20);
            Assert.IsNull(output);
        }

        [TestMethod]
        public void GetProductsTest()
        {
            var mockRepo = new ProductRepo();
            var output = mockRepo.GetProducts();
            Assert.IsNotNull(output);
            Assert.AreEqual(4, output.Count());
        }

    }
}
