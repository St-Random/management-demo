using iTechArt.ManagementDemo.DataAccess.EF.Infrastructure.Configuration;
using iTechArt.ManagementDemo.DataAccess.EF.Infrastructure.Extensions;
using iTechArt.ManagementDemo.Entities.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Linq;

namespace iTechArt.ManagementDemo.DataAccess.EF.Infrastructure
{
    internal class ManagementDemoDbContext : DbContext
    {
        //// For migrations only
        //private const string DEFAULT_CONNECTION =
        //    @"Data Source=.\SQLEXPRESS;Initial Catalog=ManagementDemo;Integrated Security=True";

        //// For migrations only
        //public ManagementDemoDbContext()
        //    : base(new DbContextOptionsBuilder()
        //        .UseSqlServer(DEFAULT_CONNECTION)
        //        .Options)
        //{ }

        public ManagementDemoDbContext(DbContextOptions options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Be sure not to seed more than 10K records
            const int startIndex = 10001;

            modelBuilder
                .ApplyEntityConfigurationWithSequence(
                    new CompanyTypeConfiguration(), startIndex, 10)
                .ApplyEntityConfigurationWithSequence(
                    new LocationTypeConfiguration(), startIndex, 10)
                .ApplyEntityConfigurationWithSequence(
                    new EmployeeTypeConfiguration(), startIndex, 10);

            ConfigureUtcDateTimeHandling(modelBuilder);
        }

        // Configures DateTime to be treated as UTC when reading from DB
        private void ConfigureUtcDateTimeHandling(ModelBuilder modelBuilder)
        {
            var utcDateTimeConverter = new ValueConverter<DateTime, DateTime>(
                v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Utc));

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if ((property.ClrType == typeof(DateTime)
                        || property.ClrType == typeof(DateTime?))
                        && property.PropertyInfo
                            .GetCustomAttributes(true)
                            .Any(attr => attr is UtcDateAttribute))
                    {
                        property.SetValueConverter(utcDateTimeConverter);
                    }
                }
            }
        }
    }
}
