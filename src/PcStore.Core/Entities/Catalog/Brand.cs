using PcStore.Core.Common;

namespace PcStore.Core.Entities.Catalog;

public sealed class Brand : Entity
{
    private Brand() { }
    public Brand(string name) => Name = name.Trim();
    public string Name { get; private set; } = string.Empty;
}
