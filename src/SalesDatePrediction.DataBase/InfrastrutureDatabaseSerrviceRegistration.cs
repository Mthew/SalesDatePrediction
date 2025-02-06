using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SalesDatePrediction.Application.Contracts.Persistence;
using SalesDatePrediction.Infrastructure.Repositories;

namespace SalesDatePrediction.Infrastructure
{
    internal static class InfrastrutureDatabaseSerrviceRegistration
    {
        public static IServiceCollection AddInfrastructureDatabaseServicesRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StoreSampleContext>(options =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"));
                options.ConfigureWarnings(warnings =>
                warnings.Ignore(CoreEventId.NavigationBaseIncludeIgnored));
            }, ServiceLifetime.Transient);

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IAsyncRepository<>), typeof(AsyncRepository<>));


            return services;
        }
    }
}
