using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace iTechArt.ManagementDemo.DataAccess.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ITransaction BeginTransaction();
        Task<ITransaction> BeginTransactionAsync(
            CancellationToken ct = default(CancellationToken));

        ITransaction BeginTransaction(IsolationLevel isolationLevel);
        Task<ITransaction> BeginTransactionAsync(
            IsolationLevel isolationLevel,
            CancellationToken ct = default(CancellationToken));

        void SaveChanges();
        Task SaveChangesAsync();
    }
}
