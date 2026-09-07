using Microsoft.EntityFrameworkCore;
using PcStore.Application.Abstractions;
using PcStore.Application.Catalog;
using PcStore.Application.Common;
using PcStore.Infrastructure.Persistence;

namespace PcStore.Infrastructure.Catalog;

public sealed class ProductQueries(PcStoreDbContext dbContext) : IProductQueries
{
    public async Task<PagedResult<ProductDto>> GetAsync(string? search, int page, int pageSize, CancellationToken cancellationToken)
    {
        page = Math.Max(page, 1);
        pageSize = Math.Clamp(pageSize, 1, 100);
        var query = dbContext.Products.AsNoTracking().Where(x => x.IsActive);

        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(x => EF.Functions.ILike(x.Name, $"%{search.Trim()}%") ||
                                     EF.Functions.ILike(x.Sku, $"%{search.Trim()}%"));
        }

        var totalCount = await query.CountAsync(cancellationToken);
        var items = await query.OrderBy(x => x.Name)
            .Skip((page - 1) * pageSize).Take(pageSize)
            .Select(x => new ProductDto(x.Id, x.Name, x.Sku, x.Price, x.Category.Name))
            .ToListAsync(cancellationToken);

        return new PagedResult<ProductDto>(items, page, pageSize, totalCount);
    }
}
