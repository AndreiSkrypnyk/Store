using BookStore.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructure
{
    public class BookStoreCodeFirstDbContext : DbContext
    {
        public BookStoreCodeFirstDbContext(DbContextOptions<BookStoreCodeFirstDbContext> options) : base(options) { }

        public BookStoreCodeFirstDbContext() { }
        public DbSet<Book> Books { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookStoreCodeFirstDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
