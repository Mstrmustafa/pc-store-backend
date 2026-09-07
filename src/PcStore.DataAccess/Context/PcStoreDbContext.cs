using Microsoft.EntityFrameworkCore;
using PcStore.Core.Entities.Catalog;
using PcStore.Core.Entities.Inventory;
using PcStore.Core.Entities.Orders;

namespace PcStore.DataAccess.Context;

public sealed class PcStoreDbContext(DbContextOptions<PcStoreDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Brand> Brands => Set<Brand>();
    public DbSet<InventoryItem> InventoryItems => Set<InventoryItem>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();
    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PcStoreDbContext).Assembly);
}
