using BookStore.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Data
{
    public class BookStoreCodeFirstDbContext : IdentityDbContext<ApplicationUser>
    {
        public BookStoreCodeFirstDbContext(DbContextOptions<BookStoreCodeFirstDbContext> options) : base(options) { }

        public BookStoreCodeFirstDbContext() { }
        public DbSet<Book> Books { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookStoreCodeFirstDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
