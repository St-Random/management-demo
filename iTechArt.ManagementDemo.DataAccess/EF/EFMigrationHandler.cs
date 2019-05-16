using iTechArt.ManagementDemo.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace iTechArt.ManagementDemo.DataAccess.EF
{
    public class EFMigrationHandler : IMigrationHandler
    {
        private readonly DbContext _context;


        public EFMigrationHandler(DbContext context)
        {
            _context = context;
        }


        public void ApplyMigrationsToDatabase() =>
            _context.Database.Migrate();

        public async Task ApplyMigrationsToDatabaseAsync() =>
            await _context.Database.MigrateAsync();
    }
}
