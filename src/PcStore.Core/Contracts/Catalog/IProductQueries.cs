using PcStore.Core.Common;

namespace PcStore.Core.Contracts.Catalog;

public interface IProductQueries
{
    Task<PagedResult<ProductDto>> GetAsync(string? search, int page, int pageSize, CancellationToken cancellationToken);
}
