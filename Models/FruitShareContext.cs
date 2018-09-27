using Microsoft.EntityFrameworkCore;

namespace FruitShare.Models
{
    public class FruitShareContext : DbContext
    {
        public FruitShareContext(DbContextOptions<FruitShareContext> options) : base(options){}

        public DbSet<User> Users { get; set; }

        public DbSet<Fruit> Fruits { get; set; }

        public DbSet<FruitLover> FruitLovers { get; set; }
    }
}