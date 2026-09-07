namespace PcStore.Core.Contracts.Orders;

public sealed record OrderDto(Guid Id, string CustomerEmail, string Status, decimal Total, DateTimeOffset CreatedAtUtc);
