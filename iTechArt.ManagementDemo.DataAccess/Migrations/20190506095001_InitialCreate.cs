using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace iTechArt.ManagementDemo.DataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "CompaniesSequence",
                startValue: 10001L,
                incrementBy: 10);

            migrationBuilder.CreateSequence<int>(
                name: "EmployeesSequence",
                startValue: 10001L,
                incrementBy: 10);

            migrationBuilder.CreateSequence<int>(
                name: "LocationsSequence",
                startValue: 10001L,
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: true, defaultValueSql: "sysutcdatetime()"),
                    LastUpdated = table.Column<DateTime>(nullable: true, defaultValueSql: "sysutcdatetime()"),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    CompanyCode = table.Column<string>(maxLength: 255, nullable: true),
                    DateFounded = table.Column<DateTime>(nullable: true),
                    Email = table.Column<string>(maxLength: 255, nullable: true),
                    Phone = table.Column<string>(maxLength: 255, nullable: true),
                    Fax = table.Column<string>(maxLength: 255, nullable: true),
                    Comment = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: true, defaultValueSql: "sysutcdatetime()"),
                    LastUpdated = table.Column<DateTime>(nullable: true, defaultValueSql: "sysutcdatetime()"),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Address_Country = table.Column<string>(maxLength: 255, nullable: false),
                    Address_Area = table.Column<string>(maxLength: 255, nullable: false),
                    Address_City = table.Column<string>(maxLength: 255, nullable: false),
                    Address_AddressLine1 = table.Column<string>(maxLength: 255, nullable: false),
                    Address_AddressLine2 = table.Column<string>(maxLength: 255, nullable: true),
                    Address_PostalCode = table.Column<string>(maxLength: 255, nullable: false),
                    Email = table.Column<string>(maxLength: 255, nullable: true),
                    Phone = table.Column<string>(maxLength: 255, nullable: true),
                    Fax = table.Column<string>(maxLength: 255, nullable: true),
                    Comment = table.Column<string>(maxLength: 255, nullable: true),
                    CompanyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: true, defaultValueSql: "sysutcdatetime()"),
                    LastUpdated = table.Column<DateTime>(nullable: true, defaultValueSql: "sysutcdatetime()"),
                    FirstName = table.Column<string>(maxLength: 255, nullable: false),
                    MiddleInitial = table.Column<string>(maxLength: 255, nullable: true),
                    LastName = table.Column<string>(maxLength: 255, nullable: true),
                    Patronymic = table.Column<string>(maxLength: 255, nullable: true),
                    Sex = table.Column<int>(nullable: false),
                    Gender = table.Column<string>(maxLength: 255, nullable: true),
                    Email = table.Column<string>(maxLength: 255, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 255, nullable: true),
                    Skype = table.Column<string>(maxLength: 255, nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: true),
                    DateOfEmployment = table.Column<DateTime>(nullable: true),
                    Position = table.Column<string>(maxLength: 255, nullable: true),
                    SalaryInUSD = table.Column<decimal>(nullable: true),
                    IsMarried = table.Column<bool>(nullable: true),
                    HasChildren = table.Column<bool>(nullable: true),
                    Comment = table.Column<string>(maxLength: 255, nullable: true),
                    LocationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            // Custom check constraints
            migrationBuilder.Sql(
                "ALTER TABLE [dbo].[Companies] ADD CONSTRAINT [CK_Companies_DateFounded] CHECK ([DateFounded] <= sysutcdatetime())");

            migrationBuilder.Sql(
                "ALTER TABLE [dbo].[Employees] ADD CONSTRAINT [CK_Employees_DateOfBirth] CHECK ([DateOfBirth] <= sysutcdatetime())");

            migrationBuilder.Sql(
                "ALTER TABLE [dbo].[Employees] ADD CONSTRAINT [CK_Employees_DateOfBirth_DateOfEmployment] CHECK ([DateOfBirth] <= [DateOfEmployment])");

            // Seeding
            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Comment", "CompanyCode", "Created", "DateFounded", "Email", "Fax", "Name", "Phone" },
                values: new object[] { 1, "A not so long time ago in a galaxy not so far away...", "404", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "galactic-empire@empire.org", null, "First Galactic Empire ©", "404" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Comment", "CompanyId", "Created", "Email", "Fax", "Name", "Phone", "Address_AddressLine1", "Address_AddressLine2", "Address_Area", "Address_City", "Address_Country", "Address_PostalCode" },
                values: new object[] { 1, "aka Palace of the Republic (beware of open spaces)", 1, new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "imperial-palace@empire.org", "404-778-000", "Imperial Palace", "404-777-000", "Imperial Palace", null, "Palace District", "Galactic City", "Coruscant", "404-777-IP" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Comment", "CompanyId", "Created", "Email", "Fax", "Name", "Phone", "Address_AddressLine1", "Address_AddressLine2", "Address_Area", "Address_City", "Address_Country", "Address_PostalCode" },
                values: new object[] { 2, "aka Senate Annex (too much dome)", 1, new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "senate-annex@empire.org", "404-788-000", "Republic Executive Building", "404-787-000", "Senate Annex", null, "Senate District", "Galactic City", "Coruscant", "404-787-SA" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Comment", "CompanyId", "Created", "Email", "Fax", "Name", "Phone", "Address_AddressLine1", "Address_AddressLine2", "Address_Area", "Address_City", "Address_Country", "Address_PostalCode" },
                values: new object[] { 3, "1.6km long, oniichan", 1, new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "star-destoryer@empire.org", "405-102-000", "Imperial II-Class Star Destroyer #1", "405-101-000", "Star Destroyer #1", null, "N/A", "N/A", "First Galactic Empire", "405-101-STD" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Comment", "CompanyId", "Created", "Email", "Fax", "Name", "Phone", "Address_AddressLine1", "Address_AddressLine2", "Address_Area", "Address_City", "Address_Country", "Address_PostalCode" },
                values: new object[] { 4, "Executor!", 1, new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "executor@empire.org", "405-202-000", "Executor", "405-201-000", "Executor", null, "N/A", "N/A", "First Galactic Empire", "405-201-EXE" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Comment", "CompanyId", "Created", "Email", "Fax", "Name", "Phone", "Address_AddressLine1", "Address_AddressLine2", "Address_Area", "Address_City", "Address_Country", "Address_PostalCode" },
                values: new object[] { 5, "Still in construction...", 1, new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "death-star@empire.org", "405-102-000", "Death Star", "405-101-000", "Death Star", null, "Dantooine District", "N/A", "First Galactic Empire", "405-666-DS" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Comment", "CompanyId", "Created", "Email", "Fax", "Name", "Phone", "Address_AddressLine1", "Address_AddressLine2", "Address_Area", "Address_City", "Address_Country", "Address_PostalCode" },
                values: new object[] { 6, "Still in construction...", 1, new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "death-star2@empire.org", "405-202-000", "Death Star #2", "405-201-000", "Death Star 2", null, "(former) Alderaan District", "N/A", "First Galactic Empire", "405-667-DS2" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 1, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-01@empire.org", "STR-0-01", "N/A", false, false, null, 1, null, null, "404-942-0-01", "Storm Trooper", 7800.00m, 1, "str-0-01" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 658, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-058@empire.org", "STR-3-058", "N/A", false, false, null, 5, null, null, "404-942-3-058", "Storm Trooper", 7800.00m, 1, "str-3-058" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 659, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-059@empire.org", "STR-3-059", "N/A", false, false, null, 5, null, null, "404-942-3-059", "Storm Trooper", 7800.00m, 1, "str-3-059" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 660, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-060@empire.org", "STR-3-060", "N/A", false, false, null, 5, null, null, "404-942-3-060", "Storm Trooper", 7800.00m, 1, "str-3-060" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 661, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-061@empire.org", "STR-3-061", "N/A", false, false, null, 5, null, null, "404-942-3-061", "Storm Trooper", 7800.00m, 1, "str-3-061" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 662, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-062@empire.org", "STR-3-062", "N/A", false, false, null, 5, null, null, "404-942-3-062", "Storm Trooper", 7800.00m, 1, "str-3-062" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 663, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-063@empire.org", "STR-3-063", "N/A", false, false, null, 5, null, null, "404-942-3-063", "Storm Trooper", 7800.00m, 1, "str-3-063" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 664, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-064@empire.org", "STR-3-064", "N/A", false, false, null, 5, null, null, "404-942-3-064", "Storm Trooper", 7800.00m, 1, "str-3-064" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 665, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-065@empire.org", "STR-3-065", "N/A", false, false, null, 5, null, null, "404-942-3-065", "Storm Trooper", 7800.00m, 1, "str-3-065" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 666, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-066@empire.org", "STR-3-066", "N/A", false, false, null, 5, null, null, "404-942-3-066", "Storm Trooper", 7800.00m, 1, "str-3-066" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 667, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-067@empire.org", "STR-3-067", "N/A", false, false, null, 5, null, null, "404-942-3-067", "Storm Trooper", 7800.00m, 1, "str-3-067" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 668, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-068@empire.org", "STR-3-068", "N/A", false, false, null, 5, null, null, "404-942-3-068", "Storm Trooper", 7800.00m, 1, "str-3-068" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 669, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-069@empire.org", "STR-3-069", "N/A", false, false, null, 5, null, null, "404-942-3-069", "Storm Trooper", 7800.00m, 1, "str-3-069" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 670, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-070@empire.org", "STR-3-070", "N/A", false, false, null, 5, null, null, "404-942-3-070", "Storm Trooper", 7800.00m, 1, "str-3-070" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 671, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-071@empire.org", "STR-3-071", "N/A", false, false, null, 5, null, null, "404-942-3-071", "Storm Trooper", 7800.00m, 1, "str-3-071" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 672, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-072@empire.org", "STR-3-072", "N/A", false, false, null, 5, null, null, "404-942-3-072", "Storm Trooper", 7800.00m, 1, "str-3-072" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 673, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-073@empire.org", "STR-3-073", "N/A", false, false, null, 5, null, null, "404-942-3-073", "Storm Trooper", 7800.00m, 1, "str-3-073" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 674, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-074@empire.org", "STR-3-074", "N/A", false, false, null, 5, null, null, "404-942-3-074", "Storm Trooper", 7800.00m, 1, "str-3-074" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 675, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-075@empire.org", "STR-3-075", "N/A", false, false, null, 5, null, null, "404-942-3-075", "Storm Trooper", 7800.00m, 1, "str-3-075" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 676, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-076@empire.org", "STR-3-076", "N/A", false, false, null, 5, null, null, "404-942-3-076", "Storm Trooper", 7800.00m, 1, "str-3-076" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 677, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-077@empire.org", "STR-3-077", "N/A", false, false, null, 5, null, null, "404-942-3-077", "Storm Trooper", 7800.00m, 1, "str-3-077" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 678, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-078@empire.org", "STR-3-078", "N/A", false, false, null, 5, null, null, "404-942-3-078", "Storm Trooper", 7800.00m, 1, "str-3-078" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 679, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-079@empire.org", "STR-3-079", "N/A", false, false, null, 5, null, null, "404-942-3-079", "Storm Trooper", 7800.00m, 1, "str-3-079" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 680, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-080@empire.org", "STR-3-080", "N/A", false, false, null, 5, null, null, "404-942-3-080", "Storm Trooper", 7800.00m, 1, "str-3-080" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 681, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-081@empire.org", "STR-3-081", "N/A", false, false, null, 5, null, null, "404-942-3-081", "Storm Trooper", 7800.00m, 1, "str-3-081" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 682, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-082@empire.org", "STR-3-082", "N/A", false, false, null, 5, null, null, "404-942-3-082", "Storm Trooper", 7800.00m, 1, "str-3-082" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 683, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-083@empire.org", "STR-3-083", "N/A", false, false, null, 5, null, null, "404-942-3-083", "Storm Trooper", 7800.00m, 1, "str-3-083" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 684, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-084@empire.org", "STR-3-084", "N/A", false, false, null, 5, null, null, "404-942-3-084", "Storm Trooper", 7800.00m, 1, "str-3-084" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 657, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-057@empire.org", "STR-3-057", "N/A", false, false, null, 5, null, null, "404-942-3-057", "Storm Trooper", 7800.00m, 1, "str-3-057" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 685, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-085@empire.org", "STR-3-085", "N/A", false, false, null, 5, null, null, "404-942-3-085", "Storm Trooper", 7800.00m, 1, "str-3-085" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 656, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-056@empire.org", "STR-3-056", "N/A", false, false, null, 5, null, null, "404-942-3-056", "Storm Trooper", 7800.00m, 1, "str-3-056" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 654, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-054@empire.org", "STR-3-054", "N/A", false, false, null, 5, null, null, "404-942-3-054", "Storm Trooper", 7800.00m, 1, "str-3-054" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 627, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-027@empire.org", "STR-3-027", "N/A", false, false, null, 5, null, null, "404-942-3-027", "Storm Trooper", 7800.00m, 1, "str-3-027" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 628, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-028@empire.org", "STR-3-028", "N/A", false, false, null, 5, null, null, "404-942-3-028", "Storm Trooper", 7800.00m, 1, "str-3-028" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 629, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-029@empire.org", "STR-3-029", "N/A", false, false, null, 5, null, null, "404-942-3-029", "Storm Trooper", 7800.00m, 1, "str-3-029" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 630, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-030@empire.org", "STR-3-030", "N/A", false, false, null, 5, null, null, "404-942-3-030", "Storm Trooper", 7800.00m, 1, "str-3-030" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 631, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-031@empire.org", "STR-3-031", "N/A", false, false, null, 5, null, null, "404-942-3-031", "Storm Trooper", 7800.00m, 1, "str-3-031" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 632, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-032@empire.org", "STR-3-032", "N/A", false, false, null, 5, null, null, "404-942-3-032", "Storm Trooper", 7800.00m, 1, "str-3-032" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 633, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-033@empire.org", "STR-3-033", "N/A", false, false, null, 5, null, null, "404-942-3-033", "Storm Trooper", 7800.00m, 1, "str-3-033" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 634, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-034@empire.org", "STR-3-034", "N/A", false, false, null, 5, null, null, "404-942-3-034", "Storm Trooper", 7800.00m, 1, "str-3-034" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 635, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-035@empire.org", "STR-3-035", "N/A", false, false, null, 5, null, null, "404-942-3-035", "Storm Trooper", 7800.00m, 1, "str-3-035" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 636, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-036@empire.org", "STR-3-036", "N/A", false, false, null, 5, null, null, "404-942-3-036", "Storm Trooper", 7800.00m, 1, "str-3-036" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 637, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-037@empire.org", "STR-3-037", "N/A", false, false, null, 5, null, null, "404-942-3-037", "Storm Trooper", 7800.00m, 1, "str-3-037" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 638, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-038@empire.org", "STR-3-038", "N/A", false, false, null, 5, null, null, "404-942-3-038", "Storm Trooper", 7800.00m, 1, "str-3-038" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 639, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-039@empire.org", "STR-3-039", "N/A", false, false, null, 5, null, null, "404-942-3-039", "Storm Trooper", 7800.00m, 1, "str-3-039" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 640, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-040@empire.org", "STR-3-040", "N/A", false, false, null, 5, null, null, "404-942-3-040", "Storm Trooper", 7800.00m, 1, "str-3-040" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 641, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-041@empire.org", "STR-3-041", "N/A", false, false, null, 5, null, null, "404-942-3-041", "Storm Trooper", 7800.00m, 1, "str-3-041" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 642, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-042@empire.org", "STR-3-042", "N/A", false, false, null, 5, null, null, "404-942-3-042", "Storm Trooper", 7800.00m, 1, "str-3-042" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 643, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-043@empire.org", "STR-3-043", "N/A", false, false, null, 5, null, null, "404-942-3-043", "Storm Trooper", 7800.00m, 1, "str-3-043" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 644, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-044@empire.org", "STR-3-044", "N/A", false, false, null, 5, null, null, "404-942-3-044", "Storm Trooper", 7800.00m, 1, "str-3-044" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 645, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-045@empire.org", "STR-3-045", "N/A", false, false, null, 5, null, null, "404-942-3-045", "Storm Trooper", 7800.00m, 1, "str-3-045" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 646, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-046@empire.org", "STR-3-046", "N/A", false, false, null, 5, null, null, "404-942-3-046", "Storm Trooper", 7800.00m, 1, "str-3-046" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 647, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-047@empire.org", "STR-3-047", "N/A", false, false, null, 5, null, null, "404-942-3-047", "Storm Trooper", 7800.00m, 1, "str-3-047" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 648, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-048@empire.org", "STR-3-048", "N/A", false, false, null, 5, null, null, "404-942-3-048", "Storm Trooper", 7800.00m, 1, "str-3-048" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 649, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-049@empire.org", "STR-3-049", "N/A", false, false, null, 5, null, null, "404-942-3-049", "Storm Trooper", 7800.00m, 1, "str-3-049" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 650, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-050@empire.org", "STR-3-050", "N/A", false, false, null, 5, null, null, "404-942-3-050", "Storm Trooper", 7800.00m, 1, "str-3-050" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 651, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-051@empire.org", "STR-3-051", "N/A", false, false, null, 5, null, null, "404-942-3-051", "Storm Trooper", 7800.00m, 1, "str-3-051" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 652, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-052@empire.org", "STR-3-052", "N/A", false, false, null, 5, null, null, "404-942-3-052", "Storm Trooper", 7800.00m, 1, "str-3-052" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 653, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-053@empire.org", "STR-3-053", "N/A", false, false, null, 5, null, null, "404-942-3-053", "Storm Trooper", 7800.00m, 1, "str-3-053" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 655, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-055@empire.org", "STR-3-055", "N/A", false, false, null, 5, null, null, "404-942-3-055", "Storm Trooper", 7800.00m, 1, "str-3-055" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 686, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-086@empire.org", "STR-3-086", "N/A", false, false, null, 5, null, null, "404-942-3-086", "Storm Trooper", 7800.00m, 1, "str-3-086" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 687, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-087@empire.org", "STR-3-087", "N/A", false, false, null, 5, null, null, "404-942-3-087", "Storm Trooper", 7800.00m, 1, "str-3-087" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 688, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-088@empire.org", "STR-3-088", "N/A", false, false, null, 5, null, null, "404-942-3-088", "Storm Trooper", 7800.00m, 1, "str-3-088" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 721, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-121@empire.org", "STR-3-121", "N/A", false, false, null, 5, null, null, "404-942-3-121", "Storm Trooper", 10000m, 2, "str-3-121" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 722, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-122@empire.org", "STR-3-122", "N/A", false, false, null, 5, null, null, "404-942-3-122", "Storm Trooper", 10000m, 2, "str-3-122" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 723, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-123@empire.org", "STR-3-123", "N/A", false, false, null, 5, null, null, "404-942-3-123", "Storm Trooper", 10000m, 2, "str-3-123" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 724, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-124@empire.org", "STR-3-124", "N/A", false, false, null, 5, null, null, "404-942-3-124", "Storm Trooper", 10000m, 2, "str-3-124" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 725, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-125@empire.org", "STR-3-125", "N/A", false, false, null, 5, null, null, "404-942-3-125", "Storm Trooper", 10000m, 2, "str-3-125" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 726, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-126@empire.org", "STR-3-126", "N/A", false, false, null, 5, null, null, "404-942-3-126", "Storm Trooper", 10000m, 2, "str-3-126" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 727, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-127@empire.org", "STR-3-127", "N/A", false, false, null, 5, null, null, "404-942-3-127", "Storm Trooper", 10000m, 2, "str-3-127" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 728, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-128@empire.org", "STR-3-128", "N/A", false, false, null, 5, null, null, "404-942-3-128", "Storm Trooper", 10000m, 2, "str-3-128" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 729, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-129@empire.org", "STR-3-129", "N/A", false, false, null, 5, null, null, "404-942-3-129", "Storm Trooper", 10000m, 2, "str-3-129" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 730, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-130@empire.org", "STR-3-130", "N/A", false, false, null, 5, null, null, "404-942-3-130", "Storm Trooper", 10000m, 2, "str-3-130" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 731, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-131@empire.org", "STR-3-131", "N/A", false, false, null, 5, null, null, "404-942-3-131", "Storm Trooper", 10000m, 2, "str-3-131" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 732, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-132@empire.org", "STR-3-132", "N/A", false, false, null, 5, null, null, "404-942-3-132", "Storm Trooper", 10000m, 2, "str-3-132" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 733, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-133@empire.org", "STR-3-133", "N/A", false, false, null, 5, null, null, "404-942-3-133", "Storm Trooper", 10000m, 2, "str-3-133" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 734, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-134@empire.org", "STR-3-134", "N/A", false, false, null, 5, null, null, "404-942-3-134", "Storm Trooper", 10000m, 2, "str-3-134" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 735, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-135@empire.org", "STR-3-135", "N/A", false, false, null, 5, null, null, "404-942-3-135", "Storm Trooper", 10000m, 2, "str-3-135" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 736, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-136@empire.org", "STR-3-136", "N/A", false, false, null, 5, null, null, "404-942-3-136", "Storm Trooper", 10000m, 2, "str-3-136" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 737, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-137@empire.org", "STR-3-137", "N/A", false, false, null, 5, null, null, "404-942-3-137", "Storm Trooper", 10000m, 2, "str-3-137" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 738, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-138@empire.org", "STR-3-138", "N/A", false, false, null, 5, null, null, "404-942-3-138", "Storm Trooper", 10000m, 2, "str-3-138" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 739, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-139@empire.org", "STR-3-139", "N/A", false, false, null, 5, null, null, "404-942-3-139", "Storm Trooper", 10000m, 2, "str-3-139" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 740, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-140@empire.org", "STR-3-140", "N/A", false, false, null, 5, null, null, "404-942-3-140", "Storm Trooper", 10000m, 2, "str-3-140" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 741, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-141@empire.org", "STR-3-141", "N/A", false, false, null, 5, null, null, "404-942-3-141", "Storm Trooper", 10000m, 2, "str-3-141" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 742, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-142@empire.org", "STR-3-142", "N/A", false, false, null, 5, null, null, "404-942-3-142", "Storm Trooper", 10000m, 2, "str-3-142" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 743, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-143@empire.org", "STR-3-143", "N/A", false, false, null, 5, null, null, "404-942-3-143", "Storm Trooper", 10000m, 2, "str-3-143" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 744, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-144@empire.org", "STR-3-144", "N/A", false, false, null, 5, null, null, "404-942-3-144", "Storm Trooper", 10000m, 2, "str-3-144" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 745, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-145@empire.org", "STR-3-145", "N/A", false, false, null, 5, null, null, "404-942-3-145", "Storm Trooper", 10000m, 2, "str-3-145" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 746, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-146@empire.org", "STR-3-146", "N/A", false, false, null, 5, null, null, "404-942-3-146", "Storm Trooper", 10000m, 2, "str-3-146" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 747, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-147@empire.org", "STR-3-147", "N/A", false, false, null, 5, null, null, "404-942-3-147", "Storm Trooper", 10000m, 2, "str-3-147" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 720, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-120@empire.org", "STR-3-120", "N/A", false, false, null, 5, null, null, "404-942-3-120", "Storm Trooper", 10000m, 2, "str-3-120" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 719, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-119@empire.org", "STR-3-119", "N/A", false, false, null, 5, null, null, "404-942-3-119", "Storm Trooper", 10000m, 2, "str-3-119" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 718, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-118@empire.org", "STR-3-118", "N/A", false, false, null, 5, null, null, "404-942-3-118", "Storm Trooper", 10000m, 2, "str-3-118" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 717, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-117@empire.org", "STR-3-117", "N/A", false, false, null, 5, null, null, "404-942-3-117", "Storm Trooper", 10000m, 2, "str-3-117" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 689, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-089@empire.org", "STR-3-089", "N/A", false, false, null, 5, null, null, "404-942-3-089", "Storm Trooper", 7800.00m, 1, "str-3-089" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 690, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-090@empire.org", "STR-3-090", "N/A", false, false, null, 5, null, null, "404-942-3-090", "Storm Trooper", 7800.00m, 1, "str-3-090" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 691, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-091@empire.org", "STR-3-091", "N/A", false, false, null, 5, null, null, "404-942-3-091", "Storm Trooper", 7800.00m, 1, "str-3-091" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 692, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-092@empire.org", "STR-3-092", "N/A", false, false, null, 5, null, null, "404-942-3-092", "Storm Trooper", 7800.00m, 1, "str-3-092" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 693, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-093@empire.org", "STR-3-093", "N/A", false, false, null, 5, null, null, "404-942-3-093", "Storm Trooper", 7800.00m, 1, "str-3-093" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 694, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-094@empire.org", "STR-3-094", "N/A", false, false, null, 5, null, null, "404-942-3-094", "Storm Trooper", 7800.00m, 1, "str-3-094" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 695, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-095@empire.org", "STR-3-095", "N/A", false, false, null, 5, null, null, "404-942-3-095", "Storm Trooper", 7800.00m, 1, "str-3-095" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 696, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-096@empire.org", "STR-3-096", "N/A", false, false, null, 5, null, null, "404-942-3-096", "Storm Trooper", 7800.00m, 1, "str-3-096" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 697, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-097@empire.org", "STR-3-097", "N/A", false, false, null, 5, null, null, "404-942-3-097", "Storm Trooper", 7800.00m, 1, "str-3-097" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 698, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-098@empire.org", "STR-3-098", "N/A", false, false, null, 5, null, null, "404-942-3-098", "Storm Trooper", 7800.00m, 1, "str-3-098" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 699, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-099@empire.org", "STR-3-099", "N/A", false, false, null, 5, null, null, "404-942-3-099", "Storm Trooper", 7800.00m, 1, "str-3-099" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 700, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-0100@empire.org", "STR-3-0100", "N/A", false, false, null, 5, null, null, "404-942-3-0100", "Storm Trooper", 7800.00m, 1, "str-3-0100" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 701, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-11@empire.org", "STR-3-11", "N/A", false, false, null, 5, null, null, "404-942-3-11", "Storm Trooper", 10000m, 2, "str-3-11" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 626, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-026@empire.org", "STR-3-026", "N/A", false, false, null, 5, null, null, "404-942-3-026", "Storm Trooper", 7800.00m, 1, "str-3-026" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 702, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-12@empire.org", "STR-3-12", "N/A", false, false, null, 5, null, null, "404-942-3-12", "Storm Trooper", 10000m, 2, "str-3-12" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 704, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-14@empire.org", "STR-3-14", "N/A", false, false, null, 5, null, null, "404-942-3-14", "Storm Trooper", 10000m, 2, "str-3-14" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 705, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-15@empire.org", "STR-3-15", "N/A", false, false, null, 5, null, null, "404-942-3-15", "Storm Trooper", 10000m, 2, "str-3-15" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 706, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-16@empire.org", "STR-3-16", "N/A", false, false, null, 5, null, null, "404-942-3-16", "Storm Trooper", 10000m, 2, "str-3-16" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 707, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-17@empire.org", "STR-3-17", "N/A", false, false, null, 5, null, null, "404-942-3-17", "Storm Trooper", 10000m, 2, "str-3-17" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 708, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-18@empire.org", "STR-3-18", "N/A", false, false, null, 5, null, null, "404-942-3-18", "Storm Trooper", 10000m, 2, "str-3-18" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 709, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-19@empire.org", "STR-3-19", "N/A", false, false, null, 5, null, null, "404-942-3-19", "Storm Trooper", 10000m, 2, "str-3-19" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 710, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-110@empire.org", "STR-3-110", "N/A", false, false, null, 5, null, null, "404-942-3-110", "Storm Trooper", 10000m, 2, "str-3-110" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 711, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-111@empire.org", "STR-3-111", "N/A", false, false, null, 5, null, null, "404-942-3-111", "Storm Trooper", 10000m, 2, "str-3-111" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 712, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-112@empire.org", "STR-3-112", "N/A", false, false, null, 5, null, null, "404-942-3-112", "Storm Trooper", 10000m, 2, "str-3-112" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 713, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-113@empire.org", "STR-3-113", "N/A", false, false, null, 5, null, null, "404-942-3-113", "Storm Trooper", 10000m, 2, "str-3-113" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 714, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-114@empire.org", "STR-3-114", "N/A", false, false, null, 5, null, null, "404-942-3-114", "Storm Trooper", 10000m, 2, "str-3-114" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 715, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-115@empire.org", "STR-3-115", "N/A", false, false, null, 5, null, null, "404-942-3-115", "Storm Trooper", 10000m, 2, "str-3-115" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 716, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-116@empire.org", "STR-3-116", "N/A", false, false, null, 5, null, null, "404-942-3-116", "Storm Trooper", 10000m, 2, "str-3-116" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 703, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-13@empire.org", "STR-3-13", "N/A", false, false, null, 5, null, null, "404-942-3-13", "Storm Trooper", 10000m, 2, "str-3-13" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 748, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-148@empire.org", "STR-3-148", "N/A", false, false, null, 5, null, null, "404-942-3-148", "Storm Trooper", 10000m, 2, "str-3-148" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 625, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-025@empire.org", "STR-3-025", "N/A", false, false, null, 5, null, null, "404-942-3-025", "Storm Trooper", 7800.00m, 1, "str-3-025" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 623, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-023@empire.org", "STR-3-023", "N/A", false, false, null, 5, null, null, "404-942-3-023", "Storm Trooper", 7800.00m, 1, "str-3-023" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 533, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-133@empire.org", "STR-2-133", "N/A", false, false, null, 5, null, null, "404-942-2-133", "Storm Trooper", 10000m, 2, "str-2-133" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 534, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-134@empire.org", "STR-2-134", "N/A", false, false, null, 5, null, null, "404-942-2-134", "Storm Trooper", 10000m, 2, "str-2-134" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 535, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-135@empire.org", "STR-2-135", "N/A", false, false, null, 5, null, null, "404-942-2-135", "Storm Trooper", 10000m, 2, "str-2-135" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 536, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-136@empire.org", "STR-2-136", "N/A", false, false, null, 5, null, null, "404-942-2-136", "Storm Trooper", 10000m, 2, "str-2-136" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 537, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-137@empire.org", "STR-2-137", "N/A", false, false, null, 5, null, null, "404-942-2-137", "Storm Trooper", 10000m, 2, "str-2-137" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 538, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-138@empire.org", "STR-2-138", "N/A", false, false, null, 5, null, null, "404-942-2-138", "Storm Trooper", 10000m, 2, "str-2-138" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 539, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-139@empire.org", "STR-2-139", "N/A", false, false, null, 5, null, null, "404-942-2-139", "Storm Trooper", 10000m, 2, "str-2-139" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 540, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-140@empire.org", "STR-2-140", "N/A", false, false, null, 5, null, null, "404-942-2-140", "Storm Trooper", 10000m, 2, "str-2-140" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 541, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-141@empire.org", "STR-2-141", "N/A", false, false, null, 5, null, null, "404-942-2-141", "Storm Trooper", 10000m, 2, "str-2-141" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 542, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-142@empire.org", "STR-2-142", "N/A", false, false, null, 5, null, null, "404-942-2-142", "Storm Trooper", 10000m, 2, "str-2-142" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 543, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-143@empire.org", "STR-2-143", "N/A", false, false, null, 5, null, null, "404-942-2-143", "Storm Trooper", 10000m, 2, "str-2-143" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 544, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-144@empire.org", "STR-2-144", "N/A", false, false, null, 5, null, null, "404-942-2-144", "Storm Trooper", 10000m, 2, "str-2-144" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 545, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-145@empire.org", "STR-2-145", "N/A", false, false, null, 5, null, null, "404-942-2-145", "Storm Trooper", 10000m, 2, "str-2-145" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 546, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-146@empire.org", "STR-2-146", "N/A", false, false, null, 5, null, null, "404-942-2-146", "Storm Trooper", 10000m, 2, "str-2-146" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 547, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-147@empire.org", "STR-2-147", "N/A", false, false, null, 5, null, null, "404-942-2-147", "Storm Trooper", 10000m, 2, "str-2-147" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 548, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-148@empire.org", "STR-2-148", "N/A", false, false, null, 5, null, null, "404-942-2-148", "Storm Trooper", 10000m, 2, "str-2-148" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 549, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-149@empire.org", "STR-2-149", "N/A", false, false, null, 5, null, null, "404-942-2-149", "Storm Trooper", 10000m, 2, "str-2-149" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 550, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-150@empire.org", "STR-2-150", "N/A", false, false, null, 5, null, null, "404-942-2-150", "Storm Trooper", 10000m, 2, "str-2-150" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 551, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-151@empire.org", "STR-2-151", "N/A", false, false, null, 5, null, null, "404-942-2-151", "Storm Trooper", 10000m, 2, "str-2-151" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 552, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-152@empire.org", "STR-2-152", "N/A", false, false, null, 5, null, null, "404-942-2-152", "Storm Trooper", 10000m, 2, "str-2-152" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 553, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-153@empire.org", "STR-2-153", "N/A", false, false, null, 5, null, null, "404-942-2-153", "Storm Trooper", 10000m, 2, "str-2-153" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 554, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-154@empire.org", "STR-2-154", "N/A", false, false, null, 5, null, null, "404-942-2-154", "Storm Trooper", 10000m, 2, "str-2-154" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 555, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-155@empire.org", "STR-2-155", "N/A", false, false, null, 5, null, null, "404-942-2-155", "Storm Trooper", 10000m, 2, "str-2-155" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 556, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-156@empire.org", "STR-2-156", "N/A", false, false, null, 5, null, null, "404-942-2-156", "Storm Trooper", 10000m, 2, "str-2-156" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 557, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-157@empire.org", "STR-2-157", "N/A", false, false, null, 5, null, null, "404-942-2-157", "Storm Trooper", 10000m, 2, "str-2-157" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 558, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-158@empire.org", "STR-2-158", "N/A", false, false, null, 5, null, null, "404-942-2-158", "Storm Trooper", 10000m, 2, "str-2-158" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 559, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-159@empire.org", "STR-2-159", "N/A", false, false, null, 5, null, null, "404-942-2-159", "Storm Trooper", 10000m, 2, "str-2-159" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 532, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-132@empire.org", "STR-2-132", "N/A", false, false, null, 5, null, null, "404-942-2-132", "Storm Trooper", 10000m, 2, "str-2-132" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 560, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-160@empire.org", "STR-2-160", "N/A", false, false, null, 5, null, null, "404-942-2-160", "Storm Trooper", 10000m, 2, "str-2-160" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 531, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-131@empire.org", "STR-2-131", "N/A", false, false, null, 5, null, null, "404-942-2-131", "Storm Trooper", 10000m, 2, "str-2-131" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 529, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-129@empire.org", "STR-2-129", "N/A", false, false, null, 5, null, null, "404-942-2-129", "Storm Trooper", 10000m, 2, "str-2-129" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 502, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-12@empire.org", "STR-2-12", "N/A", false, false, null, 5, null, null, "404-942-2-12", "Storm Trooper", 10000m, 2, "str-2-12" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 503, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-13@empire.org", "STR-2-13", "N/A", false, false, null, 5, null, null, "404-942-2-13", "Storm Trooper", 10000m, 2, "str-2-13" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 504, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-14@empire.org", "STR-2-14", "N/A", false, false, null, 5, null, null, "404-942-2-14", "Storm Trooper", 10000m, 2, "str-2-14" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 505, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-15@empire.org", "STR-2-15", "N/A", false, false, null, 5, null, null, "404-942-2-15", "Storm Trooper", 10000m, 2, "str-2-15" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 506, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-16@empire.org", "STR-2-16", "N/A", false, false, null, 5, null, null, "404-942-2-16", "Storm Trooper", 10000m, 2, "str-2-16" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 507, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-17@empire.org", "STR-2-17", "N/A", false, false, null, 5, null, null, "404-942-2-17", "Storm Trooper", 10000m, 2, "str-2-17" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 508, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-18@empire.org", "STR-2-18", "N/A", false, false, null, 5, null, null, "404-942-2-18", "Storm Trooper", 10000m, 2, "str-2-18" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 509, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-19@empire.org", "STR-2-19", "N/A", false, false, null, 5, null, null, "404-942-2-19", "Storm Trooper", 10000m, 2, "str-2-19" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 510, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-110@empire.org", "STR-2-110", "N/A", false, false, null, 5, null, null, "404-942-2-110", "Storm Trooper", 10000m, 2, "str-2-110" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 511, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-111@empire.org", "STR-2-111", "N/A", false, false, null, 5, null, null, "404-942-2-111", "Storm Trooper", 10000m, 2, "str-2-111" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 512, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-112@empire.org", "STR-2-112", "N/A", false, false, null, 5, null, null, "404-942-2-112", "Storm Trooper", 10000m, 2, "str-2-112" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 513, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-113@empire.org", "STR-2-113", "N/A", false, false, null, 5, null, null, "404-942-2-113", "Storm Trooper", 10000m, 2, "str-2-113" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 514, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-114@empire.org", "STR-2-114", "N/A", false, false, null, 5, null, null, "404-942-2-114", "Storm Trooper", 10000m, 2, "str-2-114" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 515, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-115@empire.org", "STR-2-115", "N/A", false, false, null, 5, null, null, "404-942-2-115", "Storm Trooper", 10000m, 2, "str-2-115" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 516, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-116@empire.org", "STR-2-116", "N/A", false, false, null, 5, null, null, "404-942-2-116", "Storm Trooper", 10000m, 2, "str-2-116" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 517, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-117@empire.org", "STR-2-117", "N/A", false, false, null, 5, null, null, "404-942-2-117", "Storm Trooper", 10000m, 2, "str-2-117" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 518, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-118@empire.org", "STR-2-118", "N/A", false, false, null, 5, null, null, "404-942-2-118", "Storm Trooper", 10000m, 2, "str-2-118" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 519, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-119@empire.org", "STR-2-119", "N/A", false, false, null, 5, null, null, "404-942-2-119", "Storm Trooper", 10000m, 2, "str-2-119" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 520, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-120@empire.org", "STR-2-120", "N/A", false, false, null, 5, null, null, "404-942-2-120", "Storm Trooper", 10000m, 2, "str-2-120" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 521, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-121@empire.org", "STR-2-121", "N/A", false, false, null, 5, null, null, "404-942-2-121", "Storm Trooper", 10000m, 2, "str-2-121" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 522, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-122@empire.org", "STR-2-122", "N/A", false, false, null, 5, null, null, "404-942-2-122", "Storm Trooper", 10000m, 2, "str-2-122" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 523, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-123@empire.org", "STR-2-123", "N/A", false, false, null, 5, null, null, "404-942-2-123", "Storm Trooper", 10000m, 2, "str-2-123" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 524, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-124@empire.org", "STR-2-124", "N/A", false, false, null, 5, null, null, "404-942-2-124", "Storm Trooper", 10000m, 2, "str-2-124" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 525, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-125@empire.org", "STR-2-125", "N/A", false, false, null, 5, null, null, "404-942-2-125", "Storm Trooper", 10000m, 2, "str-2-125" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 526, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-126@empire.org", "STR-2-126", "N/A", false, false, null, 5, null, null, "404-942-2-126", "Storm Trooper", 10000m, 2, "str-2-126" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 527, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-127@empire.org", "STR-2-127", "N/A", false, false, null, 5, null, null, "404-942-2-127", "Storm Trooper", 10000m, 2, "str-2-127" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 528, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-128@empire.org", "STR-2-128", "N/A", false, false, null, 5, null, null, "404-942-2-128", "Storm Trooper", 10000m, 2, "str-2-128" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 530, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-130@empire.org", "STR-2-130", "N/A", false, false, null, 5, null, null, "404-942-2-130", "Storm Trooper", 10000m, 2, "str-2-130" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 561, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-161@empire.org", "STR-2-161", "N/A", false, false, null, 5, null, null, "404-942-2-161", "Storm Trooper", 10000m, 2, "str-2-161" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 562, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-162@empire.org", "STR-2-162", "N/A", false, false, null, 5, null, null, "404-942-2-162", "Storm Trooper", 10000m, 2, "str-2-162" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 563, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-163@empire.org", "STR-2-163", "N/A", false, false, null, 5, null, null, "404-942-2-163", "Storm Trooper", 10000m, 2, "str-2-163" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 596, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-196@empire.org", "STR-2-196", "N/A", false, false, null, 5, null, null, "404-942-2-196", "Storm Trooper", 10000m, 2, "str-2-196" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 597, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-197@empire.org", "STR-2-197", "N/A", false, false, null, 5, null, null, "404-942-2-197", "Storm Trooper", 10000m, 2, "str-2-197" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 598, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-198@empire.org", "STR-2-198", "N/A", false, false, null, 5, null, null, "404-942-2-198", "Storm Trooper", 10000m, 2, "str-2-198" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 599, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-199@empire.org", "STR-2-199", "N/A", false, false, null, 5, null, null, "404-942-2-199", "Storm Trooper", 10000m, 2, "str-2-199" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 600, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-1100@empire.org", "STR-2-1100", "N/A", false, false, null, 5, null, null, "404-942-2-1100", "Storm Trooper", 10000m, 2, "str-2-1100" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 601, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-01@empire.org", "STR-3-01", "N/A", false, false, null, 5, null, null, "404-942-3-01", "Storm Trooper", 7800.00m, 1, "str-3-01" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 602, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-02@empire.org", "STR-3-02", "N/A", false, false, null, 5, null, null, "404-942-3-02", "Storm Trooper", 7800.00m, 1, "str-3-02" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 603, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-03@empire.org", "STR-3-03", "N/A", false, false, null, 5, null, null, "404-942-3-03", "Storm Trooper", 7800.00m, 1, "str-3-03" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 604, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-04@empire.org", "STR-3-04", "N/A", false, false, null, 5, null, null, "404-942-3-04", "Storm Trooper", 7800.00m, 1, "str-3-04" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 605, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-05@empire.org", "STR-3-05", "N/A", false, false, null, 5, null, null, "404-942-3-05", "Storm Trooper", 7800.00m, 1, "str-3-05" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 606, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-06@empire.org", "STR-3-06", "N/A", false, false, null, 5, null, null, "404-942-3-06", "Storm Trooper", 7800.00m, 1, "str-3-06" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 607, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-07@empire.org", "STR-3-07", "N/A", false, false, null, 5, null, null, "404-942-3-07", "Storm Trooper", 7800.00m, 1, "str-3-07" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 608, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-08@empire.org", "STR-3-08", "N/A", false, false, null, 5, null, null, "404-942-3-08", "Storm Trooper", 7800.00m, 1, "str-3-08" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 609, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-09@empire.org", "STR-3-09", "N/A", false, false, null, 5, null, null, "404-942-3-09", "Storm Trooper", 7800.00m, 1, "str-3-09" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 610, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-010@empire.org", "STR-3-010", "N/A", false, false, null, 5, null, null, "404-942-3-010", "Storm Trooper", 7800.00m, 1, "str-3-010" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 611, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-011@empire.org", "STR-3-011", "N/A", false, false, null, 5, null, null, "404-942-3-011", "Storm Trooper", 7800.00m, 1, "str-3-011" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 612, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-012@empire.org", "STR-3-012", "N/A", false, false, null, 5, null, null, "404-942-3-012", "Storm Trooper", 7800.00m, 1, "str-3-012" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 613, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-013@empire.org", "STR-3-013", "N/A", false, false, null, 5, null, null, "404-942-3-013", "Storm Trooper", 7800.00m, 1, "str-3-013" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 614, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-014@empire.org", "STR-3-014", "N/A", false, false, null, 5, null, null, "404-942-3-014", "Storm Trooper", 7800.00m, 1, "str-3-014" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 615, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-015@empire.org", "STR-3-015", "N/A", false, false, null, 5, null, null, "404-942-3-015", "Storm Trooper", 7800.00m, 1, "str-3-015" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 616, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-016@empire.org", "STR-3-016", "N/A", false, false, null, 5, null, null, "404-942-3-016", "Storm Trooper", 7800.00m, 1, "str-3-016" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 617, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-017@empire.org", "STR-3-017", "N/A", false, false, null, 5, null, null, "404-942-3-017", "Storm Trooper", 7800.00m, 1, "str-3-017" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 618, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-018@empire.org", "STR-3-018", "N/A", false, false, null, 5, null, null, "404-942-3-018", "Storm Trooper", 7800.00m, 1, "str-3-018" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 619, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-019@empire.org", "STR-3-019", "N/A", false, false, null, 5, null, null, "404-942-3-019", "Storm Trooper", 7800.00m, 1, "str-3-019" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 620, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-020@empire.org", "STR-3-020", "N/A", false, false, null, 5, null, null, "404-942-3-020", "Storm Trooper", 7800.00m, 1, "str-3-020" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 621, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-021@empire.org", "STR-3-021", "N/A", false, false, null, 5, null, null, "404-942-3-021", "Storm Trooper", 7800.00m, 1, "str-3-021" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 622, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-022@empire.org", "STR-3-022", "N/A", false, false, null, 5, null, null, "404-942-3-022", "Storm Trooper", 7800.00m, 1, "str-3-022" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 595, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-195@empire.org", "STR-2-195", "N/A", false, false, null, 5, null, null, "404-942-2-195", "Storm Trooper", 10000m, 2, "str-2-195" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 594, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-194@empire.org", "STR-2-194", "N/A", false, false, null, 5, null, null, "404-942-2-194", "Storm Trooper", 10000m, 2, "str-2-194" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 593, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-193@empire.org", "STR-2-193", "N/A", false, false, null, 5, null, null, "404-942-2-193", "Storm Trooper", 10000m, 2, "str-2-193" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 592, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-192@empire.org", "STR-2-192", "N/A", false, false, null, 5, null, null, "404-942-2-192", "Storm Trooper", 10000m, 2, "str-2-192" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 564, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-164@empire.org", "STR-2-164", "N/A", false, false, null, 5, null, null, "404-942-2-164", "Storm Trooper", 10000m, 2, "str-2-164" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 565, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-165@empire.org", "STR-2-165", "N/A", false, false, null, 5, null, null, "404-942-2-165", "Storm Trooper", 10000m, 2, "str-2-165" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 566, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-166@empire.org", "STR-2-166", "N/A", false, false, null, 5, null, null, "404-942-2-166", "Storm Trooper", 10000m, 2, "str-2-166" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 567, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-167@empire.org", "STR-2-167", "N/A", false, false, null, 5, null, null, "404-942-2-167", "Storm Trooper", 10000m, 2, "str-2-167" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 568, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-168@empire.org", "STR-2-168", "N/A", false, false, null, 5, null, null, "404-942-2-168", "Storm Trooper", 10000m, 2, "str-2-168" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 569, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-169@empire.org", "STR-2-169", "N/A", false, false, null, 5, null, null, "404-942-2-169", "Storm Trooper", 10000m, 2, "str-2-169" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 570, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-170@empire.org", "STR-2-170", "N/A", false, false, null, 5, null, null, "404-942-2-170", "Storm Trooper", 10000m, 2, "str-2-170" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 571, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-171@empire.org", "STR-2-171", "N/A", false, false, null, 5, null, null, "404-942-2-171", "Storm Trooper", 10000m, 2, "str-2-171" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 572, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-172@empire.org", "STR-2-172", "N/A", false, false, null, 5, null, null, "404-942-2-172", "Storm Trooper", 10000m, 2, "str-2-172" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 573, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-173@empire.org", "STR-2-173", "N/A", false, false, null, 5, null, null, "404-942-2-173", "Storm Trooper", 10000m, 2, "str-2-173" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 574, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-174@empire.org", "STR-2-174", "N/A", false, false, null, 5, null, null, "404-942-2-174", "Storm Trooper", 10000m, 2, "str-2-174" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 575, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-175@empire.org", "STR-2-175", "N/A", false, false, null, 5, null, null, "404-942-2-175", "Storm Trooper", 10000m, 2, "str-2-175" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 576, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-176@empire.org", "STR-2-176", "N/A", false, false, null, 5, null, null, "404-942-2-176", "Storm Trooper", 10000m, 2, "str-2-176" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 624, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-024@empire.org", "STR-3-024", "N/A", false, false, null, 5, null, null, "404-942-3-024", "Storm Trooper", 7800.00m, 1, "str-3-024" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 577, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-177@empire.org", "STR-2-177", "N/A", false, false, null, 5, null, null, "404-942-2-177", "Storm Trooper", 10000m, 2, "str-2-177" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 579, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-179@empire.org", "STR-2-179", "N/A", false, false, null, 5, null, null, "404-942-2-179", "Storm Trooper", 10000m, 2, "str-2-179" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 580, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-180@empire.org", "STR-2-180", "N/A", false, false, null, 5, null, null, "404-942-2-180", "Storm Trooper", 10000m, 2, "str-2-180" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 581, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-181@empire.org", "STR-2-181", "N/A", false, false, null, 5, null, null, "404-942-2-181", "Storm Trooper", 10000m, 2, "str-2-181" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 582, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-182@empire.org", "STR-2-182", "N/A", false, false, null, 5, null, null, "404-942-2-182", "Storm Trooper", 10000m, 2, "str-2-182" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 583, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-183@empire.org", "STR-2-183", "N/A", false, false, null, 5, null, null, "404-942-2-183", "Storm Trooper", 10000m, 2, "str-2-183" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 584, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-184@empire.org", "STR-2-184", "N/A", false, false, null, 5, null, null, "404-942-2-184", "Storm Trooper", 10000m, 2, "str-2-184" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 585, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-185@empire.org", "STR-2-185", "N/A", false, false, null, 5, null, null, "404-942-2-185", "Storm Trooper", 10000m, 2, "str-2-185" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 586, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-186@empire.org", "STR-2-186", "N/A", false, false, null, 5, null, null, "404-942-2-186", "Storm Trooper", 10000m, 2, "str-2-186" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 587, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-187@empire.org", "STR-2-187", "N/A", false, false, null, 5, null, null, "404-942-2-187", "Storm Trooper", 10000m, 2, "str-2-187" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 588, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-188@empire.org", "STR-2-188", "N/A", false, false, null, 5, null, null, "404-942-2-188", "Storm Trooper", 10000m, 2, "str-2-188" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 589, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-189@empire.org", "STR-2-189", "N/A", false, false, null, 5, null, null, "404-942-2-189", "Storm Trooper", 10000m, 2, "str-2-189" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 590, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-190@empire.org", "STR-2-190", "N/A", false, false, null, 5, null, null, "404-942-2-190", "Storm Trooper", 10000m, 2, "str-2-190" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 591, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-191@empire.org", "STR-2-191", "N/A", false, false, null, 5, null, null, "404-942-2-191", "Storm Trooper", 10000m, 2, "str-2-191" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 578, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-178@empire.org", "STR-2-178", "N/A", false, false, null, 5, null, null, "404-942-2-178", "Storm Trooper", 10000m, 2, "str-2-178" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 749, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-149@empire.org", "STR-3-149", "N/A", false, false, null, 5, null, null, "404-942-3-149", "Storm Trooper", 10000m, 2, "str-3-149" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 750, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-150@empire.org", "STR-3-150", "N/A", false, false, null, 5, null, null, "404-942-3-150", "Storm Trooper", 10000m, 2, "str-3-150" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 751, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-151@empire.org", "STR-3-151", "N/A", false, false, null, 5, null, null, "404-942-3-151", "Storm Trooper", 10000m, 2, "str-3-151" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 909, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-19@empire.org", "STR-4-19", "N/A", false, false, null, 6, null, null, "404-942-4-19", "Storm Trooper", 10000m, 2, "str-4-19" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 910, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-110@empire.org", "STR-4-110", "N/A", false, false, null, 6, null, null, "404-942-4-110", "Storm Trooper", 10000m, 2, "str-4-110" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 911, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-111@empire.org", "STR-4-111", "N/A", false, false, null, 6, null, null, "404-942-4-111", "Storm Trooper", 10000m, 2, "str-4-111" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 912, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-112@empire.org", "STR-4-112", "N/A", false, false, null, 6, null, null, "404-942-4-112", "Storm Trooper", 10000m, 2, "str-4-112" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 913, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-113@empire.org", "STR-4-113", "N/A", false, false, null, 6, null, null, "404-942-4-113", "Storm Trooper", 10000m, 2, "str-4-113" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 914, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-114@empire.org", "STR-4-114", "N/A", false, false, null, 6, null, null, "404-942-4-114", "Storm Trooper", 10000m, 2, "str-4-114" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 915, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-115@empire.org", "STR-4-115", "N/A", false, false, null, 6, null, null, "404-942-4-115", "Storm Trooper", 10000m, 2, "str-4-115" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 916, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-116@empire.org", "STR-4-116", "N/A", false, false, null, 6, null, null, "404-942-4-116", "Storm Trooper", 10000m, 2, "str-4-116" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 917, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-117@empire.org", "STR-4-117", "N/A", false, false, null, 6, null, null, "404-942-4-117", "Storm Trooper", 10000m, 2, "str-4-117" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 918, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-118@empire.org", "STR-4-118", "N/A", false, false, null, 6, null, null, "404-942-4-118", "Storm Trooper", 10000m, 2, "str-4-118" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 919, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-119@empire.org", "STR-4-119", "N/A", false, false, null, 6, null, null, "404-942-4-119", "Storm Trooper", 10000m, 2, "str-4-119" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 920, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-120@empire.org", "STR-4-120", "N/A", false, false, null, 6, null, null, "404-942-4-120", "Storm Trooper", 10000m, 2, "str-4-120" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 921, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-121@empire.org", "STR-4-121", "N/A", false, false, null, 6, null, null, "404-942-4-121", "Storm Trooper", 10000m, 2, "str-4-121" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 922, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-122@empire.org", "STR-4-122", "N/A", false, false, null, 6, null, null, "404-942-4-122", "Storm Trooper", 10000m, 2, "str-4-122" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 923, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-123@empire.org", "STR-4-123", "N/A", false, false, null, 6, null, null, "404-942-4-123", "Storm Trooper", 10000m, 2, "str-4-123" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 924, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-124@empire.org", "STR-4-124", "N/A", false, false, null, 6, null, null, "404-942-4-124", "Storm Trooper", 10000m, 2, "str-4-124" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 925, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-125@empire.org", "STR-4-125", "N/A", false, false, null, 6, null, null, "404-942-4-125", "Storm Trooper", 10000m, 2, "str-4-125" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 926, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-126@empire.org", "STR-4-126", "N/A", false, false, null, 6, null, null, "404-942-4-126", "Storm Trooper", 10000m, 2, "str-4-126" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 927, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-127@empire.org", "STR-4-127", "N/A", false, false, null, 6, null, null, "404-942-4-127", "Storm Trooper", 10000m, 2, "str-4-127" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 928, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-128@empire.org", "STR-4-128", "N/A", false, false, null, 6, null, null, "404-942-4-128", "Storm Trooper", 10000m, 2, "str-4-128" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 929, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-129@empire.org", "STR-4-129", "N/A", false, false, null, 6, null, null, "404-942-4-129", "Storm Trooper", 10000m, 2, "str-4-129" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 930, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-130@empire.org", "STR-4-130", "N/A", false, false, null, 6, null, null, "404-942-4-130", "Storm Trooper", 10000m, 2, "str-4-130" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 931, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-131@empire.org", "STR-4-131", "N/A", false, false, null, 6, null, null, "404-942-4-131", "Storm Trooper", 10000m, 2, "str-4-131" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 932, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-132@empire.org", "STR-4-132", "N/A", false, false, null, 6, null, null, "404-942-4-132", "Storm Trooper", 10000m, 2, "str-4-132" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 933, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-133@empire.org", "STR-4-133", "N/A", false, false, null, 6, null, null, "404-942-4-133", "Storm Trooper", 10000m, 2, "str-4-133" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 934, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-134@empire.org", "STR-4-134", "N/A", false, false, null, 6, null, null, "404-942-4-134", "Storm Trooper", 10000m, 2, "str-4-134" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 935, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-135@empire.org", "STR-4-135", "N/A", false, false, null, 6, null, null, "404-942-4-135", "Storm Trooper", 10000m, 2, "str-4-135" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 908, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-18@empire.org", "STR-4-18", "N/A", false, false, null, 6, null, null, "404-942-4-18", "Storm Trooper", 10000m, 2, "str-4-18" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 936, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-136@empire.org", "STR-4-136", "N/A", false, false, null, 6, null, null, "404-942-4-136", "Storm Trooper", 10000m, 2, "str-4-136" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 907, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-17@empire.org", "STR-4-17", "N/A", false, false, null, 6, null, null, "404-942-4-17", "Storm Trooper", 10000m, 2, "str-4-17" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 905, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-15@empire.org", "STR-4-15", "N/A", false, false, null, 6, null, null, "404-942-4-15", "Storm Trooper", 10000m, 2, "str-4-15" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 878, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-078@empire.org", "STR-4-078", "N/A", false, false, null, 6, null, null, "404-942-4-078", "Storm Trooper", 7800.00m, 1, "str-4-078" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 879, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-079@empire.org", "STR-4-079", "N/A", false, false, null, 6, null, null, "404-942-4-079", "Storm Trooper", 7800.00m, 1, "str-4-079" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 880, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-080@empire.org", "STR-4-080", "N/A", false, false, null, 6, null, null, "404-942-4-080", "Storm Trooper", 7800.00m, 1, "str-4-080" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 881, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-081@empire.org", "STR-4-081", "N/A", false, false, null, 6, null, null, "404-942-4-081", "Storm Trooper", 7800.00m, 1, "str-4-081" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 882, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-082@empire.org", "STR-4-082", "N/A", false, false, null, 6, null, null, "404-942-4-082", "Storm Trooper", 7800.00m, 1, "str-4-082" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 883, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-083@empire.org", "STR-4-083", "N/A", false, false, null, 6, null, null, "404-942-4-083", "Storm Trooper", 7800.00m, 1, "str-4-083" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 884, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-084@empire.org", "STR-4-084", "N/A", false, false, null, 6, null, null, "404-942-4-084", "Storm Trooper", 7800.00m, 1, "str-4-084" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 885, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-085@empire.org", "STR-4-085", "N/A", false, false, null, 6, null, null, "404-942-4-085", "Storm Trooper", 7800.00m, 1, "str-4-085" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 886, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-086@empire.org", "STR-4-086", "N/A", false, false, null, 6, null, null, "404-942-4-086", "Storm Trooper", 7800.00m, 1, "str-4-086" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 887, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-087@empire.org", "STR-4-087", "N/A", false, false, null, 6, null, null, "404-942-4-087", "Storm Trooper", 7800.00m, 1, "str-4-087" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 888, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-088@empire.org", "STR-4-088", "N/A", false, false, null, 6, null, null, "404-942-4-088", "Storm Trooper", 7800.00m, 1, "str-4-088" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 889, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-089@empire.org", "STR-4-089", "N/A", false, false, null, 6, null, null, "404-942-4-089", "Storm Trooper", 7800.00m, 1, "str-4-089" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 890, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-090@empire.org", "STR-4-090", "N/A", false, false, null, 6, null, null, "404-942-4-090", "Storm Trooper", 7800.00m, 1, "str-4-090" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 891, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-091@empire.org", "STR-4-091", "N/A", false, false, null, 6, null, null, "404-942-4-091", "Storm Trooper", 7800.00m, 1, "str-4-091" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 892, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-092@empire.org", "STR-4-092", "N/A", false, false, null, 6, null, null, "404-942-4-092", "Storm Trooper", 7800.00m, 1, "str-4-092" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 893, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-093@empire.org", "STR-4-093", "N/A", false, false, null, 6, null, null, "404-942-4-093", "Storm Trooper", 7800.00m, 1, "str-4-093" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 894, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-094@empire.org", "STR-4-094", "N/A", false, false, null, 6, null, null, "404-942-4-094", "Storm Trooper", 7800.00m, 1, "str-4-094" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 895, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-095@empire.org", "STR-4-095", "N/A", false, false, null, 6, null, null, "404-942-4-095", "Storm Trooper", 7800.00m, 1, "str-4-095" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 896, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-096@empire.org", "STR-4-096", "N/A", false, false, null, 6, null, null, "404-942-4-096", "Storm Trooper", 7800.00m, 1, "str-4-096" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 897, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-097@empire.org", "STR-4-097", "N/A", false, false, null, 6, null, null, "404-942-4-097", "Storm Trooper", 7800.00m, 1, "str-4-097" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 898, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-098@empire.org", "STR-4-098", "N/A", false, false, null, 6, null, null, "404-942-4-098", "Storm Trooper", 7800.00m, 1, "str-4-098" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 899, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-099@empire.org", "STR-4-099", "N/A", false, false, null, 6, null, null, "404-942-4-099", "Storm Trooper", 7800.00m, 1, "str-4-099" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 900, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-0100@empire.org", "STR-4-0100", "N/A", false, false, null, 6, null, null, "404-942-4-0100", "Storm Trooper", 7800.00m, 1, "str-4-0100" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 901, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-11@empire.org", "STR-4-11", "N/A", false, false, null, 6, null, null, "404-942-4-11", "Storm Trooper", 10000m, 2, "str-4-11" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 902, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-12@empire.org", "STR-4-12", "N/A", false, false, null, 6, null, null, "404-942-4-12", "Storm Trooper", 10000m, 2, "str-4-12" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 903, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-13@empire.org", "STR-4-13", "N/A", false, false, null, 6, null, null, "404-942-4-13", "Storm Trooper", 10000m, 2, "str-4-13" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 904, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-14@empire.org", "STR-4-14", "N/A", false, false, null, 6, null, null, "404-942-4-14", "Storm Trooper", 10000m, 2, "str-4-14" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 906, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-16@empire.org", "STR-4-16", "N/A", false, false, null, 6, null, null, "404-942-4-16", "Storm Trooper", 10000m, 2, "str-4-16" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 937, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-137@empire.org", "STR-4-137", "N/A", false, false, null, 6, null, null, "404-942-4-137", "Storm Trooper", 10000m, 2, "str-4-137" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 938, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-138@empire.org", "STR-4-138", "N/A", false, false, null, 6, null, null, "404-942-4-138", "Storm Trooper", 10000m, 2, "str-4-138" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 939, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-139@empire.org", "STR-4-139", "N/A", false, false, null, 6, null, null, "404-942-4-139", "Storm Trooper", 10000m, 2, "str-4-139" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 972, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-172@empire.org", "STR-4-172", "N/A", false, false, null, 6, null, null, "404-942-4-172", "Storm Trooper", 10000m, 2, "str-4-172" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 973, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-173@empire.org", "STR-4-173", "N/A", false, false, null, 6, null, null, "404-942-4-173", "Storm Trooper", 10000m, 2, "str-4-173" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 974, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-174@empire.org", "STR-4-174", "N/A", false, false, null, 6, null, null, "404-942-4-174", "Storm Trooper", 10000m, 2, "str-4-174" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 975, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-175@empire.org", "STR-4-175", "N/A", false, false, null, 6, null, null, "404-942-4-175", "Storm Trooper", 10000m, 2, "str-4-175" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 976, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-176@empire.org", "STR-4-176", "N/A", false, false, null, 6, null, null, "404-942-4-176", "Storm Trooper", 10000m, 2, "str-4-176" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 977, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-177@empire.org", "STR-4-177", "N/A", false, false, null, 6, null, null, "404-942-4-177", "Storm Trooper", 10000m, 2, "str-4-177" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 978, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-178@empire.org", "STR-4-178", "N/A", false, false, null, 6, null, null, "404-942-4-178", "Storm Trooper", 10000m, 2, "str-4-178" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 979, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-179@empire.org", "STR-4-179", "N/A", false, false, null, 6, null, null, "404-942-4-179", "Storm Trooper", 10000m, 2, "str-4-179" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 980, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-180@empire.org", "STR-4-180", "N/A", false, false, null, 6, null, null, "404-942-4-180", "Storm Trooper", 10000m, 2, "str-4-180" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 981, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-181@empire.org", "STR-4-181", "N/A", false, false, null, 6, null, null, "404-942-4-181", "Storm Trooper", 10000m, 2, "str-4-181" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 982, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-182@empire.org", "STR-4-182", "N/A", false, false, null, 6, null, null, "404-942-4-182", "Storm Trooper", 10000m, 2, "str-4-182" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 983, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-183@empire.org", "STR-4-183", "N/A", false, false, null, 6, null, null, "404-942-4-183", "Storm Trooper", 10000m, 2, "str-4-183" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 984, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-184@empire.org", "STR-4-184", "N/A", false, false, null, 6, null, null, "404-942-4-184", "Storm Trooper", 10000m, 2, "str-4-184" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 985, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-185@empire.org", "STR-4-185", "N/A", false, false, null, 6, null, null, "404-942-4-185", "Storm Trooper", 10000m, 2, "str-4-185" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 986, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-186@empire.org", "STR-4-186", "N/A", false, false, null, 6, null, null, "404-942-4-186", "Storm Trooper", 10000m, 2, "str-4-186" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 987, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-187@empire.org", "STR-4-187", "N/A", false, false, null, 6, null, null, "404-942-4-187", "Storm Trooper", 10000m, 2, "str-4-187" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 988, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-188@empire.org", "STR-4-188", "N/A", false, false, null, 6, null, null, "404-942-4-188", "Storm Trooper", 10000m, 2, "str-4-188" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 989, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-189@empire.org", "STR-4-189", "N/A", false, false, null, 6, null, null, "404-942-4-189", "Storm Trooper", 10000m, 2, "str-4-189" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 990, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-190@empire.org", "STR-4-190", "N/A", false, false, null, 6, null, null, "404-942-4-190", "Storm Trooper", 10000m, 2, "str-4-190" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 991, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-191@empire.org", "STR-4-191", "N/A", false, false, null, 6, null, null, "404-942-4-191", "Storm Trooper", 10000m, 2, "str-4-191" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 992, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-192@empire.org", "STR-4-192", "N/A", false, false, null, 6, null, null, "404-942-4-192", "Storm Trooper", 10000m, 2, "str-4-192" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 993, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-193@empire.org", "STR-4-193", "N/A", false, false, null, 6, null, null, "404-942-4-193", "Storm Trooper", 10000m, 2, "str-4-193" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 994, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-194@empire.org", "STR-4-194", "N/A", false, false, null, 6, null, null, "404-942-4-194", "Storm Trooper", 10000m, 2, "str-4-194" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 995, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-195@empire.org", "STR-4-195", "N/A", false, false, null, 6, null, null, "404-942-4-195", "Storm Trooper", 10000m, 2, "str-4-195" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 996, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-196@empire.org", "STR-4-196", "N/A", false, false, null, 6, null, null, "404-942-4-196", "Storm Trooper", 10000m, 2, "str-4-196" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 997, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-197@empire.org", "STR-4-197", "N/A", false, false, null, 6, null, null, "404-942-4-197", "Storm Trooper", 10000m, 2, "str-4-197" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 998, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-198@empire.org", "STR-4-198", "N/A", false, false, null, 6, null, null, "404-942-4-198", "Storm Trooper", 10000m, 2, "str-4-198" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 971, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-171@empire.org", "STR-4-171", "N/A", false, false, null, 6, null, null, "404-942-4-171", "Storm Trooper", 10000m, 2, "str-4-171" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 970, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-170@empire.org", "STR-4-170", "N/A", false, false, null, 6, null, null, "404-942-4-170", "Storm Trooper", 10000m, 2, "str-4-170" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 969, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-169@empire.org", "STR-4-169", "N/A", false, false, null, 6, null, null, "404-942-4-169", "Storm Trooper", 10000m, 2, "str-4-169" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 968, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-168@empire.org", "STR-4-168", "N/A", false, false, null, 6, null, null, "404-942-4-168", "Storm Trooper", 10000m, 2, "str-4-168" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 940, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-140@empire.org", "STR-4-140", "N/A", false, false, null, 6, null, null, "404-942-4-140", "Storm Trooper", 10000m, 2, "str-4-140" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 941, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-141@empire.org", "STR-4-141", "N/A", false, false, null, 6, null, null, "404-942-4-141", "Storm Trooper", 10000m, 2, "str-4-141" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 942, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-142@empire.org", "STR-4-142", "N/A", false, false, null, 6, null, null, "404-942-4-142", "Storm Trooper", 10000m, 2, "str-4-142" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 943, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-143@empire.org", "STR-4-143", "N/A", false, false, null, 6, null, null, "404-942-4-143", "Storm Trooper", 10000m, 2, "str-4-143" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 944, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-144@empire.org", "STR-4-144", "N/A", false, false, null, 6, null, null, "404-942-4-144", "Storm Trooper", 10000m, 2, "str-4-144" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 945, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-145@empire.org", "STR-4-145", "N/A", false, false, null, 6, null, null, "404-942-4-145", "Storm Trooper", 10000m, 2, "str-4-145" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 946, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-146@empire.org", "STR-4-146", "N/A", false, false, null, 6, null, null, "404-942-4-146", "Storm Trooper", 10000m, 2, "str-4-146" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 947, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-147@empire.org", "STR-4-147", "N/A", false, false, null, 6, null, null, "404-942-4-147", "Storm Trooper", 10000m, 2, "str-4-147" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 948, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-148@empire.org", "STR-4-148", "N/A", false, false, null, 6, null, null, "404-942-4-148", "Storm Trooper", 10000m, 2, "str-4-148" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 949, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-149@empire.org", "STR-4-149", "N/A", false, false, null, 6, null, null, "404-942-4-149", "Storm Trooper", 10000m, 2, "str-4-149" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 950, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-150@empire.org", "STR-4-150", "N/A", false, false, null, 6, null, null, "404-942-4-150", "Storm Trooper", 10000m, 2, "str-4-150" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 951, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-151@empire.org", "STR-4-151", "N/A", false, false, null, 6, null, null, "404-942-4-151", "Storm Trooper", 10000m, 2, "str-4-151" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 952, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-152@empire.org", "STR-4-152", "N/A", false, false, null, 6, null, null, "404-942-4-152", "Storm Trooper", 10000m, 2, "str-4-152" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 877, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-077@empire.org", "STR-4-077", "N/A", false, false, null, 6, null, null, "404-942-4-077", "Storm Trooper", 7800.00m, 1, "str-4-077" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 953, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-153@empire.org", "STR-4-153", "N/A", false, false, null, 6, null, null, "404-942-4-153", "Storm Trooper", 10000m, 2, "str-4-153" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 955, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-155@empire.org", "STR-4-155", "N/A", false, false, null, 6, null, null, "404-942-4-155", "Storm Trooper", 10000m, 2, "str-4-155" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 956, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-156@empire.org", "STR-4-156", "N/A", false, false, null, 6, null, null, "404-942-4-156", "Storm Trooper", 10000m, 2, "str-4-156" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 957, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-157@empire.org", "STR-4-157", "N/A", false, false, null, 6, null, null, "404-942-4-157", "Storm Trooper", 10000m, 2, "str-4-157" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 958, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-158@empire.org", "STR-4-158", "N/A", false, false, null, 6, null, null, "404-942-4-158", "Storm Trooper", 10000m, 2, "str-4-158" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 959, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-159@empire.org", "STR-4-159", "N/A", false, false, null, 6, null, null, "404-942-4-159", "Storm Trooper", 10000m, 2, "str-4-159" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 960, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-160@empire.org", "STR-4-160", "N/A", false, false, null, 6, null, null, "404-942-4-160", "Storm Trooper", 10000m, 2, "str-4-160" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 961, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-161@empire.org", "STR-4-161", "N/A", false, false, null, 6, null, null, "404-942-4-161", "Storm Trooper", 10000m, 2, "str-4-161" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 962, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-162@empire.org", "STR-4-162", "N/A", false, false, null, 6, null, null, "404-942-4-162", "Storm Trooper", 10000m, 2, "str-4-162" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 963, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-163@empire.org", "STR-4-163", "N/A", false, false, null, 6, null, null, "404-942-4-163", "Storm Trooper", 10000m, 2, "str-4-163" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 964, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-164@empire.org", "STR-4-164", "N/A", false, false, null, 6, null, null, "404-942-4-164", "Storm Trooper", 10000m, 2, "str-4-164" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 965, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-165@empire.org", "STR-4-165", "N/A", false, false, null, 6, null, null, "404-942-4-165", "Storm Trooper", 10000m, 2, "str-4-165" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 966, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-166@empire.org", "STR-4-166", "N/A", false, false, null, 6, null, null, "404-942-4-166", "Storm Trooper", 10000m, 2, "str-4-166" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 967, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-167@empire.org", "STR-4-167", "N/A", false, false, null, 6, null, null, "404-942-4-167", "Storm Trooper", 10000m, 2, "str-4-167" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 954, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-154@empire.org", "STR-4-154", "N/A", false, false, null, 6, null, null, "404-942-4-154", "Storm Trooper", 10000m, 2, "str-4-154" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 876, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-076@empire.org", "STR-4-076", "N/A", false, false, null, 6, null, null, "404-942-4-076", "Storm Trooper", 7800.00m, 1, "str-4-076" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 875, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-075@empire.org", "STR-4-075", "N/A", false, false, null, 6, null, null, "404-942-4-075", "Storm Trooper", 7800.00m, 1, "str-4-075" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 874, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-074@empire.org", "STR-4-074", "N/A", false, false, null, 6, null, null, "404-942-4-074", "Storm Trooper", 7800.00m, 1, "str-4-074" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 784, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-184@empire.org", "STR-3-184", "N/A", false, false, null, 6, null, null, "404-942-3-184", "Storm Trooper", 10000m, 2, "str-3-184" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 785, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-185@empire.org", "STR-3-185", "N/A", false, false, null, 6, null, null, "404-942-3-185", "Storm Trooper", 10000m, 2, "str-3-185" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 786, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-186@empire.org", "STR-3-186", "N/A", false, false, null, 6, null, null, "404-942-3-186", "Storm Trooper", 10000m, 2, "str-3-186" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 787, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-187@empire.org", "STR-3-187", "N/A", false, false, null, 6, null, null, "404-942-3-187", "Storm Trooper", 10000m, 2, "str-3-187" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 788, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-188@empire.org", "STR-3-188", "N/A", false, false, null, 6, null, null, "404-942-3-188", "Storm Trooper", 10000m, 2, "str-3-188" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 789, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-189@empire.org", "STR-3-189", "N/A", false, false, null, 6, null, null, "404-942-3-189", "Storm Trooper", 10000m, 2, "str-3-189" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 790, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-190@empire.org", "STR-3-190", "N/A", false, false, null, 6, null, null, "404-942-3-190", "Storm Trooper", 10000m, 2, "str-3-190" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 791, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-191@empire.org", "STR-3-191", "N/A", false, false, null, 6, null, null, "404-942-3-191", "Storm Trooper", 10000m, 2, "str-3-191" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 792, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-192@empire.org", "STR-3-192", "N/A", false, false, null, 6, null, null, "404-942-3-192", "Storm Trooper", 10000m, 2, "str-3-192" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 793, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-193@empire.org", "STR-3-193", "N/A", false, false, null, 6, null, null, "404-942-3-193", "Storm Trooper", 10000m, 2, "str-3-193" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 794, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-194@empire.org", "STR-3-194", "N/A", false, false, null, 6, null, null, "404-942-3-194", "Storm Trooper", 10000m, 2, "str-3-194" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 795, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-195@empire.org", "STR-3-195", "N/A", false, false, null, 6, null, null, "404-942-3-195", "Storm Trooper", 10000m, 2, "str-3-195" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 796, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-196@empire.org", "STR-3-196", "N/A", false, false, null, 6, null, null, "404-942-3-196", "Storm Trooper", 10000m, 2, "str-3-196" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 797, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-197@empire.org", "STR-3-197", "N/A", false, false, null, 6, null, null, "404-942-3-197", "Storm Trooper", 10000m, 2, "str-3-197" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 798, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-198@empire.org", "STR-3-198", "N/A", false, false, null, 6, null, null, "404-942-3-198", "Storm Trooper", 10000m, 2, "str-3-198" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 799, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-199@empire.org", "STR-3-199", "N/A", false, false, null, 6, null, null, "404-942-3-199", "Storm Trooper", 10000m, 2, "str-3-199" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 800, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-1100@empire.org", "STR-3-1100", "N/A", false, false, null, 6, null, null, "404-942-3-1100", "Storm Trooper", 10000m, 2, "str-3-1100" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 801, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-01@empire.org", "STR-4-01", "N/A", false, false, null, 6, null, null, "404-942-4-01", "Storm Trooper", 7800.00m, 1, "str-4-01" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 802, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-02@empire.org", "STR-4-02", "N/A", false, false, null, 6, null, null, "404-942-4-02", "Storm Trooper", 7800.00m, 1, "str-4-02" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 803, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-03@empire.org", "STR-4-03", "N/A", false, false, null, 6, null, null, "404-942-4-03", "Storm Trooper", 7800.00m, 1, "str-4-03" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 804, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-04@empire.org", "STR-4-04", "N/A", false, false, null, 6, null, null, "404-942-4-04", "Storm Trooper", 7800.00m, 1, "str-4-04" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 805, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-05@empire.org", "STR-4-05", "N/A", false, false, null, 6, null, null, "404-942-4-05", "Storm Trooper", 7800.00m, 1, "str-4-05" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 806, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-06@empire.org", "STR-4-06", "N/A", false, false, null, 6, null, null, "404-942-4-06", "Storm Trooper", 7800.00m, 1, "str-4-06" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 807, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-07@empire.org", "STR-4-07", "N/A", false, false, null, 6, null, null, "404-942-4-07", "Storm Trooper", 7800.00m, 1, "str-4-07" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 808, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-08@empire.org", "STR-4-08", "N/A", false, false, null, 6, null, null, "404-942-4-08", "Storm Trooper", 7800.00m, 1, "str-4-08" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 809, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-09@empire.org", "STR-4-09", "N/A", false, false, null, 6, null, null, "404-942-4-09", "Storm Trooper", 7800.00m, 1, "str-4-09" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 810, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-010@empire.org", "STR-4-010", "N/A", false, false, null, 6, null, null, "404-942-4-010", "Storm Trooper", 7800.00m, 1, "str-4-010" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 783, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-183@empire.org", "STR-3-183", "N/A", false, false, null, 6, null, null, "404-942-3-183", "Storm Trooper", 10000m, 2, "str-3-183" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 782, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-182@empire.org", "STR-3-182", "N/A", false, false, null, 6, null, null, "404-942-3-182", "Storm Trooper", 10000m, 2, "str-3-182" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 781, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-181@empire.org", "STR-3-181", "N/A", false, false, null, 6, null, null, "404-942-3-181", "Storm Trooper", 10000m, 2, "str-3-181" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 780, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-180@empire.org", "STR-3-180", "N/A", false, false, null, 6, null, null, "404-942-3-180", "Storm Trooper", 10000m, 2, "str-3-180" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 752, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-152@empire.org", "STR-3-152", "N/A", false, false, null, 5, null, null, "404-942-3-152", "Storm Trooper", 10000m, 2, "str-3-152" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 753, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-153@empire.org", "STR-3-153", "N/A", false, false, null, 5, null, null, "404-942-3-153", "Storm Trooper", 10000m, 2, "str-3-153" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 754, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-154@empire.org", "STR-3-154", "N/A", false, false, null, 5, null, null, "404-942-3-154", "Storm Trooper", 10000m, 2, "str-3-154" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 755, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-155@empire.org", "STR-3-155", "N/A", false, false, null, 5, null, null, "404-942-3-155", "Storm Trooper", 10000m, 2, "str-3-155" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 756, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-156@empire.org", "STR-3-156", "N/A", false, false, null, 5, null, null, "404-942-3-156", "Storm Trooper", 10000m, 2, "str-3-156" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 757, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-157@empire.org", "STR-3-157", "N/A", false, false, null, 5, null, null, "404-942-3-157", "Storm Trooper", 10000m, 2, "str-3-157" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 758, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-158@empire.org", "STR-3-158", "N/A", false, false, null, 5, null, null, "404-942-3-158", "Storm Trooper", 10000m, 2, "str-3-158" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 759, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-159@empire.org", "STR-3-159", "N/A", false, false, null, 5, null, null, "404-942-3-159", "Storm Trooper", 10000m, 2, "str-3-159" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 760, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-160@empire.org", "STR-3-160", "N/A", false, false, null, 5, null, null, "404-942-3-160", "Storm Trooper", 10000m, 2, "str-3-160" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 761, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-161@empire.org", "STR-3-161", "N/A", false, false, null, 5, null, null, "404-942-3-161", "Storm Trooper", 10000m, 2, "str-3-161" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 762, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-162@empire.org", "STR-3-162", "N/A", false, false, null, 5, null, null, "404-942-3-162", "Storm Trooper", 10000m, 2, "str-3-162" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 763, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-163@empire.org", "STR-3-163", "N/A", false, false, null, 5, null, null, "404-942-3-163", "Storm Trooper", 10000m, 2, "str-3-163" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 764, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-164@empire.org", "STR-3-164", "N/A", false, false, null, 5, null, null, "404-942-3-164", "Storm Trooper", 10000m, 2, "str-3-164" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 811, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-011@empire.org", "STR-4-011", "N/A", false, false, null, 6, null, null, "404-942-4-011", "Storm Trooper", 7800.00m, 1, "str-4-011" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 765, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-165@empire.org", "STR-3-165", "N/A", false, false, null, 5, null, null, "404-942-3-165", "Storm Trooper", 10000m, 2, "str-3-165" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 767, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-167@empire.org", "STR-3-167", "N/A", false, false, null, 6, null, null, "404-942-3-167", "Storm Trooper", 10000m, 2, "str-3-167" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 768, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-168@empire.org", "STR-3-168", "N/A", false, false, null, 6, null, null, "404-942-3-168", "Storm Trooper", 10000m, 2, "str-3-168" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 769, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-169@empire.org", "STR-3-169", "N/A", false, false, null, 6, null, null, "404-942-3-169", "Storm Trooper", 10000m, 2, "str-3-169" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 770, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-170@empire.org", "STR-3-170", "N/A", false, false, null, 6, null, null, "404-942-3-170", "Storm Trooper", 10000m, 2, "str-3-170" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 771, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-171@empire.org", "STR-3-171", "N/A", false, false, null, 6, null, null, "404-942-3-171", "Storm Trooper", 10000m, 2, "str-3-171" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 772, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-172@empire.org", "STR-3-172", "N/A", false, false, null, 6, null, null, "404-942-3-172", "Storm Trooper", 10000m, 2, "str-3-172" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 773, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-173@empire.org", "STR-3-173", "N/A", false, false, null, 6, null, null, "404-942-3-173", "Storm Trooper", 10000m, 2, "str-3-173" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 774, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-174@empire.org", "STR-3-174", "N/A", false, false, null, 6, null, null, "404-942-3-174", "Storm Trooper", 10000m, 2, "str-3-174" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 775, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-175@empire.org", "STR-3-175", "N/A", false, false, null, 6, null, null, "404-942-3-175", "Storm Trooper", 10000m, 2, "str-3-175" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 776, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-176@empire.org", "STR-3-176", "N/A", false, false, null, 6, null, null, "404-942-3-176", "Storm Trooper", 10000m, 2, "str-3-176" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 777, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-177@empire.org", "STR-3-177", "N/A", false, false, null, 6, null, null, "404-942-3-177", "Storm Trooper", 10000m, 2, "str-3-177" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 778, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-178@empire.org", "STR-3-178", "N/A", false, false, null, 6, null, null, "404-942-3-178", "Storm Trooper", 10000m, 2, "str-3-178" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 779, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-179@empire.org", "STR-3-179", "N/A", false, false, null, 6, null, null, "404-942-3-179", "Storm Trooper", 10000m, 2, "str-3-179" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 766, "Mentally indoctrinated and ready to serve.", new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1992, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-3-166@empire.org", "STR-3-166", "N/A", false, false, null, 6, null, null, "404-942-3-166", "Storm Trooper", 10000m, 2, "str-3-166" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 501, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-11@empire.org", "STR-2-11", "N/A", false, false, null, 5, null, null, "404-942-2-11", "Storm Trooper", 10000m, 2, "str-2-11" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 812, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-012@empire.org", "STR-4-012", "N/A", false, false, null, 6, null, null, "404-942-4-012", "Storm Trooper", 7800.00m, 1, "str-4-012" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 814, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-014@empire.org", "STR-4-014", "N/A", false, false, null, 6, null, null, "404-942-4-014", "Storm Trooper", 7800.00m, 1, "str-4-014" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 847, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-047@empire.org", "STR-4-047", "N/A", false, false, null, 6, null, null, "404-942-4-047", "Storm Trooper", 7800.00m, 1, "str-4-047" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 848, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-048@empire.org", "STR-4-048", "N/A", false, false, null, 6, null, null, "404-942-4-048", "Storm Trooper", 7800.00m, 1, "str-4-048" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 849, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-049@empire.org", "STR-4-049", "N/A", false, false, null, 6, null, null, "404-942-4-049", "Storm Trooper", 7800.00m, 1, "str-4-049" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 850, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-050@empire.org", "STR-4-050", "N/A", false, false, null, 6, null, null, "404-942-4-050", "Storm Trooper", 7800.00m, 1, "str-4-050" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 851, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-051@empire.org", "STR-4-051", "N/A", false, false, null, 6, null, null, "404-942-4-051", "Storm Trooper", 7800.00m, 1, "str-4-051" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 852, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-052@empire.org", "STR-4-052", "N/A", false, false, null, 6, null, null, "404-942-4-052", "Storm Trooper", 7800.00m, 1, "str-4-052" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 853, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-053@empire.org", "STR-4-053", "N/A", false, false, null, 6, null, null, "404-942-4-053", "Storm Trooper", 7800.00m, 1, "str-4-053" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 854, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-054@empire.org", "STR-4-054", "N/A", false, false, null, 6, null, null, "404-942-4-054", "Storm Trooper", 7800.00m, 1, "str-4-054" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 855, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-055@empire.org", "STR-4-055", "N/A", false, false, null, 6, null, null, "404-942-4-055", "Storm Trooper", 7800.00m, 1, "str-4-055" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 856, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-056@empire.org", "STR-4-056", "N/A", false, false, null, 6, null, null, "404-942-4-056", "Storm Trooper", 7800.00m, 1, "str-4-056" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 857, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-057@empire.org", "STR-4-057", "N/A", false, false, null, 6, null, null, "404-942-4-057", "Storm Trooper", 7800.00m, 1, "str-4-057" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 858, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-058@empire.org", "STR-4-058", "N/A", false, false, null, 6, null, null, "404-942-4-058", "Storm Trooper", 7800.00m, 1, "str-4-058" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 859, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-059@empire.org", "STR-4-059", "N/A", false, false, null, 6, null, null, "404-942-4-059", "Storm Trooper", 7800.00m, 1, "str-4-059" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 860, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-060@empire.org", "STR-4-060", "N/A", false, false, null, 6, null, null, "404-942-4-060", "Storm Trooper", 7800.00m, 1, "str-4-060" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 861, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-061@empire.org", "STR-4-061", "N/A", false, false, null, 6, null, null, "404-942-4-061", "Storm Trooper", 7800.00m, 1, "str-4-061" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 862, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-062@empire.org", "STR-4-062", "N/A", false, false, null, 6, null, null, "404-942-4-062", "Storm Trooper", 7800.00m, 1, "str-4-062" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 863, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-063@empire.org", "STR-4-063", "N/A", false, false, null, 6, null, null, "404-942-4-063", "Storm Trooper", 7800.00m, 1, "str-4-063" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 864, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-064@empire.org", "STR-4-064", "N/A", false, false, null, 6, null, null, "404-942-4-064", "Storm Trooper", 7800.00m, 1, "str-4-064" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 865, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-065@empire.org", "STR-4-065", "N/A", false, false, null, 6, null, null, "404-942-4-065", "Storm Trooper", 7800.00m, 1, "str-4-065" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 866, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-066@empire.org", "STR-4-066", "N/A", false, false, null, 6, null, null, "404-942-4-066", "Storm Trooper", 7800.00m, 1, "str-4-066" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 867, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-067@empire.org", "STR-4-067", "N/A", false, false, null, 6, null, null, "404-942-4-067", "Storm Trooper", 7800.00m, 1, "str-4-067" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 868, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-068@empire.org", "STR-4-068", "N/A", false, false, null, 6, null, null, "404-942-4-068", "Storm Trooper", 7800.00m, 1, "str-4-068" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 869, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-069@empire.org", "STR-4-069", "N/A", false, false, null, 6, null, null, "404-942-4-069", "Storm Trooper", 7800.00m, 1, "str-4-069" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 870, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-070@empire.org", "STR-4-070", "N/A", false, false, null, 6, null, null, "404-942-4-070", "Storm Trooper", 7800.00m, 1, "str-4-070" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 871, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-071@empire.org", "STR-4-071", "N/A", false, false, null, 6, null, null, "404-942-4-071", "Storm Trooper", 7800.00m, 1, "str-4-071" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 872, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-072@empire.org", "STR-4-072", "N/A", false, false, null, 6, null, null, "404-942-4-072", "Storm Trooper", 7800.00m, 1, "str-4-072" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 873, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-073@empire.org", "STR-4-073", "N/A", false, false, null, 6, null, null, "404-942-4-073", "Storm Trooper", 7800.00m, 1, "str-4-073" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 846, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-046@empire.org", "STR-4-046", "N/A", false, false, null, 6, null, null, "404-942-4-046", "Storm Trooper", 7800.00m, 1, "str-4-046" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 845, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-045@empire.org", "STR-4-045", "N/A", false, false, null, 6, null, null, "404-942-4-045", "Storm Trooper", 7800.00m, 1, "str-4-045" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 844, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-044@empire.org", "STR-4-044", "N/A", false, false, null, 6, null, null, "404-942-4-044", "Storm Trooper", 7800.00m, 1, "str-4-044" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 843, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-043@empire.org", "STR-4-043", "N/A", false, false, null, 6, null, null, "404-942-4-043", "Storm Trooper", 7800.00m, 1, "str-4-043" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 815, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-015@empire.org", "STR-4-015", "N/A", false, false, null, 6, null, null, "404-942-4-015", "Storm Trooper", 7800.00m, 1, "str-4-015" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 816, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-016@empire.org", "STR-4-016", "N/A", false, false, null, 6, null, null, "404-942-4-016", "Storm Trooper", 7800.00m, 1, "str-4-016" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 817, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-017@empire.org", "STR-4-017", "N/A", false, false, null, 6, null, null, "404-942-4-017", "Storm Trooper", 7800.00m, 1, "str-4-017" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 818, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-018@empire.org", "STR-4-018", "N/A", false, false, null, 6, null, null, "404-942-4-018", "Storm Trooper", 7800.00m, 1, "str-4-018" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 819, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-019@empire.org", "STR-4-019", "N/A", false, false, null, 6, null, null, "404-942-4-019", "Storm Trooper", 7800.00m, 1, "str-4-019" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 820, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-020@empire.org", "STR-4-020", "N/A", false, false, null, 6, null, null, "404-942-4-020", "Storm Trooper", 7800.00m, 1, "str-4-020" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 821, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-021@empire.org", "STR-4-021", "N/A", false, false, null, 6, null, null, "404-942-4-021", "Storm Trooper", 7800.00m, 1, "str-4-021" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 822, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-022@empire.org", "STR-4-022", "N/A", false, false, null, 6, null, null, "404-942-4-022", "Storm Trooper", 7800.00m, 1, "str-4-022" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 823, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-023@empire.org", "STR-4-023", "N/A", false, false, null, 6, null, null, "404-942-4-023", "Storm Trooper", 7800.00m, 1, "str-4-023" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 824, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-024@empire.org", "STR-4-024", "N/A", false, false, null, 6, null, null, "404-942-4-024", "Storm Trooper", 7800.00m, 1, "str-4-024" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 825, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-025@empire.org", "STR-4-025", "N/A", false, false, null, 6, null, null, "404-942-4-025", "Storm Trooper", 7800.00m, 1, "str-4-025" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 826, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-026@empire.org", "STR-4-026", "N/A", false, false, null, 6, null, null, "404-942-4-026", "Storm Trooper", 7800.00m, 1, "str-4-026" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 827, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-027@empire.org", "STR-4-027", "N/A", false, false, null, 6, null, null, "404-942-4-027", "Storm Trooper", 7800.00m, 1, "str-4-027" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 813, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-013@empire.org", "STR-4-013", "N/A", false, false, null, 6, null, null, "404-942-4-013", "Storm Trooper", 7800.00m, 1, "str-4-013" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 828, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-028@empire.org", "STR-4-028", "N/A", false, false, null, 6, null, null, "404-942-4-028", "Storm Trooper", 7800.00m, 1, "str-4-028" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 830, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-030@empire.org", "STR-4-030", "N/A", false, false, null, 6, null, null, "404-942-4-030", "Storm Trooper", 7800.00m, 1, "str-4-030" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 831, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-031@empire.org", "STR-4-031", "N/A", false, false, null, 6, null, null, "404-942-4-031", "Storm Trooper", 7800.00m, 1, "str-4-031" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 832, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-032@empire.org", "STR-4-032", "N/A", false, false, null, 6, null, null, "404-942-4-032", "Storm Trooper", 7800.00m, 1, "str-4-032" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 833, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-033@empire.org", "STR-4-033", "N/A", false, false, null, 6, null, null, "404-942-4-033", "Storm Trooper", 7800.00m, 1, "str-4-033" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 834, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-034@empire.org", "STR-4-034", "N/A", false, false, null, 6, null, null, "404-942-4-034", "Storm Trooper", 7800.00m, 1, "str-4-034" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 835, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-035@empire.org", "STR-4-035", "N/A", false, false, null, 6, null, null, "404-942-4-035", "Storm Trooper", 7800.00m, 1, "str-4-035" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 836, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-036@empire.org", "STR-4-036", "N/A", false, false, null, 6, null, null, "404-942-4-036", "Storm Trooper", 7800.00m, 1, "str-4-036" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 837, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-037@empire.org", "STR-4-037", "N/A", false, false, null, 6, null, null, "404-942-4-037", "Storm Trooper", 7800.00m, 1, "str-4-037" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 838, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-038@empire.org", "STR-4-038", "N/A", false, false, null, 6, null, null, "404-942-4-038", "Storm Trooper", 7800.00m, 1, "str-4-038" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 839, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-039@empire.org", "STR-4-039", "N/A", false, false, null, 6, null, null, "404-942-4-039", "Storm Trooper", 7800.00m, 1, "str-4-039" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 840, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-040@empire.org", "STR-4-040", "N/A", false, false, null, 6, null, null, "404-942-4-040", "Storm Trooper", 7800.00m, 1, "str-4-040" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 841, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-041@empire.org", "STR-4-041", "N/A", false, false, null, 6, null, null, "404-942-4-041", "Storm Trooper", 7800.00m, 1, "str-4-041" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 842, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-042@empire.org", "STR-4-042", "N/A", false, false, null, 6, null, null, "404-942-4-042", "Storm Trooper", 7800.00m, 1, "str-4-042" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 829, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-029@empire.org", "STR-4-029", "N/A", false, false, null, 6, null, null, "404-942-4-029", "Storm Trooper", 7800.00m, 1, "str-4-029" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 500, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-0100@empire.org", "STR-2-0100", "N/A", false, false, null, 5, null, null, "404-942-2-0100", "Storm Trooper", 7800.00m, 1, "str-2-0100" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 499, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-099@empire.org", "STR-2-099", "N/A", false, false, null, 5, null, null, "404-942-2-099", "Storm Trooper", 7800.00m, 1, "str-2-099" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 498, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-098@empire.org", "STR-2-098", "N/A", false, false, null, 5, null, null, "404-942-2-098", "Storm Trooper", 7800.00m, 1, "str-2-098" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 158, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-158@empire.org", "STR-0-158", "N/A", false, false, null, 2, null, null, "404-942-0-158", "Storm Trooper", 10000m, 2, "str-0-158" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 159, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-159@empire.org", "STR-0-159", "N/A", false, false, null, 2, null, null, "404-942-0-159", "Storm Trooper", 10000m, 2, "str-0-159" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 160, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-160@empire.org", "STR-0-160", "N/A", false, false, null, 2, null, null, "404-942-0-160", "Storm Trooper", 10000m, 2, "str-0-160" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 161, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-161@empire.org", "STR-0-161", "N/A", false, false, null, 2, null, null, "404-942-0-161", "Storm Trooper", 10000m, 2, "str-0-161" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 162, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-162@empire.org", "STR-0-162", "N/A", false, false, null, 2, null, null, "404-942-0-162", "Storm Trooper", 10000m, 2, "str-0-162" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 163, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-163@empire.org", "STR-0-163", "N/A", false, false, null, 2, null, null, "404-942-0-163", "Storm Trooper", 10000m, 2, "str-0-163" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 164, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-164@empire.org", "STR-0-164", "N/A", false, false, null, 2, null, null, "404-942-0-164", "Storm Trooper", 10000m, 2, "str-0-164" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 165, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-165@empire.org", "STR-0-165", "N/A", false, false, null, 2, null, null, "404-942-0-165", "Storm Trooper", 10000m, 2, "str-0-165" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 166, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-166@empire.org", "STR-0-166", "N/A", false, false, null, 2, null, null, "404-942-0-166", "Storm Trooper", 10000m, 2, "str-0-166" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 167, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-167@empire.org", "STR-0-167", "N/A", false, false, null, 2, null, null, "404-942-0-167", "Storm Trooper", 10000m, 2, "str-0-167" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 168, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-168@empire.org", "STR-0-168", "N/A", false, false, null, 2, null, null, "404-942-0-168", "Storm Trooper", 10000m, 2, "str-0-168" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 169, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-169@empire.org", "STR-0-169", "N/A", false, false, null, 2, null, null, "404-942-0-169", "Storm Trooper", 10000m, 2, "str-0-169" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 170, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-170@empire.org", "STR-0-170", "N/A", false, false, null, 2, null, null, "404-942-0-170", "Storm Trooper", 10000m, 2, "str-0-170" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 171, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-171@empire.org", "STR-0-171", "N/A", false, false, null, 2, null, null, "404-942-0-171", "Storm Trooper", 10000m, 2, "str-0-171" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 172, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-172@empire.org", "STR-0-172", "N/A", false, false, null, 2, null, null, "404-942-0-172", "Storm Trooper", 10000m, 2, "str-0-172" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 173, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-173@empire.org", "STR-0-173", "N/A", false, false, null, 2, null, null, "404-942-0-173", "Storm Trooper", 10000m, 2, "str-0-173" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 174, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-174@empire.org", "STR-0-174", "N/A", false, false, null, 2, null, null, "404-942-0-174", "Storm Trooper", 10000m, 2, "str-0-174" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 175, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-175@empire.org", "STR-0-175", "N/A", false, false, null, 2, null, null, "404-942-0-175", "Storm Trooper", 10000m, 2, "str-0-175" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 176, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-176@empire.org", "STR-0-176", "N/A", false, false, null, 2, null, null, "404-942-0-176", "Storm Trooper", 10000m, 2, "str-0-176" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 177, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-177@empire.org", "STR-0-177", "N/A", false, false, null, 2, null, null, "404-942-0-177", "Storm Trooper", 10000m, 2, "str-0-177" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 178, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-178@empire.org", "STR-0-178", "N/A", false, false, null, 2, null, null, "404-942-0-178", "Storm Trooper", 10000m, 2, "str-0-178" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 179, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-179@empire.org", "STR-0-179", "N/A", false, false, null, 2, null, null, "404-942-0-179", "Storm Trooper", 10000m, 2, "str-0-179" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 180, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-180@empire.org", "STR-0-180", "N/A", false, false, null, 2, null, null, "404-942-0-180", "Storm Trooper", 10000m, 2, "str-0-180" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 181, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-181@empire.org", "STR-0-181", "N/A", false, false, null, 2, null, null, "404-942-0-181", "Storm Trooper", 10000m, 2, "str-0-181" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 182, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-182@empire.org", "STR-0-182", "N/A", false, false, null, 2, null, null, "404-942-0-182", "Storm Trooper", 10000m, 2, "str-0-182" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 183, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-183@empire.org", "STR-0-183", "N/A", false, false, null, 2, null, null, "404-942-0-183", "Storm Trooper", 10000m, 2, "str-0-183" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 184, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-184@empire.org", "STR-0-184", "N/A", false, false, null, 2, null, null, "404-942-0-184", "Storm Trooper", 10000m, 2, "str-0-184" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 157, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-157@empire.org", "STR-0-157", "N/A", false, false, null, 2, null, null, "404-942-0-157", "Storm Trooper", 10000m, 2, "str-0-157" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 185, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-185@empire.org", "STR-0-185", "N/A", false, false, null, 2, null, null, "404-942-0-185", "Storm Trooper", 10000m, 2, "str-0-185" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 156, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-156@empire.org", "STR-0-156", "N/A", false, false, null, 2, null, null, "404-942-0-156", "Storm Trooper", 10000m, 2, "str-0-156" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 154, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-154@empire.org", "STR-0-154", "N/A", false, false, null, 2, null, null, "404-942-0-154", "Storm Trooper", 10000m, 2, "str-0-154" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 127, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-127@empire.org", "STR-0-127", "N/A", false, false, null, 2, null, null, "404-942-0-127", "Storm Trooper", 10000m, 2, "str-0-127" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 128, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-128@empire.org", "STR-0-128", "N/A", false, false, null, 2, null, null, "404-942-0-128", "Storm Trooper", 10000m, 2, "str-0-128" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 129, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-129@empire.org", "STR-0-129", "N/A", false, false, null, 2, null, null, "404-942-0-129", "Storm Trooper", 10000m, 2, "str-0-129" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 130, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-130@empire.org", "STR-0-130", "N/A", false, false, null, 2, null, null, "404-942-0-130", "Storm Trooper", 10000m, 2, "str-0-130" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 131, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-131@empire.org", "STR-0-131", "N/A", false, false, null, 2, null, null, "404-942-0-131", "Storm Trooper", 10000m, 2, "str-0-131" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 132, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-132@empire.org", "STR-0-132", "N/A", false, false, null, 2, null, null, "404-942-0-132", "Storm Trooper", 10000m, 2, "str-0-132" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 133, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-133@empire.org", "STR-0-133", "N/A", false, false, null, 2, null, null, "404-942-0-133", "Storm Trooper", 10000m, 2, "str-0-133" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 134, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-134@empire.org", "STR-0-134", "N/A", false, false, null, 2, null, null, "404-942-0-134", "Storm Trooper", 10000m, 2, "str-0-134" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 135, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-135@empire.org", "STR-0-135", "N/A", false, false, null, 2, null, null, "404-942-0-135", "Storm Trooper", 10000m, 2, "str-0-135" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 136, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-136@empire.org", "STR-0-136", "N/A", false, false, null, 2, null, null, "404-942-0-136", "Storm Trooper", 10000m, 2, "str-0-136" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 137, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-137@empire.org", "STR-0-137", "N/A", false, false, null, 2, null, null, "404-942-0-137", "Storm Trooper", 10000m, 2, "str-0-137" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 138, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-138@empire.org", "STR-0-138", "N/A", false, false, null, 2, null, null, "404-942-0-138", "Storm Trooper", 10000m, 2, "str-0-138" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 139, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-139@empire.org", "STR-0-139", "N/A", false, false, null, 2, null, null, "404-942-0-139", "Storm Trooper", 10000m, 2, "str-0-139" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 140, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-140@empire.org", "STR-0-140", "N/A", false, false, null, 2, null, null, "404-942-0-140", "Storm Trooper", 10000m, 2, "str-0-140" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 141, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-141@empire.org", "STR-0-141", "N/A", false, false, null, 2, null, null, "404-942-0-141", "Storm Trooper", 10000m, 2, "str-0-141" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 142, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-142@empire.org", "STR-0-142", "N/A", false, false, null, 2, null, null, "404-942-0-142", "Storm Trooper", 10000m, 2, "str-0-142" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 143, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-143@empire.org", "STR-0-143", "N/A", false, false, null, 2, null, null, "404-942-0-143", "Storm Trooper", 10000m, 2, "str-0-143" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 144, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-144@empire.org", "STR-0-144", "N/A", false, false, null, 2, null, null, "404-942-0-144", "Storm Trooper", 10000m, 2, "str-0-144" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 145, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-145@empire.org", "STR-0-145", "N/A", false, false, null, 2, null, null, "404-942-0-145", "Storm Trooper", 10000m, 2, "str-0-145" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 146, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-146@empire.org", "STR-0-146", "N/A", false, false, null, 2, null, null, "404-942-0-146", "Storm Trooper", 10000m, 2, "str-0-146" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 147, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-147@empire.org", "STR-0-147", "N/A", false, false, null, 2, null, null, "404-942-0-147", "Storm Trooper", 10000m, 2, "str-0-147" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 148, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-148@empire.org", "STR-0-148", "N/A", false, false, null, 2, null, null, "404-942-0-148", "Storm Trooper", 10000m, 2, "str-0-148" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 149, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-149@empire.org", "STR-0-149", "N/A", false, false, null, 2, null, null, "404-942-0-149", "Storm Trooper", 10000m, 2, "str-0-149" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 150, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-150@empire.org", "STR-0-150", "N/A", false, false, null, 2, null, null, "404-942-0-150", "Storm Trooper", 10000m, 2, "str-0-150" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 151, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-151@empire.org", "STR-0-151", "N/A", false, false, null, 2, null, null, "404-942-0-151", "Storm Trooper", 10000m, 2, "str-0-151" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 152, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-152@empire.org", "STR-0-152", "N/A", false, false, null, 2, null, null, "404-942-0-152", "Storm Trooper", 10000m, 2, "str-0-152" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 153, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-153@empire.org", "STR-0-153", "N/A", false, false, null, 2, null, null, "404-942-0-153", "Storm Trooper", 10000m, 2, "str-0-153" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 155, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-155@empire.org", "STR-0-155", "N/A", false, false, null, 2, null, null, "404-942-0-155", "Storm Trooper", 10000m, 2, "str-0-155" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 186, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-186@empire.org", "STR-0-186", "N/A", false, false, null, 2, null, null, "404-942-0-186", "Storm Trooper", 10000m, 2, "str-0-186" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 187, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-187@empire.org", "STR-0-187", "N/A", false, false, null, 2, null, null, "404-942-0-187", "Storm Trooper", 10000m, 2, "str-0-187" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 188, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-188@empire.org", "STR-0-188", "N/A", false, false, null, 2, null, null, "404-942-0-188", "Storm Trooper", 10000m, 2, "str-0-188" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 221, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-021@empire.org", "STR-1-021", "N/A", false, false, null, 2, null, null, "404-942-1-021", "Storm Trooper", 7800.00m, 1, "str-1-021" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 222, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-022@empire.org", "STR-1-022", "N/A", false, false, null, 2, null, null, "404-942-1-022", "Storm Trooper", 7800.00m, 1, "str-1-022" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 223, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-023@empire.org", "STR-1-023", "N/A", false, false, null, 2, null, null, "404-942-1-023", "Storm Trooper", 7800.00m, 1, "str-1-023" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 224, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-024@empire.org", "STR-1-024", "N/A", false, false, null, 2, null, null, "404-942-1-024", "Storm Trooper", 7800.00m, 1, "str-1-024" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 225, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-025@empire.org", "STR-1-025", "N/A", false, false, null, 2, null, null, "404-942-1-025", "Storm Trooper", 7800.00m, 1, "str-1-025" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 226, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-026@empire.org", "STR-1-026", "N/A", false, false, null, 2, null, null, "404-942-1-026", "Storm Trooper", 7800.00m, 1, "str-1-026" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 227, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-027@empire.org", "STR-1-027", "N/A", false, false, null, 2, null, null, "404-942-1-027", "Storm Trooper", 7800.00m, 1, "str-1-027" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 228, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-028@empire.org", "STR-1-028", "N/A", false, false, null, 2, null, null, "404-942-1-028", "Storm Trooper", 7800.00m, 1, "str-1-028" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 229, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-029@empire.org", "STR-1-029", "N/A", false, false, null, 2, null, null, "404-942-1-029", "Storm Trooper", 7800.00m, 1, "str-1-029" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 230, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-030@empire.org", "STR-1-030", "N/A", false, false, null, 3, null, null, "404-942-1-030", "Storm Trooper", 7800.00m, 1, "str-1-030" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 231, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-031@empire.org", "STR-1-031", "N/A", false, false, null, 3, null, null, "404-942-1-031", "Storm Trooper", 7800.00m, 1, "str-1-031" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 232, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-032@empire.org", "STR-1-032", "N/A", false, false, null, 3, null, null, "404-942-1-032", "Storm Trooper", 7800.00m, 1, "str-1-032" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 233, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-033@empire.org", "STR-1-033", "N/A", false, false, null, 3, null, null, "404-942-1-033", "Storm Trooper", 7800.00m, 1, "str-1-033" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 234, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-034@empire.org", "STR-1-034", "N/A", false, false, null, 3, null, null, "404-942-1-034", "Storm Trooper", 7800.00m, 1, "str-1-034" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 235, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-035@empire.org", "STR-1-035", "N/A", false, false, null, 3, null, null, "404-942-1-035", "Storm Trooper", 7800.00m, 1, "str-1-035" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 236, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-036@empire.org", "STR-1-036", "N/A", false, false, null, 3, null, null, "404-942-1-036", "Storm Trooper", 7800.00m, 1, "str-1-036" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 237, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-037@empire.org", "STR-1-037", "N/A", false, false, null, 3, null, null, "404-942-1-037", "Storm Trooper", 7800.00m, 1, "str-1-037" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 238, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-038@empire.org", "STR-1-038", "N/A", false, false, null, 3, null, null, "404-942-1-038", "Storm Trooper", 7800.00m, 1, "str-1-038" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 239, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-039@empire.org", "STR-1-039", "N/A", false, false, null, 3, null, null, "404-942-1-039", "Storm Trooper", 7800.00m, 1, "str-1-039" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 240, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-040@empire.org", "STR-1-040", "N/A", false, false, null, 3, null, null, "404-942-1-040", "Storm Trooper", 7800.00m, 1, "str-1-040" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 241, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-041@empire.org", "STR-1-041", "N/A", false, false, null, 3, null, null, "404-942-1-041", "Storm Trooper", 7800.00m, 1, "str-1-041" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 242, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-042@empire.org", "STR-1-042", "N/A", false, false, null, 3, null, null, "404-942-1-042", "Storm Trooper", 7800.00m, 1, "str-1-042" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 243, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-043@empire.org", "STR-1-043", "N/A", false, false, null, 3, null, null, "404-942-1-043", "Storm Trooper", 7800.00m, 1, "str-1-043" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 244, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-044@empire.org", "STR-1-044", "N/A", false, false, null, 3, null, null, "404-942-1-044", "Storm Trooper", 7800.00m, 1, "str-1-044" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 245, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-045@empire.org", "STR-1-045", "N/A", false, false, null, 3, null, null, "404-942-1-045", "Storm Trooper", 7800.00m, 1, "str-1-045" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 246, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-046@empire.org", "STR-1-046", "N/A", false, false, null, 3, null, null, "404-942-1-046", "Storm Trooper", 7800.00m, 1, "str-1-046" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 247, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-047@empire.org", "STR-1-047", "N/A", false, false, null, 3, null, null, "404-942-1-047", "Storm Trooper", 7800.00m, 1, "str-1-047" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 220, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-020@empire.org", "STR-1-020", "N/A", false, false, null, 2, null, null, "404-942-1-020", "Storm Trooper", 7800.00m, 1, "str-1-020" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 219, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-019@empire.org", "STR-1-019", "N/A", false, false, null, 2, null, null, "404-942-1-019", "Storm Trooper", 7800.00m, 1, "str-1-019" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 218, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-018@empire.org", "STR-1-018", "N/A", false, false, null, 2, null, null, "404-942-1-018", "Storm Trooper", 7800.00m, 1, "str-1-018" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 217, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-017@empire.org", "STR-1-017", "N/A", false, false, null, 2, null, null, "404-942-1-017", "Storm Trooper", 7800.00m, 1, "str-1-017" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 189, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-189@empire.org", "STR-0-189", "N/A", false, false, null, 2, null, null, "404-942-0-189", "Storm Trooper", 10000m, 2, "str-0-189" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 190, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-190@empire.org", "STR-0-190", "N/A", false, false, null, 2, null, null, "404-942-0-190", "Storm Trooper", 10000m, 2, "str-0-190" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 191, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-191@empire.org", "STR-0-191", "N/A", false, false, null, 2, null, null, "404-942-0-191", "Storm Trooper", 10000m, 2, "str-0-191" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 192, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-192@empire.org", "STR-0-192", "N/A", false, false, null, 2, null, null, "404-942-0-192", "Storm Trooper", 10000m, 2, "str-0-192" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 193, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-193@empire.org", "STR-0-193", "N/A", false, false, null, 2, null, null, "404-942-0-193", "Storm Trooper", 10000m, 2, "str-0-193" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 194, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-194@empire.org", "STR-0-194", "N/A", false, false, null, 2, null, null, "404-942-0-194", "Storm Trooper", 10000m, 2, "str-0-194" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 195, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-195@empire.org", "STR-0-195", "N/A", false, false, null, 2, null, null, "404-942-0-195", "Storm Trooper", 10000m, 2, "str-0-195" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 196, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-196@empire.org", "STR-0-196", "N/A", false, false, null, 2, null, null, "404-942-0-196", "Storm Trooper", 10000m, 2, "str-0-196" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 197, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-197@empire.org", "STR-0-197", "N/A", false, false, null, 2, null, null, "404-942-0-197", "Storm Trooper", 10000m, 2, "str-0-197" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 198, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-198@empire.org", "STR-0-198", "N/A", false, false, null, 2, null, null, "404-942-0-198", "Storm Trooper", 10000m, 2, "str-0-198" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 199, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-199@empire.org", "STR-0-199", "N/A", false, false, null, 2, null, null, "404-942-0-199", "Storm Trooper", 10000m, 2, "str-0-199" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 200, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-1100@empire.org", "STR-0-1100", "N/A", false, false, null, 2, null, null, "404-942-0-1100", "Storm Trooper", 10000m, 2, "str-0-1100" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 201, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-01@empire.org", "STR-1-01", "N/A", false, false, null, 2, null, null, "404-942-1-01", "Storm Trooper", 7800.00m, 1, "str-1-01" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 126, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-126@empire.org", "STR-0-126", "N/A", false, false, null, 2, null, null, "404-942-0-126", "Storm Trooper", 10000m, 2, "str-0-126" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 202, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-02@empire.org", "STR-1-02", "N/A", false, false, null, 2, null, null, "404-942-1-02", "Storm Trooper", 7800.00m, 1, "str-1-02" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 204, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-04@empire.org", "STR-1-04", "N/A", false, false, null, 2, null, null, "404-942-1-04", "Storm Trooper", 7800.00m, 1, "str-1-04" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 205, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-05@empire.org", "STR-1-05", "N/A", false, false, null, 2, null, null, "404-942-1-05", "Storm Trooper", 7800.00m, 1, "str-1-05" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 206, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-06@empire.org", "STR-1-06", "N/A", false, false, null, 2, null, null, "404-942-1-06", "Storm Trooper", 7800.00m, 1, "str-1-06" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 207, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-07@empire.org", "STR-1-07", "N/A", false, false, null, 2, null, null, "404-942-1-07", "Storm Trooper", 7800.00m, 1, "str-1-07" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 208, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-08@empire.org", "STR-1-08", "N/A", false, false, null, 2, null, null, "404-942-1-08", "Storm Trooper", 7800.00m, 1, "str-1-08" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 209, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-09@empire.org", "STR-1-09", "N/A", false, false, null, 2, null, null, "404-942-1-09", "Storm Trooper", 7800.00m, 1, "str-1-09" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 210, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-010@empire.org", "STR-1-010", "N/A", false, false, null, 2, null, null, "404-942-1-010", "Storm Trooper", 7800.00m, 1, "str-1-010" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 211, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-011@empire.org", "STR-1-011", "N/A", false, false, null, 2, null, null, "404-942-1-011", "Storm Trooper", 7800.00m, 1, "str-1-011" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 212, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-012@empire.org", "STR-1-012", "N/A", false, false, null, 2, null, null, "404-942-1-012", "Storm Trooper", 7800.00m, 1, "str-1-012" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 213, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-013@empire.org", "STR-1-013", "N/A", false, false, null, 2, null, null, "404-942-1-013", "Storm Trooper", 7800.00m, 1, "str-1-013" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 214, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-014@empire.org", "STR-1-014", "N/A", false, false, null, 2, null, null, "404-942-1-014", "Storm Trooper", 7800.00m, 1, "str-1-014" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 215, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-015@empire.org", "STR-1-015", "N/A", false, false, null, 2, null, null, "404-942-1-015", "Storm Trooper", 7800.00m, 1, "str-1-015" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 216, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-016@empire.org", "STR-1-016", "N/A", false, false, null, 2, null, null, "404-942-1-016", "Storm Trooper", 7800.00m, 1, "str-1-016" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 203, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-03@empire.org", "STR-1-03", "N/A", false, false, null, 2, null, null, "404-942-1-03", "Storm Trooper", 7800.00m, 1, "str-1-03" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 125, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-125@empire.org", "STR-0-125", "N/A", false, false, null, 2, null, null, "404-942-0-125", "Storm Trooper", 10000m, 2, "str-0-125" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 124, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-124@empire.org", "STR-0-124", "N/A", false, false, null, 2, null, null, "404-942-0-124", "Storm Trooper", 10000m, 2, "str-0-124" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 123, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-123@empire.org", "STR-0-123", "N/A", false, false, null, 2, null, null, "404-942-0-123", "Storm Trooper", 10000m, 2, "str-0-123" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 34, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-034@empire.org", "STR-0-034", "N/A", false, false, null, 1, null, null, "404-942-0-034", "Storm Trooper", 7800.00m, 1, "str-0-034" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 35, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-035@empire.org", "STR-0-035", "N/A", false, false, null, 1, null, null, "404-942-0-035", "Storm Trooper", 7800.00m, 1, "str-0-035" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 36, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-036@empire.org", "STR-0-036", "N/A", false, false, null, 1, null, null, "404-942-0-036", "Storm Trooper", 7800.00m, 1, "str-0-036" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 37, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-037@empire.org", "STR-0-037", "N/A", false, false, null, 1, null, null, "404-942-0-037", "Storm Trooper", 7800.00m, 1, "str-0-037" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 38, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-038@empire.org", "STR-0-038", "N/A", false, false, null, 1, null, null, "404-942-0-038", "Storm Trooper", 7800.00m, 1, "str-0-038" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 39, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-039@empire.org", "STR-0-039", "N/A", false, false, null, 1, null, null, "404-942-0-039", "Storm Trooper", 7800.00m, 1, "str-0-039" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 40, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-040@empire.org", "STR-0-040", "N/A", false, false, null, 1, null, null, "404-942-0-040", "Storm Trooper", 7800.00m, 1, "str-0-040" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 41, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-041@empire.org", "STR-0-041", "N/A", false, false, null, 1, null, null, "404-942-0-041", "Storm Trooper", 7800.00m, 1, "str-0-041" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 42, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-042@empire.org", "STR-0-042", "N/A", false, false, null, 1, null, null, "404-942-0-042", "Storm Trooper", 7800.00m, 1, "str-0-042" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 43, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-043@empire.org", "STR-0-043", "N/A", false, false, null, 1, null, null, "404-942-0-043", "Storm Trooper", 7800.00m, 1, "str-0-043" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 44, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-044@empire.org", "STR-0-044", "N/A", false, false, null, 1, null, null, "404-942-0-044", "Storm Trooper", 7800.00m, 1, "str-0-044" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 45, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-045@empire.org", "STR-0-045", "N/A", false, false, null, 1, null, null, "404-942-0-045", "Storm Trooper", 7800.00m, 1, "str-0-045" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 46, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-046@empire.org", "STR-0-046", "N/A", false, false, null, 1, null, null, "404-942-0-046", "Storm Trooper", 7800.00m, 1, "str-0-046" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 47, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-047@empire.org", "STR-0-047", "N/A", false, false, null, 1, null, null, "404-942-0-047", "Storm Trooper", 7800.00m, 1, "str-0-047" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 48, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-048@empire.org", "STR-0-048", "N/A", false, false, null, 1, null, null, "404-942-0-048", "Storm Trooper", 7800.00m, 1, "str-0-048" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 49, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-049@empire.org", "STR-0-049", "N/A", false, false, null, 1, null, null, "404-942-0-049", "Storm Trooper", 7800.00m, 1, "str-0-049" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 50, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-050@empire.org", "STR-0-050", "N/A", false, false, null, 1, null, null, "404-942-0-050", "Storm Trooper", 7800.00m, 1, "str-0-050" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 51, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-051@empire.org", "STR-0-051", "N/A", false, false, null, 1, null, null, "404-942-0-051", "Storm Trooper", 7800.00m, 1, "str-0-051" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 52, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-052@empire.org", "STR-0-052", "N/A", false, false, null, 1, null, null, "404-942-0-052", "Storm Trooper", 7800.00m, 1, "str-0-052" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 53, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-053@empire.org", "STR-0-053", "N/A", false, false, null, 1, null, null, "404-942-0-053", "Storm Trooper", 7800.00m, 1, "str-0-053" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 54, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-054@empire.org", "STR-0-054", "N/A", false, false, null, 1, null, null, "404-942-0-054", "Storm Trooper", 7800.00m, 1, "str-0-054" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 55, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-055@empire.org", "STR-0-055", "N/A", false, false, null, 1, null, null, "404-942-0-055", "Storm Trooper", 7800.00m, 1, "str-0-055" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 56, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-056@empire.org", "STR-0-056", "N/A", false, false, null, 1, null, null, "404-942-0-056", "Storm Trooper", 7800.00m, 1, "str-0-056" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 57, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-057@empire.org", "STR-0-057", "N/A", false, false, null, 1, null, null, "404-942-0-057", "Storm Trooper", 7800.00m, 1, "str-0-057" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 58, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-058@empire.org", "STR-0-058", "N/A", false, false, null, 1, null, null, "404-942-0-058", "Storm Trooper", 7800.00m, 1, "str-0-058" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 59, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-059@empire.org", "STR-0-059", "N/A", false, false, null, 1, null, null, "404-942-0-059", "Storm Trooper", 7800.00m, 1, "str-0-059" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 60, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-060@empire.org", "STR-0-060", "N/A", false, false, null, 1, null, null, "404-942-0-060", "Storm Trooper", 7800.00m, 1, "str-0-060" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 33, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-033@empire.org", "STR-0-033", "N/A", false, false, null, 1, null, null, "404-942-0-033", "Storm Trooper", 7800.00m, 1, "str-0-033" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 32, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-032@empire.org", "STR-0-032", "N/A", false, false, null, 1, null, null, "404-942-0-032", "Storm Trooper", 7800.00m, 1, "str-0-032" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 31, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-031@empire.org", "STR-0-031", "N/A", false, false, null, 1, null, null, "404-942-0-031", "Storm Trooper", 7800.00m, 1, "str-0-031" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 30, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-030@empire.org", "STR-0-030", "N/A", false, false, null, 1, null, null, "404-942-0-030", "Storm Trooper", 7800.00m, 1, "str-0-030" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 2, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-02@empire.org", "STR-0-02", "N/A", false, false, null, 1, null, null, "404-942-0-02", "Storm Trooper", 7800.00m, 1, "str-0-02" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 3, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-03@empire.org", "STR-0-03", "N/A", false, false, null, 1, null, null, "404-942-0-03", "Storm Trooper", 7800.00m, 1, "str-0-03" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 4, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-04@empire.org", "STR-0-04", "N/A", false, false, null, 1, null, null, "404-942-0-04", "Storm Trooper", 7800.00m, 1, "str-0-04" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 5, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-05@empire.org", "STR-0-05", "N/A", false, false, null, 1, null, null, "404-942-0-05", "Storm Trooper", 7800.00m, 1, "str-0-05" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 6, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-06@empire.org", "STR-0-06", "N/A", false, false, null, 1, null, null, "404-942-0-06", "Storm Trooper", 7800.00m, 1, "str-0-06" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 7, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-07@empire.org", "STR-0-07", "N/A", false, false, null, 1, null, null, "404-942-0-07", "Storm Trooper", 7800.00m, 1, "str-0-07" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 8, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-08@empire.org", "STR-0-08", "N/A", false, false, null, 1, null, null, "404-942-0-08", "Storm Trooper", 7800.00m, 1, "str-0-08" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 9, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-09@empire.org", "STR-0-09", "N/A", false, false, null, 1, null, null, "404-942-0-09", "Storm Trooper", 7800.00m, 1, "str-0-09" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 10, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-010@empire.org", "STR-0-010", "N/A", false, false, null, 1, null, null, "404-942-0-010", "Storm Trooper", 7800.00m, 1, "str-0-010" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 11, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-011@empire.org", "STR-0-011", "N/A", false, false, null, 1, null, null, "404-942-0-011", "Storm Trooper", 7800.00m, 1, "str-0-011" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 12, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-012@empire.org", "STR-0-012", "N/A", false, false, null, 1, null, null, "404-942-0-012", "Storm Trooper", 7800.00m, 1, "str-0-012" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 13, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-013@empire.org", "STR-0-013", "N/A", false, false, null, 1, null, null, "404-942-0-013", "Storm Trooper", 7800.00m, 1, "str-0-013" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 14, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-014@empire.org", "STR-0-014", "N/A", false, false, null, 1, null, null, "404-942-0-014", "Storm Trooper", 7800.00m, 1, "str-0-014" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 61, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-061@empire.org", "STR-0-061", "N/A", false, false, null, 1, null, null, "404-942-0-061", "Storm Trooper", 7800.00m, 1, "str-0-061" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 15, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-015@empire.org", "STR-0-015", "N/A", false, false, null, 1, null, null, "404-942-0-015", "Storm Trooper", 7800.00m, 1, "str-0-015" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 17, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-017@empire.org", "STR-0-017", "N/A", false, false, null, 1, null, null, "404-942-0-017", "Storm Trooper", 7800.00m, 1, "str-0-017" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 18, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-018@empire.org", "STR-0-018", "N/A", false, false, null, 1, null, null, "404-942-0-018", "Storm Trooper", 7800.00m, 1, "str-0-018" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 19, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-019@empire.org", "STR-0-019", "N/A", false, false, null, 1, null, null, "404-942-0-019", "Storm Trooper", 7800.00m, 1, "str-0-019" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 20, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-020@empire.org", "STR-0-020", "N/A", false, false, null, 1, null, null, "404-942-0-020", "Storm Trooper", 7800.00m, 1, "str-0-020" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 21, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-021@empire.org", "STR-0-021", "N/A", false, false, null, 1, null, null, "404-942-0-021", "Storm Trooper", 7800.00m, 1, "str-0-021" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 22, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-022@empire.org", "STR-0-022", "N/A", false, false, null, 1, null, null, "404-942-0-022", "Storm Trooper", 7800.00m, 1, "str-0-022" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 23, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-023@empire.org", "STR-0-023", "N/A", false, false, null, 1, null, null, "404-942-0-023", "Storm Trooper", 7800.00m, 1, "str-0-023" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 24, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-024@empire.org", "STR-0-024", "N/A", false, false, null, 1, null, null, "404-942-0-024", "Storm Trooper", 7800.00m, 1, "str-0-024" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 25, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-025@empire.org", "STR-0-025", "N/A", false, false, null, 1, null, null, "404-942-0-025", "Storm Trooper", 7800.00m, 1, "str-0-025" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 26, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-026@empire.org", "STR-0-026", "N/A", false, false, null, 1, null, null, "404-942-0-026", "Storm Trooper", 7800.00m, 1, "str-0-026" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 27, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-027@empire.org", "STR-0-027", "N/A", false, false, null, 1, null, null, "404-942-0-027", "Storm Trooper", 7800.00m, 1, "str-0-027" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 28, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-028@empire.org", "STR-0-028", "N/A", false, false, null, 1, null, null, "404-942-0-028", "Storm Trooper", 7800.00m, 1, "str-0-028" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 29, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-029@empire.org", "STR-0-029", "N/A", false, false, null, 1, null, null, "404-942-0-029", "Storm Trooper", 7800.00m, 1, "str-0-029" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 16, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-016@empire.org", "STR-0-016", "N/A", false, false, null, 1, null, null, "404-942-0-016", "Storm Trooper", 7800.00m, 1, "str-0-016" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 248, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-048@empire.org", "STR-1-048", "N/A", false, false, null, 3, null, null, "404-942-1-048", "Storm Trooper", 7800.00m, 1, "str-1-048" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 62, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-062@empire.org", "STR-0-062", "N/A", false, false, null, 1, null, null, "404-942-0-062", "Storm Trooper", 7800.00m, 1, "str-0-062" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 64, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-064@empire.org", "STR-0-064", "N/A", false, false, null, 1, null, null, "404-942-0-064", "Storm Trooper", 7800.00m, 1, "str-0-064" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 96, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-096@empire.org", "STR-0-096", "N/A", false, false, null, 2, null, null, "404-942-0-096", "Storm Trooper", 7800.00m, 1, "str-0-096" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 97, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-097@empire.org", "STR-0-097", "N/A", false, false, null, 2, null, null, "404-942-0-097", "Storm Trooper", 7800.00m, 1, "str-0-097" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 98, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-098@empire.org", "STR-0-098", "N/A", false, false, null, 2, null, null, "404-942-0-098", "Storm Trooper", 7800.00m, 1, "str-0-098" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 99, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-099@empire.org", "STR-0-099", "N/A", false, false, null, 2, null, null, "404-942-0-099", "Storm Trooper", 7800.00m, 1, "str-0-099" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 100, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-0100@empire.org", "STR-0-0100", "N/A", false, false, null, 2, null, null, "404-942-0-0100", "Storm Trooper", 7800.00m, 1, "str-0-0100" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 101, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-11@empire.org", "STR-0-11", "N/A", false, false, null, 2, null, null, "404-942-0-11", "Storm Trooper", 10000m, 2, "str-0-11" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 102, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-12@empire.org", "STR-0-12", "N/A", false, false, null, 2, null, null, "404-942-0-12", "Storm Trooper", 10000m, 2, "str-0-12" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 103, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-13@empire.org", "STR-0-13", "N/A", false, false, null, 2, null, null, "404-942-0-13", "Storm Trooper", 10000m, 2, "str-0-13" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 104, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-14@empire.org", "STR-0-14", "N/A", false, false, null, 2, null, null, "404-942-0-14", "Storm Trooper", 10000m, 2, "str-0-14" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 105, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-15@empire.org", "STR-0-15", "N/A", false, false, null, 2, null, null, "404-942-0-15", "Storm Trooper", 10000m, 2, "str-0-15" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 106, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-16@empire.org", "STR-0-16", "N/A", false, false, null, 2, null, null, "404-942-0-16", "Storm Trooper", 10000m, 2, "str-0-16" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 107, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-17@empire.org", "STR-0-17", "N/A", false, false, null, 2, null, null, "404-942-0-17", "Storm Trooper", 10000m, 2, "str-0-17" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 108, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-18@empire.org", "STR-0-18", "N/A", false, false, null, 2, null, null, "404-942-0-18", "Storm Trooper", 10000m, 2, "str-0-18" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 109, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-19@empire.org", "STR-0-19", "N/A", false, false, null, 2, null, null, "404-942-0-19", "Storm Trooper", 10000m, 2, "str-0-19" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 110, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-110@empire.org", "STR-0-110", "N/A", false, false, null, 2, null, null, "404-942-0-110", "Storm Trooper", 10000m, 2, "str-0-110" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 111, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-111@empire.org", "STR-0-111", "N/A", false, false, null, 2, null, null, "404-942-0-111", "Storm Trooper", 10000m, 2, "str-0-111" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 112, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-112@empire.org", "STR-0-112", "N/A", false, false, null, 2, null, null, "404-942-0-112", "Storm Trooper", 10000m, 2, "str-0-112" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 113, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-113@empire.org", "STR-0-113", "N/A", false, false, null, 2, null, null, "404-942-0-113", "Storm Trooper", 10000m, 2, "str-0-113" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 114, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-114@empire.org", "STR-0-114", "N/A", false, false, null, 2, null, null, "404-942-0-114", "Storm Trooper", 10000m, 2, "str-0-114" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 115, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-115@empire.org", "STR-0-115", "N/A", false, false, null, 2, null, null, "404-942-0-115", "Storm Trooper", 10000m, 2, "str-0-115" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 116, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-116@empire.org", "STR-0-116", "N/A", false, false, null, 2, null, null, "404-942-0-116", "Storm Trooper", 10000m, 2, "str-0-116" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 117, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-117@empire.org", "STR-0-117", "N/A", false, false, null, 2, null, null, "404-942-0-117", "Storm Trooper", 10000m, 2, "str-0-117" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 118, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-118@empire.org", "STR-0-118", "N/A", false, false, null, 2, null, null, "404-942-0-118", "Storm Trooper", 10000m, 2, "str-0-118" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 119, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-119@empire.org", "STR-0-119", "N/A", false, false, null, 2, null, null, "404-942-0-119", "Storm Trooper", 10000m, 2, "str-0-119" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 120, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-120@empire.org", "STR-0-120", "N/A", false, false, null, 2, null, null, "404-942-0-120", "Storm Trooper", 10000m, 2, "str-0-120" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 121, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-121@empire.org", "STR-0-121", "N/A", false, false, null, 2, null, null, "404-942-0-121", "Storm Trooper", 10000m, 2, "str-0-121" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 122, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-122@empire.org", "STR-0-122", "N/A", false, false, null, 2, null, null, "404-942-0-122", "Storm Trooper", 10000m, 2, "str-0-122" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 95, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-095@empire.org", "STR-0-095", "N/A", false, false, null, 2, null, null, "404-942-0-095", "Storm Trooper", 7800.00m, 1, "str-0-095" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 94, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-094@empire.org", "STR-0-094", "N/A", false, false, null, 2, null, null, "404-942-0-094", "Storm Trooper", 7800.00m, 1, "str-0-094" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 93, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-093@empire.org", "STR-0-093", "N/A", false, false, null, 2, null, null, "404-942-0-093", "Storm Trooper", 7800.00m, 1, "str-0-093" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 92, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-092@empire.org", "STR-0-092", "N/A", false, false, null, 2, null, null, "404-942-0-092", "Storm Trooper", 7800.00m, 1, "str-0-092" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 65, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-065@empire.org", "STR-0-065", "N/A", false, false, null, 1, null, null, "404-942-0-065", "Storm Trooper", 7800.00m, 1, "str-0-065" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 66, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-066@empire.org", "STR-0-066", "N/A", false, false, null, 1, null, null, "404-942-0-066", "Storm Trooper", 7800.00m, 1, "str-0-066" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 67, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-067@empire.org", "STR-0-067", "N/A", false, false, null, 1, null, null, "404-942-0-067", "Storm Trooper", 7800.00m, 1, "str-0-067" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 68, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-068@empire.org", "STR-0-068", "N/A", false, false, null, 1, null, null, "404-942-0-068", "Storm Trooper", 7800.00m, 1, "str-0-068" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 69, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-069@empire.org", "STR-0-069", "N/A", false, false, null, 1, null, null, "404-942-0-069", "Storm Trooper", 7800.00m, 1, "str-0-069" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 70, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-070@empire.org", "STR-0-070", "N/A", false, false, null, 1, null, null, "404-942-0-070", "Storm Trooper", 7800.00m, 1, "str-0-070" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 71, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-071@empire.org", "STR-0-071", "N/A", false, false, null, 1, null, null, "404-942-0-071", "Storm Trooper", 7800.00m, 1, "str-0-071" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 72, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-072@empire.org", "STR-0-072", "N/A", false, false, null, 1, null, null, "404-942-0-072", "Storm Trooper", 7800.00m, 1, "str-0-072" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 73, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-073@empire.org", "STR-0-073", "N/A", false, false, null, 1, null, null, "404-942-0-073", "Storm Trooper", 7800.00m, 1, "str-0-073" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 74, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-074@empire.org", "STR-0-074", "N/A", false, false, null, 1, null, null, "404-942-0-074", "Storm Trooper", 7800.00m, 1, "str-0-074" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 75, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-075@empire.org", "STR-0-075", "N/A", false, false, null, 1, null, null, "404-942-0-075", "Storm Trooper", 7800.00m, 1, "str-0-075" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 76, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-076@empire.org", "STR-0-076", "N/A", false, false, null, 1, null, null, "404-942-0-076", "Storm Trooper", 7800.00m, 1, "str-0-076" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 1002, "", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1927, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "emperor-sidious@empire.org", "Sheev", "Male", false, false, "Palpatine", 1, "Darth Sidious", null, "404-1", "Emperor", 10000000m, 2, "emperor-sidious" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 63, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-063@empire.org", "STR-0-063", "N/A", false, false, null, 1, null, null, "404-942-0-063", "Storm Trooper", 7800.00m, 1, "str-0-063" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 77, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-077@empire.org", "STR-0-077", "N/A", false, false, null, 2, null, null, "404-942-0-077", "Storm Trooper", 7800.00m, 1, "str-0-077" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 79, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-079@empire.org", "STR-0-079", "N/A", false, false, null, 2, null, null, "404-942-0-079", "Storm Trooper", 7800.00m, 1, "str-0-079" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 80, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-080@empire.org", "STR-0-080", "N/A", false, false, null, 2, null, null, "404-942-0-080", "Storm Trooper", 7800.00m, 1, "str-0-080" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 81, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-081@empire.org", "STR-0-081", "N/A", false, false, null, 2, null, null, "404-942-0-081", "Storm Trooper", 7800.00m, 1, "str-0-081" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 82, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-082@empire.org", "STR-0-082", "N/A", false, false, null, 2, null, null, "404-942-0-082", "Storm Trooper", 7800.00m, 1, "str-0-082" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 83, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-083@empire.org", "STR-0-083", "N/A", false, false, null, 2, null, null, "404-942-0-083", "Storm Trooper", 7800.00m, 1, "str-0-083" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 84, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-084@empire.org", "STR-0-084", "N/A", false, false, null, 2, null, null, "404-942-0-084", "Storm Trooper", 7800.00m, 1, "str-0-084" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 85, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-085@empire.org", "STR-0-085", "N/A", false, false, null, 2, null, null, "404-942-0-085", "Storm Trooper", 7800.00m, 1, "str-0-085" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 86, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-086@empire.org", "STR-0-086", "N/A", false, false, null, 2, null, null, "404-942-0-086", "Storm Trooper", 7800.00m, 1, "str-0-086" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 87, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-087@empire.org", "STR-0-087", "N/A", false, false, null, 2, null, null, "404-942-0-087", "Storm Trooper", 7800.00m, 1, "str-0-087" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 88, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-088@empire.org", "STR-0-088", "N/A", false, false, null, 2, null, null, "404-942-0-088", "Storm Trooper", 7800.00m, 1, "str-0-088" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 89, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-089@empire.org", "STR-0-089", "N/A", false, false, null, 2, null, null, "404-942-0-089", "Storm Trooper", 7800.00m, 1, "str-0-089" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 90, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-090@empire.org", "STR-0-090", "N/A", false, false, null, 2, null, null, "404-942-0-090", "Storm Trooper", 7800.00m, 1, "str-0-090" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 91, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-091@empire.org", "STR-0-091", "N/A", false, false, null, 2, null, null, "404-942-0-091", "Storm Trooper", 7800.00m, 1, "str-0-091" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 78, "Mentally indoctrinated and ready to serve.", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-0-078@empire.org", "STR-0-078", "N/A", false, false, null, 2, null, null, "404-942-0-078", "Storm Trooper", 7800.00m, 1, "str-0-078" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 999, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-199@empire.org", "STR-4-199", "N/A", false, false, null, 6, null, null, "404-942-4-199", "Storm Trooper", 10000m, 2, "str-4-199" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 249, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-049@empire.org", "STR-1-049", "N/A", false, false, null, 3, null, null, "404-942-1-049", "Storm Trooper", 7800.00m, 1, "str-1-049" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 251, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-051@empire.org", "STR-1-051", "N/A", false, false, null, 3, null, null, "404-942-1-051", "Storm Trooper", 7800.00m, 1, "str-1-051" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 409, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-09@empire.org", "STR-2-09", "N/A", false, false, null, 4, null, null, "404-942-2-09", "Storm Trooper", 7800.00m, 1, "str-2-09" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 410, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-010@empire.org", "STR-2-010", "N/A", false, false, null, 4, null, null, "404-942-2-010", "Storm Trooper", 7800.00m, 1, "str-2-010" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 411, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-011@empire.org", "STR-2-011", "N/A", false, false, null, 4, null, null, "404-942-2-011", "Storm Trooper", 7800.00m, 1, "str-2-011" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 412, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-012@empire.org", "STR-2-012", "N/A", false, false, null, 4, null, null, "404-942-2-012", "Storm Trooper", 7800.00m, 1, "str-2-012" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 413, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-013@empire.org", "STR-2-013", "N/A", false, false, null, 4, null, null, "404-942-2-013", "Storm Trooper", 7800.00m, 1, "str-2-013" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 414, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-014@empire.org", "STR-2-014", "N/A", false, false, null, 4, null, null, "404-942-2-014", "Storm Trooper", 7800.00m, 1, "str-2-014" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 415, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-015@empire.org", "STR-2-015", "N/A", false, false, null, 4, null, null, "404-942-2-015", "Storm Trooper", 7800.00m, 1, "str-2-015" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 416, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-016@empire.org", "STR-2-016", "N/A", false, false, null, 4, null, null, "404-942-2-016", "Storm Trooper", 7800.00m, 1, "str-2-016" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 417, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-017@empire.org", "STR-2-017", "N/A", false, false, null, 4, null, null, "404-942-2-017", "Storm Trooper", 7800.00m, 1, "str-2-017" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 418, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-018@empire.org", "STR-2-018", "N/A", false, false, null, 4, null, null, "404-942-2-018", "Storm Trooper", 7800.00m, 1, "str-2-018" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 419, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-019@empire.org", "STR-2-019", "N/A", false, false, null, 4, null, null, "404-942-2-019", "Storm Trooper", 7800.00m, 1, "str-2-019" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 420, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-020@empire.org", "STR-2-020", "N/A", false, false, null, 4, null, null, "404-942-2-020", "Storm Trooper", 7800.00m, 1, "str-2-020" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 421, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-021@empire.org", "STR-2-021", "N/A", false, false, null, 4, null, null, "404-942-2-021", "Storm Trooper", 7800.00m, 1, "str-2-021" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 422, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-022@empire.org", "STR-2-022", "N/A", false, false, null, 4, null, null, "404-942-2-022", "Storm Trooper", 7800.00m, 1, "str-2-022" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 423, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-023@empire.org", "STR-2-023", "N/A", false, false, null, 4, null, null, "404-942-2-023", "Storm Trooper", 7800.00m, 1, "str-2-023" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 424, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-024@empire.org", "STR-2-024", "N/A", false, false, null, 4, null, null, "404-942-2-024", "Storm Trooper", 7800.00m, 1, "str-2-024" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 425, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-025@empire.org", "STR-2-025", "N/A", false, false, null, 4, null, null, "404-942-2-025", "Storm Trooper", 7800.00m, 1, "str-2-025" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 426, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-026@empire.org", "STR-2-026", "N/A", false, false, null, 4, null, null, "404-942-2-026", "Storm Trooper", 7800.00m, 1, "str-2-026" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 427, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-027@empire.org", "STR-2-027", "N/A", false, false, null, 4, null, null, "404-942-2-027", "Storm Trooper", 7800.00m, 1, "str-2-027" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 428, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-028@empire.org", "STR-2-028", "N/A", false, false, null, 4, null, null, "404-942-2-028", "Storm Trooper", 7800.00m, 1, "str-2-028" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 429, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-029@empire.org", "STR-2-029", "N/A", false, false, null, 4, null, null, "404-942-2-029", "Storm Trooper", 7800.00m, 1, "str-2-029" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 430, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-030@empire.org", "STR-2-030", "N/A", false, false, null, 4, null, null, "404-942-2-030", "Storm Trooper", 7800.00m, 1, "str-2-030" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 431, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-031@empire.org", "STR-2-031", "N/A", false, false, null, 4, null, null, "404-942-2-031", "Storm Trooper", 7800.00m, 1, "str-2-031" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 432, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-032@empire.org", "STR-2-032", "N/A", false, false, null, 4, null, null, "404-942-2-032", "Storm Trooper", 7800.00m, 1, "str-2-032" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 433, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-033@empire.org", "STR-2-033", "N/A", false, false, null, 4, null, null, "404-942-2-033", "Storm Trooper", 7800.00m, 1, "str-2-033" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 434, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-034@empire.org", "STR-2-034", "N/A", false, false, null, 4, null, null, "404-942-2-034", "Storm Trooper", 7800.00m, 1, "str-2-034" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 435, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-035@empire.org", "STR-2-035", "N/A", false, false, null, 4, null, null, "404-942-2-035", "Storm Trooper", 7800.00m, 1, "str-2-035" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 408, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-08@empire.org", "STR-2-08", "N/A", false, false, null, 4, null, null, "404-942-2-08", "Storm Trooper", 7800.00m, 1, "str-2-08" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 436, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-036@empire.org", "STR-2-036", "N/A", false, false, null, 4, null, null, "404-942-2-036", "Storm Trooper", 7800.00m, 1, "str-2-036" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 407, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-07@empire.org", "STR-2-07", "N/A", false, false, null, 4, null, null, "404-942-2-07", "Storm Trooper", 7800.00m, 1, "str-2-07" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 405, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-05@empire.org", "STR-2-05", "N/A", false, false, null, 4, null, null, "404-942-2-05", "Storm Trooper", 7800.00m, 1, "str-2-05" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 378, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-178@empire.org", "STR-1-178", "N/A", false, false, null, 4, null, null, "404-942-1-178", "Storm Trooper", 10000m, 2, "str-1-178" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 379, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-179@empire.org", "STR-1-179", "N/A", false, false, null, 4, null, null, "404-942-1-179", "Storm Trooper", 10000m, 2, "str-1-179" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 380, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-180@empire.org", "STR-1-180", "N/A", false, false, null, 4, null, null, "404-942-1-180", "Storm Trooper", 10000m, 2, "str-1-180" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 381, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-181@empire.org", "STR-1-181", "N/A", false, false, null, 4, null, null, "404-942-1-181", "Storm Trooper", 10000m, 2, "str-1-181" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 382, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-182@empire.org", "STR-1-182", "N/A", false, false, null, 4, null, null, "404-942-1-182", "Storm Trooper", 10000m, 2, "str-1-182" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 383, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-183@empire.org", "STR-1-183", "N/A", false, false, null, 4, null, null, "404-942-1-183", "Storm Trooper", 10000m, 2, "str-1-183" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 384, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-184@empire.org", "STR-1-184", "N/A", false, false, null, 4, null, null, "404-942-1-184", "Storm Trooper", 10000m, 2, "str-1-184" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 385, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-185@empire.org", "STR-1-185", "N/A", false, false, null, 4, null, null, "404-942-1-185", "Storm Trooper", 10000m, 2, "str-1-185" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 386, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-186@empire.org", "STR-1-186", "N/A", false, false, null, 4, null, null, "404-942-1-186", "Storm Trooper", 10000m, 2, "str-1-186" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 387, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-187@empire.org", "STR-1-187", "N/A", false, false, null, 4, null, null, "404-942-1-187", "Storm Trooper", 10000m, 2, "str-1-187" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 388, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-188@empire.org", "STR-1-188", "N/A", false, false, null, 4, null, null, "404-942-1-188", "Storm Trooper", 10000m, 2, "str-1-188" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 389, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-189@empire.org", "STR-1-189", "N/A", false, false, null, 4, null, null, "404-942-1-189", "Storm Trooper", 10000m, 2, "str-1-189" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 390, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-190@empire.org", "STR-1-190", "N/A", false, false, null, 4, null, null, "404-942-1-190", "Storm Trooper", 10000m, 2, "str-1-190" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 391, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-191@empire.org", "STR-1-191", "N/A", false, false, null, 4, null, null, "404-942-1-191", "Storm Trooper", 10000m, 2, "str-1-191" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 392, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-192@empire.org", "STR-1-192", "N/A", false, false, null, 4, null, null, "404-942-1-192", "Storm Trooper", 10000m, 2, "str-1-192" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 393, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-193@empire.org", "STR-1-193", "N/A", false, false, null, 4, null, null, "404-942-1-193", "Storm Trooper", 10000m, 2, "str-1-193" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 394, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-194@empire.org", "STR-1-194", "N/A", false, false, null, 4, null, null, "404-942-1-194", "Storm Trooper", 10000m, 2, "str-1-194" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 395, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-195@empire.org", "STR-1-195", "N/A", false, false, null, 4, null, null, "404-942-1-195", "Storm Trooper", 10000m, 2, "str-1-195" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 396, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-196@empire.org", "STR-1-196", "N/A", false, false, null, 4, null, null, "404-942-1-196", "Storm Trooper", 10000m, 2, "str-1-196" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 397, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-197@empire.org", "STR-1-197", "N/A", false, false, null, 4, null, null, "404-942-1-197", "Storm Trooper", 10000m, 2, "str-1-197" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 398, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-198@empire.org", "STR-1-198", "N/A", false, false, null, 4, null, null, "404-942-1-198", "Storm Trooper", 10000m, 2, "str-1-198" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 399, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-199@empire.org", "STR-1-199", "N/A", false, false, null, 4, null, null, "404-942-1-199", "Storm Trooper", 10000m, 2, "str-1-199" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 400, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-1100@empire.org", "STR-1-1100", "N/A", false, false, null, 4, null, null, "404-942-1-1100", "Storm Trooper", 10000m, 2, "str-1-1100" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 401, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-01@empire.org", "STR-2-01", "N/A", false, false, null, 4, null, null, "404-942-2-01", "Storm Trooper", 7800.00m, 1, "str-2-01" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 402, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-02@empire.org", "STR-2-02", "N/A", false, false, null, 4, null, null, "404-942-2-02", "Storm Trooper", 7800.00m, 1, "str-2-02" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 403, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-03@empire.org", "STR-2-03", "N/A", false, false, null, 4, null, null, "404-942-2-03", "Storm Trooper", 7800.00m, 1, "str-2-03" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 404, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-04@empire.org", "STR-2-04", "N/A", false, false, null, 4, null, null, "404-942-2-04", "Storm Trooper", 7800.00m, 1, "str-2-04" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 406, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-06@empire.org", "STR-2-06", "N/A", false, false, null, 4, null, null, "404-942-2-06", "Storm Trooper", 7800.00m, 1, "str-2-06" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 437, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-037@empire.org", "STR-2-037", "N/A", false, false, null, 4, null, null, "404-942-2-037", "Storm Trooper", 7800.00m, 1, "str-2-037" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 438, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-038@empire.org", "STR-2-038", "N/A", false, false, null, 4, null, null, "404-942-2-038", "Storm Trooper", 7800.00m, 1, "str-2-038" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 439, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-039@empire.org", "STR-2-039", "N/A", false, false, null, 4, null, null, "404-942-2-039", "Storm Trooper", 7800.00m, 1, "str-2-039" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 471, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-071@empire.org", "STR-2-071", "N/A", false, false, null, 5, null, null, "404-942-2-071", "Storm Trooper", 7800.00m, 1, "str-2-071" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 472, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-072@empire.org", "STR-2-072", "N/A", false, false, null, 5, null, null, "404-942-2-072", "Storm Trooper", 7800.00m, 1, "str-2-072" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 473, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-073@empire.org", "STR-2-073", "N/A", false, false, null, 5, null, null, "404-942-2-073", "Storm Trooper", 7800.00m, 1, "str-2-073" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 474, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-074@empire.org", "STR-2-074", "N/A", false, false, null, 5, null, null, "404-942-2-074", "Storm Trooper", 7800.00m, 1, "str-2-074" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 475, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-075@empire.org", "STR-2-075", "N/A", false, false, null, 5, null, null, "404-942-2-075", "Storm Trooper", 7800.00m, 1, "str-2-075" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 476, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-076@empire.org", "STR-2-076", "N/A", false, false, null, 5, null, null, "404-942-2-076", "Storm Trooper", 7800.00m, 1, "str-2-076" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 477, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-077@empire.org", "STR-2-077", "N/A", false, false, null, 5, null, null, "404-942-2-077", "Storm Trooper", 7800.00m, 1, "str-2-077" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 478, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-078@empire.org", "STR-2-078", "N/A", false, false, null, 5, null, null, "404-942-2-078", "Storm Trooper", 7800.00m, 1, "str-2-078" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 479, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-079@empire.org", "STR-2-079", "N/A", false, false, null, 5, null, null, "404-942-2-079", "Storm Trooper", 7800.00m, 1, "str-2-079" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 480, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-080@empire.org", "STR-2-080", "N/A", false, false, null, 5, null, null, "404-942-2-080", "Storm Trooper", 7800.00m, 1, "str-2-080" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 481, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-081@empire.org", "STR-2-081", "N/A", false, false, null, 5, null, null, "404-942-2-081", "Storm Trooper", 7800.00m, 1, "str-2-081" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 482, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-082@empire.org", "STR-2-082", "N/A", false, false, null, 5, null, null, "404-942-2-082", "Storm Trooper", 7800.00m, 1, "str-2-082" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 483, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-083@empire.org", "STR-2-083", "N/A", false, false, null, 5, null, null, "404-942-2-083", "Storm Trooper", 7800.00m, 1, "str-2-083" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 484, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-084@empire.org", "STR-2-084", "N/A", false, false, null, 5, null, null, "404-942-2-084", "Storm Trooper", 7800.00m, 1, "str-2-084" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 485, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-085@empire.org", "STR-2-085", "N/A", false, false, null, 5, null, null, "404-942-2-085", "Storm Trooper", 7800.00m, 1, "str-2-085" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 486, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-086@empire.org", "STR-2-086", "N/A", false, false, null, 5, null, null, "404-942-2-086", "Storm Trooper", 7800.00m, 1, "str-2-086" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 487, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-087@empire.org", "STR-2-087", "N/A", false, false, null, 5, null, null, "404-942-2-087", "Storm Trooper", 7800.00m, 1, "str-2-087" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 488, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-088@empire.org", "STR-2-088", "N/A", false, false, null, 5, null, null, "404-942-2-088", "Storm Trooper", 7800.00m, 1, "str-2-088" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 489, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-089@empire.org", "STR-2-089", "N/A", false, false, null, 5, null, null, "404-942-2-089", "Storm Trooper", 7800.00m, 1, "str-2-089" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 490, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-090@empire.org", "STR-2-090", "N/A", false, false, null, 5, null, null, "404-942-2-090", "Storm Trooper", 7800.00m, 1, "str-2-090" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 491, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-091@empire.org", "STR-2-091", "N/A", false, false, null, 5, null, null, "404-942-2-091", "Storm Trooper", 7800.00m, 1, "str-2-091" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 492, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-092@empire.org", "STR-2-092", "N/A", false, false, null, 5, null, null, "404-942-2-092", "Storm Trooper", 7800.00m, 1, "str-2-092" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 493, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-093@empire.org", "STR-2-093", "N/A", false, false, null, 5, null, null, "404-942-2-093", "Storm Trooper", 7800.00m, 1, "str-2-093" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 494, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-094@empire.org", "STR-2-094", "N/A", false, false, null, 5, null, null, "404-942-2-094", "Storm Trooper", 7800.00m, 1, "str-2-094" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 495, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-095@empire.org", "STR-2-095", "N/A", false, false, null, 5, null, null, "404-942-2-095", "Storm Trooper", 7800.00m, 1, "str-2-095" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 496, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-096@empire.org", "STR-2-096", "N/A", false, false, null, 5, null, null, "404-942-2-096", "Storm Trooper", 7800.00m, 1, "str-2-096" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 497, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-097@empire.org", "STR-2-097", "N/A", false, false, null, 5, null, null, "404-942-2-097", "Storm Trooper", 7800.00m, 1, "str-2-097" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 470, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-070@empire.org", "STR-2-070", "N/A", false, false, null, 5, null, null, "404-942-2-070", "Storm Trooper", 7800.00m, 1, "str-2-070" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 469, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-069@empire.org", "STR-2-069", "N/A", false, false, null, 5, null, null, "404-942-2-069", "Storm Trooper", 7800.00m, 1, "str-2-069" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 468, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-068@empire.org", "STR-2-068", "N/A", false, false, null, 5, null, null, "404-942-2-068", "Storm Trooper", 7800.00m, 1, "str-2-068" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 467, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-067@empire.org", "STR-2-067", "N/A", false, false, null, 5, null, null, "404-942-2-067", "Storm Trooper", 7800.00m, 1, "str-2-067" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 440, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-040@empire.org", "STR-2-040", "N/A", false, false, null, 4, null, null, "404-942-2-040", "Storm Trooper", 7800.00m, 1, "str-2-040" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 441, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-041@empire.org", "STR-2-041", "N/A", false, false, null, 4, null, null, "404-942-2-041", "Storm Trooper", 7800.00m, 1, "str-2-041" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 442, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-042@empire.org", "STR-2-042", "N/A", false, false, null, 4, null, null, "404-942-2-042", "Storm Trooper", 7800.00m, 1, "str-2-042" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 443, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-043@empire.org", "STR-2-043", "N/A", false, false, null, 4, null, null, "404-942-2-043", "Storm Trooper", 7800.00m, 1, "str-2-043" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 444, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-044@empire.org", "STR-2-044", "N/A", false, false, null, 4, null, null, "404-942-2-044", "Storm Trooper", 7800.00m, 1, "str-2-044" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 445, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-045@empire.org", "STR-2-045", "N/A", false, false, null, 4, null, null, "404-942-2-045", "Storm Trooper", 7800.00m, 1, "str-2-045" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 446, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-046@empire.org", "STR-2-046", "N/A", false, false, null, 4, null, null, "404-942-2-046", "Storm Trooper", 7800.00m, 1, "str-2-046" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 447, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-047@empire.org", "STR-2-047", "N/A", false, false, null, 4, null, null, "404-942-2-047", "Storm Trooper", 7800.00m, 1, "str-2-047" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 448, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-048@empire.org", "STR-2-048", "N/A", false, false, null, 4, null, null, "404-942-2-048", "Storm Trooper", 7800.00m, 1, "str-2-048" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 449, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-049@empire.org", "STR-2-049", "N/A", false, false, null, 4, null, null, "404-942-2-049", "Storm Trooper", 7800.00m, 1, "str-2-049" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 450, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-050@empire.org", "STR-2-050", "N/A", false, false, null, 4, null, null, "404-942-2-050", "Storm Trooper", 7800.00m, 1, "str-2-050" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 451, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-051@empire.org", "STR-2-051", "N/A", false, false, null, 4, null, null, "404-942-2-051", "Storm Trooper", 7800.00m, 1, "str-2-051" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 452, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-052@empire.org", "STR-2-052", "N/A", false, false, null, 4, null, null, "404-942-2-052", "Storm Trooper", 7800.00m, 1, "str-2-052" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 377, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-177@empire.org", "STR-1-177", "N/A", false, false, null, 4, null, null, "404-942-1-177", "Storm Trooper", 10000m, 2, "str-1-177" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 453, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-053@empire.org", "STR-2-053", "N/A", false, false, null, 4, null, null, "404-942-2-053", "Storm Trooper", 7800.00m, 1, "str-2-053" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 455, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-055@empire.org", "STR-2-055", "N/A", false, false, null, 4, null, null, "404-942-2-055", "Storm Trooper", 7800.00m, 1, "str-2-055" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 456, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-056@empire.org", "STR-2-056", "N/A", false, false, null, 4, null, null, "404-942-2-056", "Storm Trooper", 7800.00m, 1, "str-2-056" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 457, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-057@empire.org", "STR-2-057", "N/A", false, false, null, 4, null, null, "404-942-2-057", "Storm Trooper", 7800.00m, 1, "str-2-057" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 458, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-058@empire.org", "STR-2-058", "N/A", false, false, null, 4, null, null, "404-942-2-058", "Storm Trooper", 7800.00m, 1, "str-2-058" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 1001, "Who's your daddy?", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1947, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "lord-vader@empire.org", "Anakin", "Male", true, false, "Skywalker", 4, "Darth Vader", null, "404-2", "Dark Lord", 500000m, 2, "lord-vader" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 459, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-059@empire.org", "STR-2-059", "N/A", false, false, null, 5, null, null, "404-942-2-059", "Storm Trooper", 7800.00m, 1, "str-2-059" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 460, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-060@empire.org", "STR-2-060", "N/A", false, false, null, 5, null, null, "404-942-2-060", "Storm Trooper", 7800.00m, 1, "str-2-060" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 461, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-061@empire.org", "STR-2-061", "N/A", false, false, null, 5, null, null, "404-942-2-061", "Storm Trooper", 7800.00m, 1, "str-2-061" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 462, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-062@empire.org", "STR-2-062", "N/A", false, false, null, 5, null, null, "404-942-2-062", "Storm Trooper", 7800.00m, 1, "str-2-062" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 463, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-063@empire.org", "STR-2-063", "N/A", false, false, null, 5, null, null, "404-942-2-063", "Storm Trooper", 7800.00m, 1, "str-2-063" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 464, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-064@empire.org", "STR-2-064", "N/A", false, false, null, 5, null, null, "404-942-2-064", "Storm Trooper", 7800.00m, 1, "str-2-064" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 465, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-065@empire.org", "STR-2-065", "N/A", false, false, null, 5, null, null, "404-942-2-065", "Storm Trooper", 7800.00m, 1, "str-2-065" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 466, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-066@empire.org", "STR-2-066", "N/A", false, false, null, 5, null, null, "404-942-2-066", "Storm Trooper", 7800.00m, 1, "str-2-066" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 454, "Mentally indoctrinated and ready to serve.", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-2-054@empire.org", "STR-2-054", "N/A", false, false, null, 4, null, null, "404-942-2-054", "Storm Trooper", 7800.00m, 1, "str-2-054" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 376, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-176@empire.org", "STR-1-176", "N/A", false, false, null, 4, null, null, "404-942-1-176", "Storm Trooper", 10000m, 2, "str-1-176" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 375, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-175@empire.org", "STR-1-175", "N/A", false, false, null, 4, null, null, "404-942-1-175", "Storm Trooper", 10000m, 2, "str-1-175" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 374, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-174@empire.org", "STR-1-174", "N/A", false, false, null, 4, null, null, "404-942-1-174", "Storm Trooper", 10000m, 2, "str-1-174" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 284, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-084@empire.org", "STR-1-084", "N/A", false, false, null, 3, null, null, "404-942-1-084", "Storm Trooper", 7800.00m, 1, "str-1-084" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 285, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-085@empire.org", "STR-1-085", "N/A", false, false, null, 3, null, null, "404-942-1-085", "Storm Trooper", 7800.00m, 1, "str-1-085" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 286, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-086@empire.org", "STR-1-086", "N/A", false, false, null, 3, null, null, "404-942-1-086", "Storm Trooper", 7800.00m, 1, "str-1-086" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 287, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-087@empire.org", "STR-1-087", "N/A", false, false, null, 3, null, null, "404-942-1-087", "Storm Trooper", 7800.00m, 1, "str-1-087" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 288, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-088@empire.org", "STR-1-088", "N/A", false, false, null, 3, null, null, "404-942-1-088", "Storm Trooper", 7800.00m, 1, "str-1-088" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 289, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-089@empire.org", "STR-1-089", "N/A", false, false, null, 3, null, null, "404-942-1-089", "Storm Trooper", 7800.00m, 1, "str-1-089" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 290, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-090@empire.org", "STR-1-090", "N/A", false, false, null, 3, null, null, "404-942-1-090", "Storm Trooper", 7800.00m, 1, "str-1-090" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 291, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-091@empire.org", "STR-1-091", "N/A", false, false, null, 3, null, null, "404-942-1-091", "Storm Trooper", 7800.00m, 1, "str-1-091" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 292, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-092@empire.org", "STR-1-092", "N/A", false, false, null, 3, null, null, "404-942-1-092", "Storm Trooper", 7800.00m, 1, "str-1-092" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 293, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-093@empire.org", "STR-1-093", "N/A", false, false, null, 3, null, null, "404-942-1-093", "Storm Trooper", 7800.00m, 1, "str-1-093" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 294, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-094@empire.org", "STR-1-094", "N/A", false, false, null, 3, null, null, "404-942-1-094", "Storm Trooper", 7800.00m, 1, "str-1-094" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 295, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-095@empire.org", "STR-1-095", "N/A", false, false, null, 3, null, null, "404-942-1-095", "Storm Trooper", 7800.00m, 1, "str-1-095" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 296, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-096@empire.org", "STR-1-096", "N/A", false, false, null, 3, null, null, "404-942-1-096", "Storm Trooper", 7800.00m, 1, "str-1-096" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 297, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-097@empire.org", "STR-1-097", "N/A", false, false, null, 3, null, null, "404-942-1-097", "Storm Trooper", 7800.00m, 1, "str-1-097" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 298, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-098@empire.org", "STR-1-098", "N/A", false, false, null, 3, null, null, "404-942-1-098", "Storm Trooper", 7800.00m, 1, "str-1-098" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 299, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-099@empire.org", "STR-1-099", "N/A", false, false, null, 3, null, null, "404-942-1-099", "Storm Trooper", 7800.00m, 1, "str-1-099" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 300, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-0100@empire.org", "STR-1-0100", "N/A", false, false, null, 3, null, null, "404-942-1-0100", "Storm Trooper", 7800.00m, 1, "str-1-0100" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 301, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-11@empire.org", "STR-1-11", "N/A", false, false, null, 3, null, null, "404-942-1-11", "Storm Trooper", 10000m, 2, "str-1-11" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 302, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-12@empire.org", "STR-1-12", "N/A", false, false, null, 3, null, null, "404-942-1-12", "Storm Trooper", 10000m, 2, "str-1-12" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 303, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-13@empire.org", "STR-1-13", "N/A", false, false, null, 3, null, null, "404-942-1-13", "Storm Trooper", 10000m, 2, "str-1-13" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 304, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-14@empire.org", "STR-1-14", "N/A", false, false, null, 3, null, null, "404-942-1-14", "Storm Trooper", 10000m, 2, "str-1-14" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 305, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-15@empire.org", "STR-1-15", "N/A", false, false, null, 3, null, null, "404-942-1-15", "Storm Trooper", 10000m, 2, "str-1-15" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 306, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-16@empire.org", "STR-1-16", "N/A", false, false, null, 4, null, null, "404-942-1-16", "Storm Trooper", 10000m, 2, "str-1-16" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 307, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-17@empire.org", "STR-1-17", "N/A", false, false, null, 4, null, null, "404-942-1-17", "Storm Trooper", 10000m, 2, "str-1-17" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 308, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-18@empire.org", "STR-1-18", "N/A", false, false, null, 4, null, null, "404-942-1-18", "Storm Trooper", 10000m, 2, "str-1-18" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 309, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-19@empire.org", "STR-1-19", "N/A", false, false, null, 4, null, null, "404-942-1-19", "Storm Trooper", 10000m, 2, "str-1-19" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 310, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-110@empire.org", "STR-1-110", "N/A", false, false, null, 4, null, null, "404-942-1-110", "Storm Trooper", 10000m, 2, "str-1-110" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 283, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-083@empire.org", "STR-1-083", "N/A", false, false, null, 3, null, null, "404-942-1-083", "Storm Trooper", 7800.00m, 1, "str-1-083" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 282, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-082@empire.org", "STR-1-082", "N/A", false, false, null, 3, null, null, "404-942-1-082", "Storm Trooper", 7800.00m, 1, "str-1-082" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 281, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-081@empire.org", "STR-1-081", "N/A", false, false, null, 3, null, null, "404-942-1-081", "Storm Trooper", 7800.00m, 1, "str-1-081" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 280, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-080@empire.org", "STR-1-080", "N/A", false, false, null, 3, null, null, "404-942-1-080", "Storm Trooper", 7800.00m, 1, "str-1-080" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 252, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-052@empire.org", "STR-1-052", "N/A", false, false, null, 3, null, null, "404-942-1-052", "Storm Trooper", 7800.00m, 1, "str-1-052" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 253, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-053@empire.org", "STR-1-053", "N/A", false, false, null, 3, null, null, "404-942-1-053", "Storm Trooper", 7800.00m, 1, "str-1-053" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 254, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-054@empire.org", "STR-1-054", "N/A", false, false, null, 3, null, null, "404-942-1-054", "Storm Trooper", 7800.00m, 1, "str-1-054" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 255, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-055@empire.org", "STR-1-055", "N/A", false, false, null, 3, null, null, "404-942-1-055", "Storm Trooper", 7800.00m, 1, "str-1-055" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 256, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-056@empire.org", "STR-1-056", "N/A", false, false, null, 3, null, null, "404-942-1-056", "Storm Trooper", 7800.00m, 1, "str-1-056" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 257, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-057@empire.org", "STR-1-057", "N/A", false, false, null, 3, null, null, "404-942-1-057", "Storm Trooper", 7800.00m, 1, "str-1-057" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 258, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-058@empire.org", "STR-1-058", "N/A", false, false, null, 3, null, null, "404-942-1-058", "Storm Trooper", 7800.00m, 1, "str-1-058" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 259, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-059@empire.org", "STR-1-059", "N/A", false, false, null, 3, null, null, "404-942-1-059", "Storm Trooper", 7800.00m, 1, "str-1-059" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 260, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-060@empire.org", "STR-1-060", "N/A", false, false, null, 3, null, null, "404-942-1-060", "Storm Trooper", 7800.00m, 1, "str-1-060" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 261, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-061@empire.org", "STR-1-061", "N/A", false, false, null, 3, null, null, "404-942-1-061", "Storm Trooper", 7800.00m, 1, "str-1-061" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 262, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-062@empire.org", "STR-1-062", "N/A", false, false, null, 3, null, null, "404-942-1-062", "Storm Trooper", 7800.00m, 1, "str-1-062" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 263, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-063@empire.org", "STR-1-063", "N/A", false, false, null, 3, null, null, "404-942-1-063", "Storm Trooper", 7800.00m, 1, "str-1-063" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 264, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-064@empire.org", "STR-1-064", "N/A", false, false, null, 3, null, null, "404-942-1-064", "Storm Trooper", 7800.00m, 1, "str-1-064" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 311, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-111@empire.org", "STR-1-111", "N/A", false, false, null, 4, null, null, "404-942-1-111", "Storm Trooper", 10000m, 2, "str-1-111" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 265, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-065@empire.org", "STR-1-065", "N/A", false, false, null, 3, null, null, "404-942-1-065", "Storm Trooper", 7800.00m, 1, "str-1-065" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 267, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-067@empire.org", "STR-1-067", "N/A", false, false, null, 3, null, null, "404-942-1-067", "Storm Trooper", 7800.00m, 1, "str-1-067" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 268, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-068@empire.org", "STR-1-068", "N/A", false, false, null, 3, null, null, "404-942-1-068", "Storm Trooper", 7800.00m, 1, "str-1-068" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 269, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-069@empire.org", "STR-1-069", "N/A", false, false, null, 3, null, null, "404-942-1-069", "Storm Trooper", 7800.00m, 1, "str-1-069" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 270, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-070@empire.org", "STR-1-070", "N/A", false, false, null, 3, null, null, "404-942-1-070", "Storm Trooper", 7800.00m, 1, "str-1-070" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 271, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-071@empire.org", "STR-1-071", "N/A", false, false, null, 3, null, null, "404-942-1-071", "Storm Trooper", 7800.00m, 1, "str-1-071" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 272, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-072@empire.org", "STR-1-072", "N/A", false, false, null, 3, null, null, "404-942-1-072", "Storm Trooper", 7800.00m, 1, "str-1-072" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 273, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-073@empire.org", "STR-1-073", "N/A", false, false, null, 3, null, null, "404-942-1-073", "Storm Trooper", 7800.00m, 1, "str-1-073" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 274, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-074@empire.org", "STR-1-074", "N/A", false, false, null, 3, null, null, "404-942-1-074", "Storm Trooper", 7800.00m, 1, "str-1-074" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 275, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-075@empire.org", "STR-1-075", "N/A", false, false, null, 3, null, null, "404-942-1-075", "Storm Trooper", 7800.00m, 1, "str-1-075" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 276, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-076@empire.org", "STR-1-076", "N/A", false, false, null, 3, null, null, "404-942-1-076", "Storm Trooper", 7800.00m, 1, "str-1-076" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 277, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-077@empire.org", "STR-1-077", "N/A", false, false, null, 3, null, null, "404-942-1-077", "Storm Trooper", 7800.00m, 1, "str-1-077" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 278, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-078@empire.org", "STR-1-078", "N/A", false, false, null, 3, null, null, "404-942-1-078", "Storm Trooper", 7800.00m, 1, "str-1-078" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 279, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-079@empire.org", "STR-1-079", "N/A", false, false, null, 3, null, null, "404-942-1-079", "Storm Trooper", 7800.00m, 1, "str-1-079" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 266, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-066@empire.org", "STR-1-066", "N/A", false, false, null, 3, null, null, "404-942-1-066", "Storm Trooper", 7800.00m, 1, "str-1-066" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 250, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-050@empire.org", "STR-1-050", "N/A", false, false, null, 3, null, null, "404-942-1-050", "Storm Trooper", 7800.00m, 1, "str-1-050" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 312, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-112@empire.org", "STR-1-112", "N/A", false, false, null, 4, null, null, "404-942-1-112", "Storm Trooper", 10000m, 2, "str-1-112" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 314, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-114@empire.org", "STR-1-114", "N/A", false, false, null, 4, null, null, "404-942-1-114", "Storm Trooper", 10000m, 2, "str-1-114" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 347, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-147@empire.org", "STR-1-147", "N/A", false, false, null, 4, null, null, "404-942-1-147", "Storm Trooper", 10000m, 2, "str-1-147" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 348, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-148@empire.org", "STR-1-148", "N/A", false, false, null, 4, null, null, "404-942-1-148", "Storm Trooper", 10000m, 2, "str-1-148" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 349, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-149@empire.org", "STR-1-149", "N/A", false, false, null, 4, null, null, "404-942-1-149", "Storm Trooper", 10000m, 2, "str-1-149" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 350, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-150@empire.org", "STR-1-150", "N/A", false, false, null, 4, null, null, "404-942-1-150", "Storm Trooper", 10000m, 2, "str-1-150" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 351, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-151@empire.org", "STR-1-151", "N/A", false, false, null, 4, null, null, "404-942-1-151", "Storm Trooper", 10000m, 2, "str-1-151" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 352, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-152@empire.org", "STR-1-152", "N/A", false, false, null, 4, null, null, "404-942-1-152", "Storm Trooper", 10000m, 2, "str-1-152" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 353, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-153@empire.org", "STR-1-153", "N/A", false, false, null, 4, null, null, "404-942-1-153", "Storm Trooper", 10000m, 2, "str-1-153" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 354, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-154@empire.org", "STR-1-154", "N/A", false, false, null, 4, null, null, "404-942-1-154", "Storm Trooper", 10000m, 2, "str-1-154" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 355, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-155@empire.org", "STR-1-155", "N/A", false, false, null, 4, null, null, "404-942-1-155", "Storm Trooper", 10000m, 2, "str-1-155" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 356, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-156@empire.org", "STR-1-156", "N/A", false, false, null, 4, null, null, "404-942-1-156", "Storm Trooper", 10000m, 2, "str-1-156" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 357, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-157@empire.org", "STR-1-157", "N/A", false, false, null, 4, null, null, "404-942-1-157", "Storm Trooper", 10000m, 2, "str-1-157" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 358, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-158@empire.org", "STR-1-158", "N/A", false, false, null, 4, null, null, "404-942-1-158", "Storm Trooper", 10000m, 2, "str-1-158" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 359, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-159@empire.org", "STR-1-159", "N/A", false, false, null, 4, null, null, "404-942-1-159", "Storm Trooper", 10000m, 2, "str-1-159" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 360, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-160@empire.org", "STR-1-160", "N/A", false, false, null, 4, null, null, "404-942-1-160", "Storm Trooper", 10000m, 2, "str-1-160" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 361, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-161@empire.org", "STR-1-161", "N/A", false, false, null, 4, null, null, "404-942-1-161", "Storm Trooper", 10000m, 2, "str-1-161" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 362, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-162@empire.org", "STR-1-162", "N/A", false, false, null, 4, null, null, "404-942-1-162", "Storm Trooper", 10000m, 2, "str-1-162" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 363, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-163@empire.org", "STR-1-163", "N/A", false, false, null, 4, null, null, "404-942-1-163", "Storm Trooper", 10000m, 2, "str-1-163" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 364, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-164@empire.org", "STR-1-164", "N/A", false, false, null, 4, null, null, "404-942-1-164", "Storm Trooper", 10000m, 2, "str-1-164" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 365, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-165@empire.org", "STR-1-165", "N/A", false, false, null, 4, null, null, "404-942-1-165", "Storm Trooper", 10000m, 2, "str-1-165" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 366, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-166@empire.org", "STR-1-166", "N/A", false, false, null, 4, null, null, "404-942-1-166", "Storm Trooper", 10000m, 2, "str-1-166" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 367, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-167@empire.org", "STR-1-167", "N/A", false, false, null, 4, null, null, "404-942-1-167", "Storm Trooper", 10000m, 2, "str-1-167" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 368, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-168@empire.org", "STR-1-168", "N/A", false, false, null, 4, null, null, "404-942-1-168", "Storm Trooper", 10000m, 2, "str-1-168" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 369, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-169@empire.org", "STR-1-169", "N/A", false, false, null, 4, null, null, "404-942-1-169", "Storm Trooper", 10000m, 2, "str-1-169" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 370, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-170@empire.org", "STR-1-170", "N/A", false, false, null, 4, null, null, "404-942-1-170", "Storm Trooper", 10000m, 2, "str-1-170" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 371, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-171@empire.org", "STR-1-171", "N/A", false, false, null, 4, null, null, "404-942-1-171", "Storm Trooper", 10000m, 2, "str-1-171" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 372, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-172@empire.org", "STR-1-172", "N/A", false, false, null, 4, null, null, "404-942-1-172", "Storm Trooper", 10000m, 2, "str-1-172" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 373, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-173@empire.org", "STR-1-173", "N/A", false, false, null, 4, null, null, "404-942-1-173", "Storm Trooper", 10000m, 2, "str-1-173" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 346, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-146@empire.org", "STR-1-146", "N/A", false, false, null, 4, null, null, "404-942-1-146", "Storm Trooper", 10000m, 2, "str-1-146" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 345, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-145@empire.org", "STR-1-145", "N/A", false, false, null, 4, null, null, "404-942-1-145", "Storm Trooper", 10000m, 2, "str-1-145" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 344, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-144@empire.org", "STR-1-144", "N/A", false, false, null, 4, null, null, "404-942-1-144", "Storm Trooper", 10000m, 2, "str-1-144" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 343, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-143@empire.org", "STR-1-143", "N/A", false, false, null, 4, null, null, "404-942-1-143", "Storm Trooper", 10000m, 2, "str-1-143" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 315, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-115@empire.org", "STR-1-115", "N/A", false, false, null, 4, null, null, "404-942-1-115", "Storm Trooper", 10000m, 2, "str-1-115" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 316, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-116@empire.org", "STR-1-116", "N/A", false, false, null, 4, null, null, "404-942-1-116", "Storm Trooper", 10000m, 2, "str-1-116" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 317, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-117@empire.org", "STR-1-117", "N/A", false, false, null, 4, null, null, "404-942-1-117", "Storm Trooper", 10000m, 2, "str-1-117" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 318, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-118@empire.org", "STR-1-118", "N/A", false, false, null, 4, null, null, "404-942-1-118", "Storm Trooper", 10000m, 2, "str-1-118" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 319, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-119@empire.org", "STR-1-119", "N/A", false, false, null, 4, null, null, "404-942-1-119", "Storm Trooper", 10000m, 2, "str-1-119" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 320, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-120@empire.org", "STR-1-120", "N/A", false, false, null, 4, null, null, "404-942-1-120", "Storm Trooper", 10000m, 2, "str-1-120" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 321, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-121@empire.org", "STR-1-121", "N/A", false, false, null, 4, null, null, "404-942-1-121", "Storm Trooper", 10000m, 2, "str-1-121" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 322, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-122@empire.org", "STR-1-122", "N/A", false, false, null, 4, null, null, "404-942-1-122", "Storm Trooper", 10000m, 2, "str-1-122" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 323, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-123@empire.org", "STR-1-123", "N/A", false, false, null, 4, null, null, "404-942-1-123", "Storm Trooper", 10000m, 2, "str-1-123" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 324, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-124@empire.org", "STR-1-124", "N/A", false, false, null, 4, null, null, "404-942-1-124", "Storm Trooper", 10000m, 2, "str-1-124" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 325, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-125@empire.org", "STR-1-125", "N/A", false, false, null, 4, null, null, "404-942-1-125", "Storm Trooper", 10000m, 2, "str-1-125" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 326, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-126@empire.org", "STR-1-126", "N/A", false, false, null, 4, null, null, "404-942-1-126", "Storm Trooper", 10000m, 2, "str-1-126" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 327, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-127@empire.org", "STR-1-127", "N/A", false, false, null, 4, null, null, "404-942-1-127", "Storm Trooper", 10000m, 2, "str-1-127" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 313, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-113@empire.org", "STR-1-113", "N/A", false, false, null, 4, null, null, "404-942-1-113", "Storm Trooper", 10000m, 2, "str-1-113" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 328, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-128@empire.org", "STR-1-128", "N/A", false, false, null, 4, null, null, "404-942-1-128", "Storm Trooper", 10000m, 2, "str-1-128" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 330, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-130@empire.org", "STR-1-130", "N/A", false, false, null, 4, null, null, "404-942-1-130", "Storm Trooper", 10000m, 2, "str-1-130" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 331, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-131@empire.org", "STR-1-131", "N/A", false, false, null, 4, null, null, "404-942-1-131", "Storm Trooper", 10000m, 2, "str-1-131" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 332, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-132@empire.org", "STR-1-132", "N/A", false, false, null, 4, null, null, "404-942-1-132", "Storm Trooper", 10000m, 2, "str-1-132" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 333, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-133@empire.org", "STR-1-133", "N/A", false, false, null, 4, null, null, "404-942-1-133", "Storm Trooper", 10000m, 2, "str-1-133" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 334, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-134@empire.org", "STR-1-134", "N/A", false, false, null, 4, null, null, "404-942-1-134", "Storm Trooper", 10000m, 2, "str-1-134" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 335, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-135@empire.org", "STR-1-135", "N/A", false, false, null, 4, null, null, "404-942-1-135", "Storm Trooper", 10000m, 2, "str-1-135" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 336, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-136@empire.org", "STR-1-136", "N/A", false, false, null, 4, null, null, "404-942-1-136", "Storm Trooper", 10000m, 2, "str-1-136" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 337, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-137@empire.org", "STR-1-137", "N/A", false, false, null, 4, null, null, "404-942-1-137", "Storm Trooper", 10000m, 2, "str-1-137" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 338, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-138@empire.org", "STR-1-138", "N/A", false, false, null, 4, null, null, "404-942-1-138", "Storm Trooper", 10000m, 2, "str-1-138" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 339, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-139@empire.org", "STR-1-139", "N/A", false, false, null, 4, null, null, "404-942-1-139", "Storm Trooper", 10000m, 2, "str-1-139" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 340, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-140@empire.org", "STR-1-140", "N/A", false, false, null, 4, null, null, "404-942-1-140", "Storm Trooper", 10000m, 2, "str-1-140" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 341, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-141@empire.org", "STR-1-141", "N/A", false, false, null, 4, null, null, "404-942-1-141", "Storm Trooper", 10000m, 2, "str-1-141" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 342, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-142@empire.org", "STR-1-142", "N/A", false, false, null, 4, null, null, "404-942-1-142", "Storm Trooper", 10000m, 2, "str-1-142" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 329, "Mentally indoctrinated and ready to serve.", new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-1-129@empire.org", "STR-1-129", "N/A", false, false, null, 4, null, null, "404-942-1-129", "Storm Trooper", 10000m, 2, "str-1-129" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Comment", "Created", "DateOfBirth", "DateOfEmployment", "Email", "FirstName", "Gender", "HasChildren", "IsMarried", "LastName", "LocationId", "MiddleInitial", "Patronymic", "PhoneNumber", "Position", "SalaryInUSD", "Sex", "Skype" },
                values: new object[] { 1000, "Mentally indoctrinated and ready to serve.", new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "str-4-1100@empire.org", "STR-4-1100", "N/A", false, false, null, 6, null, null, "404-942-4-1100", "Storm Trooper", 10000m, 2, "str-4-1100" });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_LocationId",
                table: "Employees",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_CompanyId",
                table: "Locations",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropSequence(
                name: "CompaniesSequence");

            migrationBuilder.DropSequence(
                name: "EmployeesSequence");

            migrationBuilder.DropSequence(
                name: "LocationsSequence");
        }
    }
}
