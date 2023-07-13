﻿using Microsoft.EntityFrameworkCore;

namespace BookShop.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
    }
}
