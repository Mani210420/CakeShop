using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CakeShop.Models
{
    public class CakeShopDbContext : DbContext
    {
        public CakeShopDbContext(DbContextOptions<CakeShopDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Cake> Cakes {  get; set; }
    }
}
