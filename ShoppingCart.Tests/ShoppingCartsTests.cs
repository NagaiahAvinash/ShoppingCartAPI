using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCart.Models;
using System.Collections.Generic;

namespace ShoppingCart.Tests
{
    [TestClass]
    public class ShoppingCartsTests
    {
        // Test method to verify that adding a product increases the product count in the shopping cart
        [TestMethod]
        public void AddingProductIncreasesProductCount()
        {
            // Arrange
            var shoppingCart = new ShoppingCarts();
            var initialCount = shoppingCart.Products.Count;
            var newProduct = new Product { Name = "Smartphone", Description = "High-end smartphone with advanced camera features" };

            // Act
            shoppingCart.Products.Add(newProduct);

            // Assert
            Assert.AreEqual(initialCount + 1, shoppingCart.Products.Count);
        }

        // Test method to verify that removing a product decreases the product count in the shopping cart
        [TestMethod]
        public void RemovingProductDecreasesProductCount()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product { Name = "Laptop", Description = "Thin and light laptop with long battery life" },
                new Product { Name = "Tablet", Description = "10-inch tablet with high-resolution display" }
            };
            var shoppingCart = new ShoppingCarts { Products = products };
            var initialCount = shoppingCart.Products.Count;
            var productToRemove = products[0]; // Remove the first product

            // Act
            shoppingCart.Products.Remove(productToRemove);

            // Assert
            Assert.AreEqual(initialCount - 1, shoppingCart.Products.Count);
        }

        // Test method to verify that clearing the products list resets the product count to zero in the shopping cart
        [TestMethod]
        public void ClearingProductsListResetsProductCountToZero()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product { Name = "Headphones", Description = "Wireless headphones with noise-cancellation" },
                new Product { Name = "Smartwatch", Description = "Fitness tracker with heart rate monitor" }
            };
            var shoppingCart = new ShoppingCarts { Products = products };

            // Act
            shoppingCart.Products.Clear();

            // Assert
            Assert.AreEqual(0, shoppingCart.Products.Count);
        }

        // Test method to verify that a specific product can be found in the shopping cart
        [TestMethod]
        public void FindingProductInShoppingCart()
        {
            // Arrange
            var shoppingCart = new ShoppingCarts();
            var productToFind = new Product { Name = "Gaming Console", Description = "High-performance gaming console with 4K graphics" };
            shoppingCart.Products.Add(new Product { Name = "Smart TV", Description = "Large-screen television with smart features" });
            shoppingCart.Products.Add(productToFind);
            shoppingCart.Products.Add(new Product { Name = "Laptop", Description = "Thin and light laptop with powerful processor" });

            // Act
            var foundProduct = shoppingCart.Products.Find(p => p.Name == "Gaming Console");

            // Assert
            Assert.IsNotNull(foundProduct);
            Assert.AreEqual(productToFind, foundProduct);
        }
    }
}

