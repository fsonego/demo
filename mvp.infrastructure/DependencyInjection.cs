
using mvp.infrastructure.data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using MediatR;
using mvp.application.Common.Interfaces;

namespace mvp.infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) 
    {

        services.AddDbContext<MvpDBContext>(options =>
             options.UseSqlServer(
                 configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IMvpDBContext>(provider =>
                    provider.GetRequiredService<MvpDBContext>());

        return services;
    }

}
