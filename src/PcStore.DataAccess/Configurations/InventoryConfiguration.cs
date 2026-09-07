using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PcStore.Domain.Inventory;

namespace PcStore.DataAccess.Configurations;

public sealed class InventoryConfiguration : IEntityTypeConfiguration<InventoryItem>
{
    public void Configure(EntityTypeBuilder<InventoryItem> builder)
    {
        builder.ToTable("inventory_items"); builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.ProductId).IsUnique();
    }
}
