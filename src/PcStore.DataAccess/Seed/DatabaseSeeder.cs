using Microsoft.EntityFrameworkCore;
using PcStore.DataAccess.Context;
using PcStore.Core.Entities.Catalog;

namespace PcStore.DataAccess.Seed;

public static class DatabaseSeeder
{
    public static async Task SeedAsync(PcStoreDbContext dbContext, CancellationToken cancellationToken = default)
    {
        if (await dbContext.Categories.AnyAsync(cancellationToken)) return;
        dbContext.Categories.AddRange(new Category("Processors", "processors"), new Category("Graphics Cards", "graphics-cards"), new Category("Memory", "memory"));
        dbContext.Brands.AddRange(new Brand("AMD"), new Brand("Intel"), new Brand("NVIDIA"));
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
