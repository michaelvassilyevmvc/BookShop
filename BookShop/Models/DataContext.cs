using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace BookShop.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasIndex(x => x.Title);
            modelBuilder.Entity<Book>().HasIndex(x => x.Price);
            modelBuilder.Entity<Book>().HasIndex(x => x.RetailPrice);

            modelBuilder.Entity<Category>().HasIndex(x => x.Name);
            modelBuilder.Entity<Category>().HasIndex(x => x.Description);
        }
    }
}
