using PcStore.Core.Common;

namespace PcStore.Core.Entities.Catalog;

public sealed class Product : Entity
{
    private Product() { }
    public Product(string name, string sku, decimal price, Guid categoryId)
    {
        if (price < 0) throw new ArgumentOutOfRangeException(nameof(price));
        Name = name.Trim(); Sku = sku.Trim().ToUpperInvariant(); Price = price; CategoryId = categoryId;
    }
    public string Name { get; private set; } = string.Empty;
    public string Sku { get; private set; } = string.Empty;
    public string? Description { get; private set; }
    public decimal Price { get; private set; }
    public Guid CategoryId { get; private set; }
    public Category Category { get; private set; } = null!;
    public Guid? BrandId { get; private set; }
    public Brand? Brand { get; private set; }
    public bool IsActive { get; private set; } = true;
}
