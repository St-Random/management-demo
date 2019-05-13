using iTechArt.ManagementDemo.DataAccess.EF;
using iTechArt.ManagementDemo.DataAccess.EF.Infrastructure;
using iTechArt.ManagementDemo.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace iTechArt.ManagementDemo.DataAccess.Configuration
{
    public static class EFConfigurationExtensions
    {
        public static IServiceCollection AddEntityFrameworkDataAccess(
            this IServiceCollection services,
            string connectionString,
            bool shouldLogQueries) =>
            services
                .ConfigureEFDbContext(
                    connectionString, shouldLogQueries)
                .ConfigureEFUnitOfWork()
                .ConfigureEFRepositories()
                .ConfigureEFQueryHandlers();

        private static IServiceCollection ConfigureEFDbContext(
            this IServiceCollection services,
            string connectionString,
            bool shouldLogQueries) =>
            // Sounds cool
            services
                .AddDbContextPool<DbContext, ManagementDemoDbContext>(
                    options =>
                    {
                        options
                            .UseSqlServer(connectionString)
                            .UseLazyLoadingProxies();

                        if (shouldLogQueries)
                        {
                            // EF core wants obsolete logger factory.
                            // Shame on it.
                            options.UseLoggerFactory(
#pragma warning disable CS0618 // Type or member is obsolete
                            new LoggerFactory().AddDebug());
#pragma warning restore CS0618 // Type or member is obsolete
                        }
                    });

        private static IServiceCollection ConfigureEFUnitOfWork(
            this IServiceCollection services) =>
            services
                .AddScoped<EFUnitOfWork>()
                // Forwarding
                .AddTransient<IUnitOfWork>(
                    sp => sp.GetRequiredService<EFUnitOfWork>())
                .AddTransient<IDbContextProvider>(
                    sp => sp.GetRequiredService<EFUnitOfWork>());

        private static IServiceCollection ConfigureEFRepositories(
            this IServiceCollection services) =>
            services
                .AddScoped(
                    typeof(IRepository<>),
                    typeof(EFRepository<>));

        private static IServiceCollection ConfigureEFQueryHandlers(
            this IServiceCollection services) =>
            services
                .AddScoped(
                    typeof(IQueryHandler<,>),
                    typeof(EFQueryHandler<,>));
    }
}
