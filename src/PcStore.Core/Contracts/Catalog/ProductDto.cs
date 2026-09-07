namespace PcStore.Core.Contracts.Catalog;

public sealed record ProductDto(Guid Id, string Name, string Sku, decimal Price, string Category);
