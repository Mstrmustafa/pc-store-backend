using PcStore.Application.Catalog;
using PcStore.Application.Common;

namespace PcStore.Application.Abstractions;

public interface IProductQueries
{
    Task<PagedResult<ProductDto>> GetAsync(string? search, int page, int pageSize, CancellationToken cancellationToken);
}
