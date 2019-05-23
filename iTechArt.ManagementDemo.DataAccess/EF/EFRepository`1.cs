using iTechArt.ManagementDemo.DataAccess.EF.Infrastructure;
using iTechArt.ManagementDemo.DataAccess.Interfaces;
using iTechArt.ManagementDemo.Entities.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iTechArt.ManagementDemo.DataAccess.EF
{
    internal class EFRepository<TEntity> : IRepository<TEntity>
        where TEntity : Entity
    {
        private readonly DbSet<TEntity> _dbSet;

        public EFRepository(IDbContextProvider dbContextProvider)
        {
            _dbSet = dbContextProvider
                ?.GetDbContext()
                ?.Set<TEntity>()
                ?? throw new ArgumentNullException();
        }

        public TEntity Find(int id) =>
            _dbSet.Find(id);

        public async Task<TEntity> FindAsync(int id) =>
            await _dbSet.FindAsync(id);

        public void Add(TEntity entity) =>
            _dbSet.Add(entity);

        public async Task AddAsync(TEntity entity) =>
            await _dbSet.AddAsync(entity);

        public void Update(TEntity entity) =>
            _dbSet.Update(entity);

        public void Remove(int id)
        {
            var entity = _dbSet.Find(id);
            Remove(entity);
        }

        public async Task RemoveAsync(int id)
        {
            var entity =
                await _dbSet.FindAsync(id);

            if (entity != null)
            {
                Remove(entity);
            }
        }

        public void Remove(TEntity entity) =>
            _dbSet.Remove(entity);

        public void RemoveRange(IEnumerable<TEntity> entities) =>
            _dbSet.RemoveRange(entities);

    }
}
