using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Data;
using ShoppingCart.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly UserManager<Microsoft.AspNetCore.Identity.IdentityUser> _userManager;

        public ShoppingCartController(AppDbContext context, UserManager<Microsoft.AspNetCore.Identity.IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // Method to return all products in the user's shopping cart
        [HttpGet]
        public async Task<ActionResult<ShoppingCarts>> GetUserShoppingCart()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized(); // User not found, return an unauthorized response
            }

            var shoppingCart = await _context.ShoppingCarts
                                    .Include(sc => sc.Products)
                                    .FirstOrDefaultAsync(sc => sc.UserId == user.Id);

            if (shoppingCart == null) return NotFound();

            return shoppingCart;
        }

        // Method to add a product by ID to the shopping cart
        [HttpPost("add/{productId}")]
        public async Task<IActionResult> AddProductToCart(int productId)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized(); // User not found, return an unauthorized response
            }

            var product = await _context.Products.FindAsync(productId);
            if (product == null) return NotFound();

            var shoppingCart = await _context.ShoppingCarts
                                    .Include(sc => sc.Products)
                                    .FirstOrDefaultAsync(sc => sc.UserId == user.Id);

            if (shoppingCart == null)
            {
                shoppingCart = new ShoppingCarts { UserId = user.Id }; // Note: Adjusted the class name based on your model
                _context.ShoppingCarts.Add(shoppingCart);
            }

            shoppingCart.Products.Add(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/ShoppingCart/remove/{productId}
        [HttpPost("remove/{productId}")]
        public async Task<IActionResult> RemoveProductFromCart(int productId)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized(); // User not found, return an unauthorized response
            }

            var shoppingCart = await _context.ShoppingCarts
                                    .Include(sc => sc.Products)
                                    .FirstOrDefaultAsync(sc => sc.UserId == user.Id);

            if (shoppingCart == null)
            {
                return NotFound("Shopping cart not found");
            }

            var productToRemove = shoppingCart.Products.FirstOrDefault(p => p.Id == productId);
            if (productToRemove == null)
            {
                return NotFound("Product not found in the shopping cart");
            }

            shoppingCart.Products.Remove(productToRemove);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/ShoppingCart/clear
        [HttpPost("clear")]
        public async Task<IActionResult> ClearShoppingCart()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized(); // User not found, return an unauthorized response
            }

            var shoppingCart = await _context.ShoppingCarts
                                    .Include(sc => sc.Products)
                                    .FirstOrDefaultAsync(sc => sc.UserId == user.Id);

            if (shoppingCart == null)
            {
                return NotFound("Shopping cart not found");
            }

            shoppingCart.Products.Clear();
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/ShoppingCart/update/{productId}/{quantity}
        [HttpPost("update/{productId}/{quantity}")]
        public async Task<IActionResult> UpdateProductQuantity(int productId, int quantity)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized(); // User not found, return an unauthorized response
            }

            var shoppingCart = await _context.ShoppingCarts
                                    .Include(sc => sc.Products)
                                    .FirstOrDefaultAsync(sc => sc.UserId == user.Id);

            if (shoppingCart == null)
            {
                return NotFound("Shopping cart not found");
            }

            var productToUpdate = shoppingCart.Products.FirstOrDefault(p => p.Id == productId);
            if (productToUpdate == null)
            {
                return NotFound("Product not found in the shopping cart");
            }

            productToUpdate.Quantity = quantity;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
