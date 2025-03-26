using Microsoft.EntityFrameworkCore;
using yorg.Model;

namespace yorg
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Refund> Refunds { get; set; }
        public DbSet<RefundOrderItem> RefundOrderItems { get; set; }
        public DbSet<Review> Reviews { get; set; }

    }
}
