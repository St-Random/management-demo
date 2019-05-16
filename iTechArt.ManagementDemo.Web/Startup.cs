using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation.AspNetCore;
using iTechArt.ManagementDemo.Querying;
using iTechArt.ManagementDemo.Querying.Pagination;
using iTechArt.ManagementDemo.Querying.Search;
using iTechArt.ManagementDemo.Querying.Sort;
using iTechArt.ManagementDemo.Services.Configuration;
using iTechArt.ManagementDemo.Services.Interfaces;
using iTechArt.ManagementDemo.Web.Infrastructure.ServiceAdaptors;
using iTechArt.ManagementDemo.Web.Infrastructure.ServiceAdaptors.Interfaces;
using iTechArt.ManagementDemo.Web.Infrastructure.Validators;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Converters;

namespace iTechArt.ManagementDemo.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services
                .AddMvc()
                .AddFluentValidation(
                    fv => fv.RegisterValidatorsFromAssemblyContaining<
                        AddressModelValidator>())
                .AddJsonOptions(
                    opt =>
                    {
                        opt.SerializerSettings.Converters
                            .Add(new StringEnumConverter());
                    })
                .SetCompatibilityVersion(
                    CompatibilityVersion.Version_2_2);

            services
                .ConfigureBLWithEFDAL(
                    Configuration.GetConnectionString("ManagementDemo"),
                    true)
                .AddAutoMapper(
                    AppDomain.CurrentDomain.GetAssemblies());

            services
                .AddScoped<ICompanyServiceAdapter, CompanyServiceAdapter>()
                .AddScoped<ILocationServiceAdapter, LocationServiceAdapter>()
                .AddScoped<IEmployeeServiceAdapter, EmployeeServiceAdapter>();

            services
                .AddTransient<IQueryOptions, QueryOptions>()
                .AddTransient<ISearchOptions, SearchOptions>()
                .AddTransient<ISortOptions, SortOptions>()
                .AddTransient<IPaginationOptions, PaginationOptions>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error/Index");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(
                routes =>
                {
                    routes.MapRoute(
                        name: "edit",
                        template: "{controller}/{id:int}/{action=Details}");
                    routes.MapRoute(
                        name: "default",
                        template: "{controller=Home}/{action=Index}");
                });

            if (Configuration.GetValue<bool>("ApplyMigrationsOnStartup"))
            {
                app.ApplicationServices
                    .GetRequiredService<IMigrationService>()
                    .ApplyMigrations();
            }
        }
    }
}
