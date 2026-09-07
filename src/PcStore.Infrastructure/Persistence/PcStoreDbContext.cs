using Microsoft.EntityFrameworkCore;
using PcStore.Domain.Catalog;
using PcStore.Domain.Inventory;

namespace PcStore.Infrastructure.Persistence;

public sealed class PcStoreDbContext(DbContextOptions<PcStoreDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<InventoryItem> InventoryItems => Set<InventoryItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PcStoreDbContext).Assembly);
    }
}
