using PcStore.Domain.Common;

namespace PcStore.Domain.Catalog;

public sealed class Brand : Entity
{
    private Brand() { }
    public Brand(string name) => Name = name.Trim();
    public string Name { get; private set; } = string.Empty;
}
