using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ShoppingCart.Data
{
    public class AppSecurityDbContext : IdentityDbContext
    {
        public AppSecurityDbContext(DbContextOptions<AppSecurityDbContext> options) : base(options) { }
    }
}
