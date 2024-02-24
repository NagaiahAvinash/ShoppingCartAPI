using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCart.Models;
using System.Collections.Generic;

namespace ShoppingCart.Tests
{
    [TestClass]
    public class CategoryTests
    {
        // Test method to verify that adding a product increases the product count
        [TestMethod]
        public void AddingProductIncreasesProductCount()
        {
            // Arrange
            var category = new Category();
            var initialCount = category.Products.Count;
            var newProduct = new Product { Name = "Smartphone", Description = "High-end smartphone with advanced camera features" };

            // Act
            category.Products.Add(newProduct);

            // Assert
            Assert.AreEqual(initialCount + 1, category.Products.Count);
        }

        // Test method to verify that removing a product decreases the product count
        [TestMethod]
        public void RemovingProductDecreasesProductCount()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product { Name = "Laptop", Description = "Thin and light laptop with long battery life" },
                new Product { Name = "Tablet", Description = "10-inch tablet with high-resolution display" }
            };
            var category = new Category { Products = products };
            var initialCount = category.Products.Count;
            var productToRemove = products[0]; // Remove the first product

            // Act
            category.Products.Remove(productToRemove);

            // Assert
            Assert.AreEqual(initialCount - 1, category.Products.Count);
        }

        // Test method to verify that clearing the products list resets the product count to zero
        [TestMethod]
        public void ClearingProductsListResetsProductCountToZero()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product { Name = "Headphones", Description = "Wireless headphones with noise-cancellation" },
                new Product { Name = "Smartwatch", Description = "Fitness tracker with heart rate monitor" }
            };
            var category = new Category { Products = products };

            // Act
            category.Products.Clear();

            // Assert
            Assert.AreEqual(0, category.Products.Count);
        }

        // Test method to verify that a specific product can be found in the category
        [TestMethod]
        public void FindingProductInCategory()
        {
            // Arrange
            var category = new Category();
            var productToFind = new Product { Name = "Gaming Console", Description = "High-performance gaming console with 4K graphics" };
            category.Products.Add(new Product { Name = "Smart TV", Description = "Large-screen television with smart features" });
            category.Products.Add(productToFind);
            category.Products.Add(new Product { Name = "Laptop", Description = "Thin and light laptop with powerful processor" });

            // Act
            var foundProduct = category.Products.Find(p => p.Name == "Gaming Console");

            // Assert
            Assert.IsNotNull(foundProduct);
            Assert.AreEqual(productToFind, foundProduct);
        }
    }
}
