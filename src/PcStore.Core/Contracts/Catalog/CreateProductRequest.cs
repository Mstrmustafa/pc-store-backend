namespace PcStore.Core.Contracts.Catalog;

public sealed record CreateProductRequest(string Name, string Sku, string? Description, decimal Price, Guid CategoryId, Guid? BrandId);
