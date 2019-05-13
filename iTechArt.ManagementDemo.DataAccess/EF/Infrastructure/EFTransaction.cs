using iTechArt.ManagementDemo.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace iTechArt.ManagementDemo.DataAccess.EF.Infrastructure
{
    public class EFTransaction : ITransaction
    {
        private readonly IDbContextTransaction _transaction;


        public EFTransaction(IDbContextTransaction transaction)
        {
            _transaction = transaction;
        }


        public void Commit() =>
            _transaction.Commit();

        public void Rollback() =>
            _transaction.Rollback();
    }
}
