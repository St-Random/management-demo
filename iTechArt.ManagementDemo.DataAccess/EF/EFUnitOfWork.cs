using iTechArt.ManagementDemo.DataAccess.EF.Infrastructure;
using iTechArt.ManagementDemo.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace iTechArt.ManagementDemo.DataAccess.EF
{
    internal class EFUnitOfWork : IUnitOfWork, IDbContextProvider
    {
        private readonly DbContext _context;

        public EFUnitOfWork(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException();
        }

        public DbContext GetDbContext() => _context;

        public ITransaction BeginTransaction() => 
            new EFTransaction(_context.Database.BeginTransaction());

        public async Task<ITransaction> BeginTransactionAsync(
            CancellationToken ct = default(CancellationToken)) =>
            new EFTransaction(
                await _context.Database.BeginTransactionAsync(ct));

        public ITransaction BeginTransaction(IsolationLevel isolationLevel) =>
            new EFTransaction(
                _context.Database.BeginTransaction(isolationLevel));

        public async Task<ITransaction> BeginTransactionAsync(
            IsolationLevel isolationLevel = default(IsolationLevel),
            CancellationToken ct = default(CancellationToken)) =>
            new EFTransaction(
                await _context.Database.BeginTransactionAsync(
                    isolationLevel, ct));

        public void SaveChanges()
        {
            ValidateModel();
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            ValidateModel();
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            // I'll actually try to use pooling
            // _context.Dispose();
        }

        private void ValidateModel()
        {
            var changedEntities =
                _context
                    .ChangeTracker
                    .Entries()
                    .Where(e =>
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified)
                    .Select(e => e.Entity);

            // Will throw exception if something is invalid
            foreach (var entity in changedEntities)
            {
                Validator.ValidateObject(
                    entity, new ValidationContext(entity), true);
            }
        }
    }
}
