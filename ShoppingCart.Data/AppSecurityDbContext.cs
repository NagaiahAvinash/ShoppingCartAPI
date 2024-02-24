using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ShoppingCart.Data
{
    public class AppSecurityDbContext : IdentityDbContext<IdentityUser>
    {
        public AppSecurityDbContext(DbContextOptions<AppSecurityDbContext> options) : base(options) { }
    }
}
