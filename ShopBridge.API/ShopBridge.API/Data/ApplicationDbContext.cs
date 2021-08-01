using Microsoft.EntityFrameworkCore;
using ShopBridge.API.Model;

namespace ShopBridge.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            //this.Database.Migrate();
        }

        public DbSet<Item> Items { get; set; }
    }
}
