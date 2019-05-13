using iTechArt.ManagementDemo.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace iTechArt.ManagementDemo.DataAccess.EF.Infrastructure.Configuration
{
    internal class CompanyTypeConfiguration
        : ManagementDemoEntityConfiguration<Company>
    {
        protected override string TableName => "Companies";

        protected override void SeedData(EntityTypeBuilder<Company> builder)
        {
            var dateFounded = 
                new DateTime(
                    1977, 5, 25, 0, 0, 0, DateTimeKind.Utc);

            builder.HasData(
                new Company
                {
                    Id = 1,
                    Created = dateFounded,
                    LastUpdated = dateFounded,
                    Name = "First Galactic Empire ©",
                    CompanyCode = "404",
                    DateFounded = dateFounded,
                    Phone = "404",
                    Email = "galactic-empire@empire.org",
                    Comment = "A not so long time ago "
                        + "in a galaxy not so far away...",
                });
        }
    }
}
