using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PcStore.Application.Abstractions;
using PcStore.Infrastructure.Catalog;
using PcStore.Infrastructure.Persistence;

namespace PcStore.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<PcStoreDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("PcStore")));
        services.AddScoped<IProductQueries, ProductQueries>();
        return services;
    }
}
