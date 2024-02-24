using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Data;
using Microsoft.AspNetCore.Authorization;
using ShoppingCart.Models;

namespace ShoppingCart.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

       //methods
       //method to return all products
       [HttpGet]
public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
{
    return await _context.Products.ToListAsync();
}

        //method to return products by category ID
        [HttpGet("category/{categoryId}")]
public async Task<ActionResult<IEnumerable<Product>>> GetProductsByCategory(int categoryId)
{
    return await _context.Products.Where(p => p.CategoryId == categoryId).ToListAsync();
}

        // method to create a new product
        [HttpPost]
public async Task<ActionResult<Product>> AddProduct(Product product)
{
    _context.Products.Add(product);
    await _context.SaveChangesAsync();

    return CreatedAtAction(nameof(GetAllProducts), new { id = product.Id }, product);
}

        //

    }
}
