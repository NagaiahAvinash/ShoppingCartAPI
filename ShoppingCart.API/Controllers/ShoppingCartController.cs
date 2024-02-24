using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Data;
using Microsoft.AspNetCore.Authorization;
using ShoppingCart.Models;
using Microsoft.AspNetCore.Identity;

namespace ShoppingCart.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ShoppingCartController(AppDbContext context, UserManager<IdentityUser> userManager)
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
    }
}
