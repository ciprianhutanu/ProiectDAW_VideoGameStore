using Microsoft.EntityFrameworkCore;
using ProiectDAW_VideoGameStore.Models;

namespace ProiectDAW_VideoGameStore.Data
{
    public class DataBaseContext:DbContext
    {
        public DbSet<Order> Orders {  get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<StoreItem> Items { get; set; }
        public DbSet<PlacedOn> MMRelations {  get; set; }

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(us => us.Orders)
                .WithOne(or => or.User);

            modelBuilder.Entity<User>()
                .HasMany(us => us.Reviews)
                .WithOne(rv => rv.User);

            modelBuilder.Entity<StoreItem>()
                .HasMany(si => si.Reviews)
                .WithOne(rv => rv.StoreItem);

            modelBuilder.Entity<PlacedOn>().HasKey(po => new { po.StoreItemId, po.OrderId });

            modelBuilder.Entity<PlacedOn>()
                .HasOne(po => po.Order)
                .WithMany(or => or.ItemsPlacedOn)
                .HasForeignKey(po => po.OrderId);

            modelBuilder.Entity<PlacedOn>()
                .HasOne(po => po.StoreItem)
                .WithMany(si => si.PlacedOnOrders)
                .HasForeignKey(po => po.StoreItemId);


            base.OnModelCreating(modelBuilder);
        }
    }
}
