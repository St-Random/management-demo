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

        void Remove(int id);
        Task RemoveAsync(int id);

        void Update(TEntity entity);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
