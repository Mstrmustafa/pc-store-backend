using PcStore.Core.Entities.Catalog;

namespace PcStore.Tests.Catalog;

public sealed class ProductTests
{
    [Fact]
    public void Constructor_NormalizesSku()
    {
        var product = new Product("Gaming PC", " pc-001 ", 999m, Guid.NewGuid());
        Assert.Equal("PC-001", product.Sku);
    }

    [Fact]
    public void Constructor_RejectsNegativePrice()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Product("GPU", "GPU-1", -1m, Guid.NewGuid()));
    }
}
