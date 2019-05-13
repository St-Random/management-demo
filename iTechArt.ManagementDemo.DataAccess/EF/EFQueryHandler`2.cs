using AutoMapper;
using iTechArt.ManagementDemo.DataAccess.EF.Infrastructure;
using iTechArt.ManagementDemo.DataAccess.EF.Infrastructure.Extensions;
using iTechArt.ManagementDemo.DataAccess.Infrastructure.Extensions;
using iTechArt.ManagementDemo.DataAccess.Interfaces;
using iTechArt.ManagementDemo.Entities.Abstractions;
using iTechArt.ManagementDemo.Querying;
using iTechArt.ManagementDemo.Querying.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace iTechArt.ManagementDemo.DataAccess.EF
{
    internal class EFQueryHandler<TEntity, TModel>
        : IQueryHandler<TEntity, TModel>
        where TEntity : Entity
        where TModel : IQueryModel
    {
        private readonly DbSet<TEntity> _dbSet;
        private readonly IMapper _mapper;


        public EFQueryHandler(
            IDbContextProvider dbContextProvider,
            IMapper mapper)
        {
            _dbSet = dbContextProvider
                ?.GetDbContext()
                ?.Set<TEntity>()
                ?? throw new ArgumentNullException();

            _mapper = mapper ?? throw new ArgumentNullException();
        }


        public TModel Find(int id) =>
            _mapper.Map<TModel>(
                _dbSet
                    .AsNoTracking()
                    .SingleOrDefault(e => e.Id == id));

        public async Task<TModel> FindAsync(int id) =>
            _mapper.Map<TModel>(
                await _dbSet
                    .AsNoTracking()
                    .SingleOrDefaultAsync(e => e.Id == id));

        public IQueryResult<TModel> Query(
            IQueryOptions options,
            Expression<Func<TEntity, bool>> filter = null)
        {
            var query = _dbSet.AsNoTracking();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return _mapper
                .ProjectTo<TModel>(query)
                .ApplyOptions(options);
        }


        public async Task<IQueryResult<TModel>> QueryAsync(
            IQueryOptions options,
            Expression<Func<TEntity, bool>> filter = null)
        {
            var query = _dbSet.AsNoTracking();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await _mapper
                .ProjectTo<TModel>(query)
                .ApplyOptionsAsync(options);
        }
    }
}
