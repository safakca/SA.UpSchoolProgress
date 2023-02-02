using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Onion.ApiConsume.Application.Interfaces;
using Onion.ApiConsume.Persistence.Context;
using Onion.ApiConsume.Persistence.Repositories;

namespace Onion.ApiConsume.Persistence;
public static class ServiceRegistration
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BaseContext>(opt =>
        {
            opt.UseNpgsql(configuration.GetConnectionString("Local"));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        });
    }
}
