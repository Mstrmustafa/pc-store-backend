using PcStore.Domain.Common;

namespace PcStore.Domain.Inventory;

public sealed class InventoryItem : Entity
{
    private InventoryItem() { }
    public Guid ProductId { get; private set; }
    public int QuantityOnHand { get; private set; }
    public int QuantityReserved { get; private set; }
    public int QuantityAvailable => QuantityOnHand - QuantityReserved;
}
