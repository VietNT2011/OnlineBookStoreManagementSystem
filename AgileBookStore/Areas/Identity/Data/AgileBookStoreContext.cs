using AgileBookStore.Areas.Identity.Data;
using AgileBookStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AgileBookStore.Data;

public class AgileBookStoreContext : IdentityDbContext<AgileBookStoreUser>
{
    public AgileBookStoreContext(DbContextOptions<AgileBookStoreContext> options)
        : base(options)
    {
    }
	public DbSet<Product> Products { get; set; }
	public DbSet<Category> Categories { get; set; }
	public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    public DbSet<Wishlist> Wishlists { get; set; }
    public DbSet<ReviewComment> ReviewComments { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
