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
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

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

            //var companiesRepo = serviceProvider
            //    .GetRequiredService<IRepository<Company>>();
            //var locationsRepo = serviceProvider
            //    .GetRequiredService<IRepository<Location>>();

            //var context = serviceProvider.GetService<DbContext>();

            //var query = context.Set<Location>()
            //    .Select(l => new CompanyLocationModel { Id = l.Id, EmployeesCount = l.Employees.Count, Name = l.Name });
            //query = query //.Where(l => l.EmployeesCount > 150)
            //    .Where(l => l.Name.ToUpper().Contains("A"));
            //query = query.OrderBy(e => e.EmployeesCount);
            //query = query.Skip(1).Take(10);
            //var testData = query.ToListAsync().Result;

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

            var employees = queryHandler.QueryAsync(
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
                }).Result;

            //var company = new Company { Name = "Test3", Comment = "Validation test", Phone = "404", Locations = new List<Location>() };
            //company.Locations.Add(new Location { Name = "Test location", Address = new Address { Country = "Belarus", Area = "Minskaya Voblast", City = "Minsk", AddressLine1 = "10, Tolstoyevskogo st.", PostalCode = "220002" } });
            //companiesRepo.Add(company);
            //var company = companiesRepo.Find(1);

            //foreach (var location in company.Locations)
            //{
            //    Console.WriteLine(location.Employees.Count);
            //}

            //Console.WriteLine(company.Locations.Sum(l => l.Employees.Count));

            Console.WriteLine("So far so good...");
            Console.ReadKey();

            unitOfWork.SaveChanges();

            Console.WriteLine(" [x] Finished. Press any key to continue...");
            Console.ReadKey();
        }
    }
}
