using AutoMapper;
using iTechArt.ManagementDemo.DataAccess.Interfaces;
using iTechArt.ManagementDemo.Entities.Abstractions;
using iTechArt.ManagementDemo.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace iTechArt.ManagementDemo.Services
{
    internal abstract class Service<TEntity, TDTO> : IService<TDTO>
        where TEntity : Entity
    {
        protected readonly IMapper _mapper;
        protected readonly ILogger _logger;
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IRepository<TEntity> _repository;


        public Service(
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IRepository<TEntity> repository,
            ILogger logger = null)
        {
            _mapper = mapper ?? throw new NullReferenceException();
            _unitOfWork = unitOfWork ?? throw new NullReferenceException();
            _repository = repository ?? throw new NullReferenceException();
            _logger = logger ?? throw new NullReferenceException();
        }


        public virtual async Task<TDTO> FindAsync(int id) =>
            _mapper.Map<TDTO>(
                await _repository.FindAsync(id));

        public virtual async Task<int> SaveAsync(TDTO item)
        {
            var entity = _mapper.Map<TEntity>(item);

            if (entity.IsTransient())
            {
                await _repository.AddAsync(entity);
            }
            else
            {
                _repository.Update(entity);
            }

            await _unitOfWork.SaveChangesAsync();

            return entity.Id;
        }

        public virtual async Task DeleteAsync(int id)
        {
            await _repository.RemoveAsync(id);

            await _unitOfWork.SaveChangesAsync();
        }
            
    }
}
