using Microsoft.EntityFrameworkCore;
using PcStore.Core.Common;
using PcStore.Core.Contracts.Catalog;
using PcStore.DataAccess.Context;

namespace PcStore.DataAccess.Queries;

public sealed class ProductQueries(PcStoreDbContext dbContext) : IProductQueries
{
    public async Task<PagedResult<ProductDto>> GetAsync(string? search, int page, int pageSize, CancellationToken cancellationToken)
    {
        page = Math.Max(page, 1); pageSize = Math.Clamp(pageSize, 1, 100);
        var query = dbContext.Products.AsNoTracking().Where(x => x.IsActive);
        if (!string.IsNullOrWhiteSpace(search))
            query = query.Where(x => EF.Functions.ILike(x.Name, $"%{search.Trim()}%") || EF.Functions.ILike(x.Sku, $"%{search.Trim()}%"));
        var total = await query.CountAsync(cancellationToken);
        var items = await query.OrderBy(x => x.Name).Skip((page - 1) * pageSize).Take(pageSize)
            .Select(x => new ProductDto(x.Id, x.Name, x.Sku, x.Price, x.Category.Name)).ToListAsync(cancellationToken);
        return new(items, page, pageSize, total);
    }
}
