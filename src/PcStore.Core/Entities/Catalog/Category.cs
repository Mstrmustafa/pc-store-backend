using PcStore.Core.Common;

namespace PcStore.Core.Entities.Catalog;

public sealed class Category : Entity
{
    private Category() { }
    public Category(string name, string slug) { Name = name.Trim(); Slug = slug.Trim().ToLowerInvariant(); }
    public string Name { get; private set; } = string.Empty;
    public string Slug { get; private set; } = string.Empty;
}
