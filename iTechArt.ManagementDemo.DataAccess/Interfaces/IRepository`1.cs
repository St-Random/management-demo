using iTechArt.ManagementDemo.Entities.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iTechArt.ManagementDemo.DataAccess.Interfaces
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        TEntity Find(int id);
        Task<TEntity> FindAsync(int id);

        void Add(TEntity entity);
        Task AddAsync(TEntity entity);

        void Update(TEntity entity);
        Task UpdateAsync(TEntity entity);

        void Remove(int id);
        Task RemoveAsync(int id);

        void Remove(TEntity entity);
        Task RemoveAsync(TEntity entity);

        void RemoveRange(IEnumerable<TEntity> entities);
        Task RemoveRangeAsync(IEnumerable<TEntity> entities);
    }
}
