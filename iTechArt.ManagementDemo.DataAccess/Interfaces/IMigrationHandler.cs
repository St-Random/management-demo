using System.Threading.Tasks;

namespace iTechArt.ManagementDemo.DataAccess.Interfaces
{
    public interface IMigrationHandler
    {
        void ApplyMigrationsToDatabase();

        Task ApplyMigrationsToDatabaseAsync();
    }
}
