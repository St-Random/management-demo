using iTechArt.ManagementDemo.Entities.Abstractions;
using iTechArt.ManagementDemo.Querying;
using iTechArt.ManagementDemo.Querying.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace iTechArt.ManagementDemo.DataAccess.Interfaces
{
    public interface IQueryHandler<TEntity, TModel>
        where TEntity : Entity
        where TModel : IQueryModel
    {
        IQueryResult<TModel> Query(
            IQueryOptions options,
            Expression<Func<TEntity, bool>> filter = null);
        Task<IQueryResult<TModel>> QueryAsync(
            IQueryOptions options,
            Expression<Func<TEntity, bool>> filter = null);

        IEnumerable<TModel> Get(
            Expression<Func<TEntity, bool>> filter = null);
        Task<IEnumerable<TModel>> GetAsync(
            Expression<Func<TEntity, bool>> filter = null);

        TModel Find(int id);
        Task<TModel> FindAsync(int id);
    }
}
