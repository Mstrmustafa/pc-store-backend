using PcStore.Domain.Common;

namespace PcStore.Domain.Orders;

public sealed class OrderItem : Entity
{
    private OrderItem() { }
    public Guid OrderId { get; private set; }
    public Guid ProductId { get; private set; }
    public string ProductName { get; private set; } = string.Empty;
    public string Sku { get; private set; } = string.Empty;
    public decimal UnitPrice { get; private set; }
    public int Quantity { get; private set; }
}
