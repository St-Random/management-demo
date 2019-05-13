using iTechArt.ManagementDemo.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace iTechArt.ManagementDemo.DataAccess.EF.Infrastructure.Configuration
{
    internal class EmployeeTypeConfiguration
        : ManagementDemoEntityConfiguration<Employee>
    {
        protected override string TableName => "Employees";

        protected override void ConfigureType(
            EntityTypeBuilder<Employee> builder)
        {
            builder
                .HasOne(e => e.Location)
                .WithMany(l => l.Employees)
                .HasForeignKey(e => e.LocationId)
                .OnDelete(DeleteBehavior.Cascade);

            /* It was a bit of a pain and caused EFCore to
             * evaluate locally */
            //builder
            //    .Property(e => e.Sex)
            //    .HasConversion(
            //        new EnumToStringConverter<Sex>());
        }

        protected override void SeedData(EntityTypeBuilder<Employee> builder)
        {
            var clones = GenerateClones().ToList();
            var commanders = GenerateCommanders(
                clones.Max(c => c.Id));

            builder.HasData(
                clones.Concat(commanders));
        }

        #region Asocial Engineering

        private IEnumerable<Employee> GenerateClones()
        {
            var dateFounded =
                new DateTime(
                    1977, 5, 25, 0, 0, 0, DateTimeKind.Utc);

            const int numberOfGenerations = 5;
            const int malesInGeneration = 100;
            const int femalesInGeneration = 100;
            const int yearsBetweenGenerations = 5;
            const int clonesCount = numberOfGenerations
                * (malesInGeneration + femalesInGeneration);
            const decimal trooperSalary = 10000m;
            const decimal genderPayGap = 0.78m;
            // Should match the number of locations
            int[] locationQuotas = { 1, 2, 1, 2, 4, 3 };

            return Enumerable
                .Range(0, numberOfGenerations)
                .Select(gen =>
                    new
                    {
                        gen,
                        dt = dateFounded
                            .AddYears(gen * yearsBetweenGenerations),
                        females = Enumerable
                            .Range(1, femalesInGeneration),
                        males = Enumerable
                            .Range(1, malesInGeneration)
                    })
                .SelectMany(gr => gr.females
                        .Select(num =>
                            new { gr.gen, gr.dt, num, isMale = false })
                        .Concat(gr.males
                            .Select(num =>
                                new { gr.gen, gr.dt, num, isMale = true })))
                .Zip(
                    GetClonesLocations(clonesCount, locationQuotas),
                    (info, loc) =>
                        new
                        {
                            info.gen,
                            info.dt,
                            info.num,
                            info.isMale,
                            loc
                        })
                .Zip(
                    Enumerable.Range(1, clonesCount),
                    (info, id) =>
                        new Employee
                        {
                            Id = id,
                            Created = info.dt,
                            LastUpdated = info.dt,
                            DateOfBirth = info.dt,
                            DateOfEmployment = info.dt,
                            FirstName = 
                                $"STR-{info.gen}-{(info.isMale ? 1 : 0)}"
                                    + $"{info.num}",
                            Sex = info.isMale ? Sex.Male : Sex.Female,
                            Gender = "N/A",
                            HasChildren = false,
                            IsMarried = false,
                            Email =
                                $"str-{info.gen}-{(info.isMale ? 1 : 0)}"
                                    + $"{info.num}@empire.org",
                            Skype =
                                $"str-{info.gen}-{(info.isMale ? 1 : 0)}"
                                   + $"{info.num}",
                            PhoneNumber =
                                $"404-942-{info.gen}-"
                                    + $"{(info.isMale ? 1 : 0)}{info.num}",
                            Position = "Storm Trooper",
                            SalaryInUSD = info.isMale 
                                ? trooperSalary : genderPayGap * trooperSalary,
                            Comment =
                                "Mentally indoctrinated and ready to serve.",
                            LocationId = info.loc
                        });
        }

        private IEnumerable<int> GetClonesLocations(
            int clonesCount, IEnumerable<int> locationQuotas)
        {
            var totalQuota = locationQuotas.Sum();
            var clonesPerLocation = locationQuotas
                .Select(q => (clonesCount * q) / totalQuota)
                .ToArray();
            
            /* 
             * Fix the tuncation (rounding) error by dumping 
             * remaining clones to the last location. */
            clonesPerLocation[clonesPerLocation.Length - 1] +=
                clonesCount - clonesPerLocation.Sum();

            return clonesPerLocation
                .Select(
                    (n, i) =>
                        Enumerable.Repeat(i + 1, n))
                 .SelectMany(gr => gr);
        }

        private IEnumerable<Employee> GenerateCommanders(int maxId)
        {
            var dateFounded =
                new DateTime(
                    1977, 5, 25, 0, 0, 0, DateTimeKind.Utc);
            
            return
                new Employee[]
                {
                    new Employee
                    {
                            Id = maxId + 1,
                            Created = dateFounded,
                            LastUpdated = dateFounded,
                            DateOfBirth = dateFounded.AddYears(-30),
                            DateOfEmployment = dateFounded,
                            FirstName = "Anakin",
                            LastName = "Skywalker",
                            MiddleInitial = "Darth Vader",
                            Sex = Sex.Male,
                            Gender = "Male",
                            HasChildren = true,
                            IsMarried = false,
                            Email = "lord-vader@empire.org",
                            Skype = "lord-vader",
                            PhoneNumber = "404-2",
                            Position = "Dark Lord",
                            SalaryInUSD = 500000,
                            Comment =  "Who's your daddy?",
                            LocationId = 4
                    },
                    new Employee
                    {
                            Id = maxId + 2,
                            Created = dateFounded,
                            LastUpdated = dateFounded,
                            DateOfBirth = dateFounded.AddYears(-50),
                            DateOfEmployment = dateFounded,
                            FirstName = "Sheev",
                            LastName = "Palpatine",
                            MiddleInitial = "Darth Sidious",
                            Sex = Sex.Male,
                            Gender = "Male",
                            HasChildren = false,
                            IsMarried = false,
                            Email = "emperor-sidious@empire.org",
                            Skype = "emperor-sidious",
                            PhoneNumber = "404-1",
                            Position = "Emperor",
                            SalaryInUSD = 10000000,
                            Comment =  "",
                            LocationId = 1
                    }
                };
        }

        #endregion
    }
}
