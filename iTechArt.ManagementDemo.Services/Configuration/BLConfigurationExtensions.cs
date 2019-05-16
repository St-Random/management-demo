using iTechArt.ManagementDemo.DataAccess.Configuration;
using iTechArt.ManagementDemo.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace iTechArt.ManagementDemo.Services.Configuration
{
    public static class BLConfigurationExtensions
    {
        public static IServiceCollection ConfigureBLWithEFDAL(
            this IServiceCollection services,
            string connectionString,
            bool shouldLogQueries = false) =>
            services
                .ConfigureBL()
                .AddEntityFrameworkDataAccess(
                    connectionString, shouldLogQueries);

        public static IServiceCollection ConfigureBL(
            this IServiceCollection serviceCollection) =>
            serviceCollection
                .AddScoped<ICompanyService, CompanyService>()
                .AddScoped<IEmployeeService, EmployeeService>()
                .AddScoped<ILocationService, LocationService>()
                .AddTransient<IMigrationService, MigrationService>();

    }
}
