using Microsoft.EntityFrameworkCore;
using Publication.Data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Publication.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Book> Book { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<PublicationCartItem> PublicationCartItems { get; set; }
        public DbSet<Order> Order{ get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<User> User { get; set; }
    }
}
