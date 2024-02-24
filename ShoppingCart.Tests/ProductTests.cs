using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCart.Models;

namespace ShoppingCart.Tests
{
    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        public void CanChangeProductName()
        {
            // Arrange
            var product = new Product { Name = "Nike" };

            // Act
            product.Name = "Adidas";

            // Assert
            Assert.AreEqual("Adidas", product.Name);
        }

        [TestMethod]
        public void CanChangeProductPrice()
        {
            // Arrange
            var product = new Product { Price = 100 };

            // Act
            product.Price = 1999;

            // Assert
            Assert.AreEqual(1999, product.Price);
        }

        [TestMethod]
        public void CanChangeProductDescription()
        {
            // Arrange
            var product = new Product { Description = "Running Shoe" };

            // Act
            product.Description = "Casual Shoe";

            // Assert
            Assert.AreEqual("Casual Shoe", product.Description);
        }

        [TestMethod]
        public void CanChangeProductId()
        {
            // Arrange
            var product = new Product { Id = 1 };

            // Act
            product.Id = 2;

            // Assert
            Assert.AreEqual(2, product.Id);
        }
    }
}
