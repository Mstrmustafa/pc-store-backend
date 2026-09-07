using Microsoft.EntityFrameworkCore;
using PcStore.Domain.Catalog;
using PcStore.Domain.Inventory;
using PcStore.Domain.Orders;

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
