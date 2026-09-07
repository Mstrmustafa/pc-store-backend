using PcStore.Domain.Common;

namespace PcStore.Domain.Orders;

public sealed class Order : Entity
{
    private readonly List<OrderItem> _items = [];
    private Order() { }
    public Order(string customerEmail) => CustomerEmail = customerEmail.Trim().ToLowerInvariant();
    public string CustomerEmail { get; private set; } = string.Empty;
    public OrderStatus Status { get; private set; } = OrderStatus.Pending;
    public IReadOnlyCollection<OrderItem> Items => _items;
    public decimal Total => _items.Sum(x => x.UnitPrice * x.Quantity);
}

public enum OrderStatus { Pending = 1, Paid = 2, Processing = 3, Shipped = 4, Completed = 5, Cancelled = 6 }
