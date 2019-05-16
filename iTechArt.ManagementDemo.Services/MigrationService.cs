using iTechArt.ManagementDemo.DataAccess.Interfaces;
using iTechArt.ManagementDemo.Services.Interfaces;
using System;

namespace iTechArt.ManagementDemo.Services
{
    internal class MigrationService : IMigrationService
    {
        private readonly IMigrationHandler _migrationHandler;


        public MigrationService(IMigrationHandler migrationHandler)
        {
            _migrationHandler = migrationHandler
                ?? throw new NullReferenceException();
        }


        public void ApplyMigrations() =>
            _migrationHandler.ApplyMigrationsToDatabase();
    }
}
