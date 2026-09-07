namespace PcStore.Application.Catalog;

public sealed record ProductDto(Guid Id, string Name, string Sku, decimal Price, string Category);
