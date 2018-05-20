using CoreTutorial.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreTutorial.Data
{
    public class ArtContext : DbContext
    {
        public ArtContext(DbContextOptions<ArtContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}