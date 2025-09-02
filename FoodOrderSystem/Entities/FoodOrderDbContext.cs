using FoodOrderSystem.Orders;
using Microsoft.EntityFrameworkCore;

namespace FoodOrderSystem.Entities
{
    public class FoodOrderDbContext : DbContext
    {
        public FoodOrderDbContext(DbContextOptions<FoodOrderDbContext> options) : base(options) { }
        
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<FoodType> FoodTypes { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<OrderStatus> OrderStatus { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<FoodItem> FoodItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FoodType>(entity =>
            {
                entity.ToTable("Foodtype");
                entity.HasData(
                    new FoodType { Id = 1, Name = "Starters" },
                    new FoodType { Id = 2, Name = "Main Course" },
                    new FoodType { Id = 3, Name = "Bread" },
                    new FoodType { Id = 4, Name = "Rice" },
                    new FoodType { Id = 5, Name = "Desert" });
            });
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OrderStatus>(entity =>
            {
                entity.ToTable("OrderStatus");
                entity.HasData(
                    new OrderStatus { Id = 1, Name = "Created" },
                    new OrderStatus { Id = 2, Name = "Accepted" },
                    new OrderStatus { Id = 3, Name = "Canceled" },
                    new OrderStatus { Id = 4, Name = "Paid" },
                    new OrderStatus { Id = 5, Name = "Delivered" });
            });
        }
    }
}
