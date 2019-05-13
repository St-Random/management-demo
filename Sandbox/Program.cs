using AutoMapper;
using iTechArt.ManagementDemo.DataAccess.Configuration;
using iTechArt.ManagementDemo.DataAccess.Interfaces;
using iTechArt.ManagementDemo.Entities;
using iTechArt.ManagementDemo.Querying;
using iTechArt.ManagementDemo.Querying.Models;
using iTechArt.ManagementDemo.Querying.Pagination;
using iTechArt.ManagementDemo.Querying.Search;
using iTechArt.ManagementDemo.Querying.Sort;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkDataAccess(
                    @"Data Source=.\SQLEXPRESS;Initial Catalog=ManagementDemo;Integrated Security=True",
                    true)
                .AddAutoMapper(
                    AppDomain.CurrentDomain.GetAssemblies())
                .BuildServiceProvider();

            Console.WriteLine(" Applying migrations & seeding db...");
            // Migration & seed
            var context = serviceProvider.GetRequiredService<DbContext>();
            context.Database.Migrate();

            Console.WriteLine(" Finished.");

            var unitOfWork = serviceProvider
                .GetRequiredService<IUnitOfWork>();

            var queryHandler = serviceProvider
                .GetRequiredService<IQueryHandler<Employee, CompanyEmployeeModel>>();

            var searchOptions =
                new SearchOptions
                {
                    PropertyNames =
                        new string[]
                        {
                            "FirstName"
                        },
                    Term = "10"
                };

            var sortOptions =
                new SortOptions[]
                {
                    new SortOptions
                    {
                        PropertyName = "Sex",
                        SortDirection = SortDirection.Ascending
                    },
                    new SortOptions
                    {
                        PropertyName = "FirstName",
                        SortDirection = SortDirection.Descending
                    }
                };

            var employees = queryHandler.Query(
                new QueryOptions
                {
                    SearchOptions = searchOptions,
                    SortOptions = sortOptions,
                    PaginationOptions =
                        new PaginationOptions
                        {
                            ItemsPerPage = 30,
                            Page = 1
                        }
                });

            foreach (var emp in employees.Items)
            {
                Console.WriteLine($" {emp.Id}; {emp.Sex}; {emp.FirstName};");
            }

            Console.WriteLine(" [x] Finished. Press any key to continue...");
            Console.ReadKey();
        }
    }
}
