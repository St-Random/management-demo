using iTechArt.ManagementDemo.DataAccess.EF.Infrastructure.Configuration;
using iTechArt.ManagementDemo.Entities.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace iTechArt.ManagementDemo.DataAccess.EF.Infrastructure.Extensions
{
    public static class ModelBuilderExtensions
    {
        // Sort of hack to set up start index for HiLo
        internal static ModelBuilder ApplyEntityConfigurationWithSequence<TEntity>(
            this ModelBuilder modelBuilder,
            ManagementDemoEntityConfiguration<TEntity> configuration,
            int startValue,
            int increment)
            where TEntity : Entity
        {
            modelBuilder
                .HasSequence<int>(configuration.SequenceName)
                .StartsAt(startValue)
                .IncrementsBy(increment);

            return modelBuilder
                .ApplyConfiguration(configuration);
        }
    }
}
