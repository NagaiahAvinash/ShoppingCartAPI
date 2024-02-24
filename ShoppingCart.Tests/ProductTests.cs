using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCart.Models;

namespace ShoppingCart.Tests
{
    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        // Verifies that a product can be created with valid data.
        public void CanCreateProductWithValidData()
        {
            // Arrange & Act
            var product = new Product { Id = 1, Name = "Laptop", Price = 999.99m, Description = "High-performance laptop", CategoryId = 1, Category = "Electronics" };

            // Assert
            Assert.IsNotNull(product);
        }

        [TestMethod]
        // Verifies that the product's name is correctly set.
        public void ProductNameIsCorrectlySet()
        {
            // Arrange
            var productName = "Smartphone";

            // Act
            var product = new Product { Id = 2, Name = productName, Price = 799.99m, Description = "Flagship smartphone", CategoryId = 2, Category = "Electronics" };

            // Assert
            Assert.AreEqual(productName, product.Name);
        }

        [TestMethod]
        // Verifies that the product's price is correctly set.
        public void ProductPriceIsCorrectlySet()
        {
            // Arrange
            var productPrice = 199.99m;

            // Act
            var product = new Product { Id = 3, Name = "Tablet", Price = productPrice, Description = "Portable tablet", CategoryId = 3, Category = "Electronics" };

            // Assert
            Assert.AreEqual(productPrice, product.Price);
        }

        [TestMethod]
        // Verifies that the product's description is correctly set.
        public void ProductDescriptionIsCorrectlySet()
        {
            // Arrange
            var productDescription = "Wireless earbuds";

            // Act
            var product = new Product { Id = 4, Name = "Earbuds", Price = 79.99m, Description = productDescription, CategoryId = 4, Category = "Electronics" };

            // Assert
            Assert.AreEqual(productDescription, product.Description);
        }
    }
}
