using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PcStore.Core.Contracts.Catalog;
using PcStore.DataAccess.Context;
using PcStore.DataAccess.Queries;

namespace PcStore.DataAccess;

public static class DependencyInjection
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<PcStoreDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("PcStore")));
        services.AddScoped<IProductQueries, ProductQueries>();
        return services;
    }
}
