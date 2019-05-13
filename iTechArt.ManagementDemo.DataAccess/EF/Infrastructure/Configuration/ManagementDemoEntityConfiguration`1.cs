using iTechArt.ManagementDemo.Entities.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iTechArt.ManagementDemo.DataAccess.EF.Infrastructure.Configuration
{
    internal abstract class ManagementDemoEntityConfiguration<TEntity>
        : IEntityTypeConfiguration<TEntity> where TEntity : Entity
    {
        protected const string DateTimeUtcNowSqlValue = "sysutcdatetime()";
        protected abstract string TableName { get; }
        public string SequenceName => $"{TableName}Sequence";

        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.ToTable(TableName);

            ConfigureEntityProperties(builder);
            ConfigureType(builder);
            SeedData(builder);
        }

        protected virtual void ConfigureType(
            EntityTypeBuilder<TEntity> builder)
        {
        }

        protected virtual void SeedData(
            EntityTypeBuilder<TEntity> builder)
        {
        }

        private void ConfigureEntityProperties(
            EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .ForSqlServerUseSequenceHiLo(SequenceName);

            builder.Property(e => e.Created)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql(DateTimeUtcNowSqlValue);

            builder.Property(e => e.LastUpdated)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql(DateTimeUtcNowSqlValue);
        }
    }
}
