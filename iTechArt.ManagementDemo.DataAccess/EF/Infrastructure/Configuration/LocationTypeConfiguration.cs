using iTechArt.ManagementDemo.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace iTechArt.ManagementDemo.DataAccess.EF.Infrastructure.Configuration
{
    internal class LocationTypeConfiguration
        : ManagementDemoEntityConfiguration<Location>
    {
        protected override string TableName => "Locations";

        protected override void ConfigureType(
            EntityTypeBuilder<Location> builder)
        {
            builder
                .HasOne(l => l.Company)
                .WithMany(c => c.Locations)
                .HasForeignKey(l => l.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .OwnsOne(l => l.Address);
        }

        protected override void SeedData(EntityTypeBuilder<Location> builder)
        {
            var dateFounded =
                new DateTime(
                    1977, 5, 25, 0, 0, 0, DateTimeKind.Utc);

            builder
                .HasData(
                    new Location
                    {
                        Id = 1,
                        Created = dateFounded,
                        LastUpdated = dateFounded,
                        CompanyId = 1,
                        Name = "Imperial Palace",
                        Comment = "aka Palace of the Republic (beware of open spaces)",
                        Email = "imperial-palace@empire.org",
                        Phone = "404-777-000",
                        Fax = "404-778-000"
                    },
                    new Location
                    {
                        Id = 2,
                        Created = dateFounded,
                        LastUpdated = dateFounded,
                        CompanyId = 1,
                        Name = "Republic Executive Building",
                        Comment = "aka Senate Annex (too much dome)",
                        Email = "senate-annex@empire.org",
                        Phone = "404-787-000",
                        Fax = "404-788-000"
                    },
                    new Location
                    {
                        Id = 3,
                        Created = dateFounded,
                        LastUpdated = dateFounded,
                        CompanyId = 1,
                        Name = "Imperial II-Class Star Destroyer #1",
                        Comment = "1.6km long, oniichan",
                        Email = "star-destoryer@empire.org",
                        Phone = "405-101-000",
                        Fax = "405-102-000"
                    },
                    new Location
                    {
                        Id = 4,
                        Created = dateFounded,
                        LastUpdated = dateFounded,
                        CompanyId = 1,
                        Name = "Executor",
                        Comment = "Executor!",
                        Email = "executor@empire.org",
                        Phone = "405-201-000",
                        Fax = "405-202-000"
                    },
                    new Location
                    {
                        Id = 5,
                        Created = dateFounded,
                        LastUpdated = dateFounded,
                        CompanyId = 1,
                        Name = "Death Star",
                        Comment = "Still in construction...",
                        Email = "death-star@empire.org",
                        Phone = "405-101-000",
                        Fax = "405-102-000"
                    },
                    new Location
                    {
                        Id = 6,
                        Created = dateFounded,
                        LastUpdated = dateFounded,
                        CompanyId = 1,
                        Name = "Death Star #2",
                        Comment = "Still in construction...",
                        Email = "death-star2@empire.org",
                        Phone = "405-201-000",
                        Fax = "405-202-000"
                    });

            // A little hack for owned data seeding
            var addressBuilder = builder
                .OwnsOne(l => l.Address);

            SeedAddressData(addressBuilder);
        }

        private void SeedAddressData(
            ReferenceOwnershipBuilder<Location, Address> addressBuilder)
        {
            addressBuilder
                .HasData(
                    new
                    {
                        // Shadow property keys. Meh.
                        LocationId = 1, 
                        AddressLine1 = "Imperial Palace",
                        Country = "Coruscant",
                        Area = "Palace District",
                        City = "Galactic City",
                        PostalCode = "404-777-IP"
                    },
                    new
                    {
                        LocationId = 2,
                        AddressLine1 = "Senate Annex",
                        Country = "Coruscant",
                        Area = "Senate District",
                        City = "Galactic City",
                        PostalCode = "404-787-SA"
                    },
                    new
                    {
                        LocationId = 3,
                        AddressLine1 = "Star Destroyer #1",
                        Country = "First Galactic Empire",
                        Area = "N/A",
                        City = "N/A",
                        PostalCode = "405-101-STD"
                    },
                    new
                    {
                        LocationId = 4,
                        AddressLine1 = "Executor",
                        Country = "First Galactic Empire",
                        Area = "N/A",
                        City = "N/A",
                        PostalCode = "405-201-EXE"
                    },
                    new
                    {
                        LocationId = 5,
                        AddressLine1 = "Death Star",
                        Country = "First Galactic Empire",
                        Area = "Dantooine District",
                        City = "N/A",
                        PostalCode = "405-666-DS"
                    },
                    new
                    {
                        LocationId = 6,
                        AddressLine1 = "Death Star 2",
                        Country = "First Galactic Empire",
                        Area = "(former) Alderaan District",
                        City = "N/A",
                        PostalCode = "405-667-DS2"
                    });
        }
    }
}
